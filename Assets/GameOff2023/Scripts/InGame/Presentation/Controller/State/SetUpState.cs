using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class SetUpState : BaseState
    {
        private readonly PlayerView _playerView;
        private readonly StageView _stageView;

        public SetUpState(PlayerView playerView, StageView stageView)
        {
            _playerView = playerView;
            _stageView = stageView;
        }

        public override GameState state => GameState.SetUp;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _playerView.SetUp();
            _stageView.SetUp();
            await UniTaskHelper.DelayAsync(StageObjectConfig.SHOW_TIME, token);

            return GameState.Edit;
        }
    }
}