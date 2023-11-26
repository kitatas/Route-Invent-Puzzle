using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class BuildState : BaseState
    {
        private readonly StageUseCase _stageUseCase;
        private readonly GoalView _goalView;
        private readonly PlayerView _playerView;
        private readonly StageView _stageView;

        public BuildState(StageUseCase stageUseCase, GoalView goalView, PlayerView playerView, StageView stageView)
        {
            _stageUseCase = stageUseCase;
            _goalView = goalView;
            _playerView = playerView;
            _stageView = stageView;
        }

        public override GameState state => GameState.Build;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _stageView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // Transition完了待ち
            await UniTask.Delay(TimeSpan.FromSeconds(PageConfig.ANIMATION_TIME), cancellationToken: token);

            await _stageView.BuildBaseAsync(token);
            await UniTask.Delay(TimeSpan.FromSeconds(StageObjectConfig.SHOW_TIME), cancellationToken: token);

            var stageEntity = _stageUseCase.GetStage();
            _stageView.BuildField(stageEntity.cells, _playerView, _goalView);
            _stageView.BuildPanel(stageEntity.panels);
            await UniTask.Delay(TimeSpan.FromSeconds(StageObjectConfig.SHOW_TIME), cancellationToken: token);

            return GameState.SetUp;
        }
    }
}