using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class SetUpState : BaseState
    {
        private readonly PlayerView _playerView;

        public SetUpState(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public override GameState state => GameState.SetUp;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _playerView.SetUp();

            await UniTask.Yield(token);
            return GameState.Edit;
        }
    }
}