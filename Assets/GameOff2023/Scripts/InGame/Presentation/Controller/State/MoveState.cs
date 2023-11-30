using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class MoveState : BaseState
    {
        private readonly GoalView _goalView;
        private readonly PlayerView _playerView;
        private readonly StageView _stageView;

        public MoveState(GoalView goalView, PlayerView playerView, StageView stageView)
        {
            _goalView = goalView;
            _playerView = playerView;
            _stageView = stageView;
        }

        public override GameState state => GameState.Move;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            while (true)
            {
                if (_playerView.isDead)
                {
                    return GameState.Fail;
                }

                if (_goalView.IsGoal(_playerView) && _stageView.IsAllItemPicked())
                {
                    await _playerView.TweenPositionAsync(_goalView.currentPosition, token);
                    return GameState.Send;
                }

                var deltaTime = Time.deltaTime;
                _playerView.Tick(deltaTime);

                _stageView.ExecPanelEffect(_playerView);

                await UniTask.Yield(token);
            }
        }
    }
}