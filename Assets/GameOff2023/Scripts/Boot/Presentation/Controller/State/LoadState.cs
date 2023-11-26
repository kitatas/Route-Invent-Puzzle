using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2023.Boot.Presentation.Controller
{
    public sealed class LoadState : BaseState
    {
        public override BootState state => BootState.Load;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            // NOTE: 起動前に読み込み必要なもの
            await UniTask.Yield(token);

            return BootState.None;
        }
    }
}