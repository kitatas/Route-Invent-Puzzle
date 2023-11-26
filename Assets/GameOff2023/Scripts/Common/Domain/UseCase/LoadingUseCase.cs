using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Base.Domain.UseCase;

namespace GameOff2023.Common.Domain.UseCase
{
    public sealed class LoadingUseCase : BaseModelUseCase<bool>
    {
        public LoadingUseCase()
        {
            Set(false);
        }

        public async UniTask SetAsync(bool value, CancellationToken token)
        {
            Set(value);
            await UniTaskHelper.DelayAsync(ModalConfig.ANIMATION_TIME, token);
        }
    }
}