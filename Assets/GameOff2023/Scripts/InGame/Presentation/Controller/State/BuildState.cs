using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class BuildState : BaseState
    {
        private readonly StageView _stageView;

        public BuildState(StageView stageView)
        {
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
            await _stageView.BuildAsync(token);

            return GameState.SetUp;
        }
    }
}