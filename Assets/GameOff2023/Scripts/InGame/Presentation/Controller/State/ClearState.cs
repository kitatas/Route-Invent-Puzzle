using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class ClearState : BaseState
    {
        public override GameState state => GameState.Clear;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return GameState.None;
        }
    }
}