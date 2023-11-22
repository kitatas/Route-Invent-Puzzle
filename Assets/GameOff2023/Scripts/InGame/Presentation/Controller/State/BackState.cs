using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using UnityScreenNavigator.Runtime.Core.Page;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class BackState : BaseState
    {
        private readonly StageUseCase _stageUseCase;
        private readonly GoalView _goalView;
        private readonly PlayerView _playerView;

        public BackState(StageUseCase stageUseCase, GoalView goalView, PlayerView playerView)
        {
            _stageUseCase = stageUseCase;
            _goalView = goalView;
            _playerView = playerView;
        }

        public override GameState state => GameState.Back;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _stageUseCase.Hide(StageObjectConfig.HIDE_TIME);
            _goalView.Hide(StageObjectConfig.HIDE_TIME);
            _playerView.Hide(StageObjectConfig.HIDE_TIME);

            var pageContainer = PageContainer.Find(PageConfig.INGAME_CONTAINER);
            pageContainer.Push(PageConfig.SELECT_PATH, true, stack: false);

            await UniTask.Yield(token);

            return GameState.None;
        }
    }
}