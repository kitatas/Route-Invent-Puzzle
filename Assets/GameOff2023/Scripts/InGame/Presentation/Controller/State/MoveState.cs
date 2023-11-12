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

        public MoveState(GoalView goalView, PlayerView playerView)
        {
            _goalView = goalView;
            _playerView = playerView;
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
                if (_goalView.IsGoal(_playerView))
                {
                    break;
                }

                var deltaTime = Time.deltaTime;
                _playerView.Tick(deltaTime);

                await UniTask.Yield(token);
            }

            await _playerView.TweenPositionAsync(_goalView.currentPosition, token);

            return GameState.None;
        }
    }
}