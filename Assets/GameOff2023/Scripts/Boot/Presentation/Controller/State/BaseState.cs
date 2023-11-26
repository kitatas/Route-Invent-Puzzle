using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2023.Boot.Presentation.Controller
{
    public abstract class BaseState
    {
        public abstract BootState state { get; }

#pragma warning disable CS1998
        public virtual async UniTask InitAsync(CancellationToken token)
#pragma warning restore CS1998
        {

        }

#pragma warning disable CS1998
        public virtual async UniTask<BootState> TickAsync(CancellationToken token)
#pragma warning restore CS1998
        {
            return BootState.None;
        }
    }
}