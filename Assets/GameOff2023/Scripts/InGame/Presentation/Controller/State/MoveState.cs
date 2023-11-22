using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class MoveState : BaseState
    {
        private readonly StageUseCase _stageUseCase;
        private readonly GoalView _goalView;
        private readonly PlayerView _playerView;

        public MoveState(StageUseCase stageUseCase, GoalView goalView, PlayerView playerView)
        {
            _stageUseCase = stageUseCase;
            _goalView = goalView;
            _playerView = playerView;
        }

        public override GameState state => GameState.Move;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _goalView.Init();
            _playerView.Init();

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

                if (_goalView.IsGoal(_playerView))
                {
                    await _playerView.TweenPositionAsync(_goalView.currentPosition, token);
                    return GameState.Clear;
                }

                var deltaTime = Time.deltaTime;
                _playerView.Tick(deltaTime);

                _stageUseCase.ExecPanelEffect(_playerView);

                await UniTask.Yield(token);
            }
        }
    }
}