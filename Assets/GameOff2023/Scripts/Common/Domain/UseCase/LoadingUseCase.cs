using GameOff2023.Base.Domain.UseCase;

namespace GameOff2023.Common.Domain.UseCase
{
    public sealed class LoadingUseCase : BaseModelUseCase<bool>
    {
        public LoadingUseCase()
        {
            Set(false);
        }
    }
}