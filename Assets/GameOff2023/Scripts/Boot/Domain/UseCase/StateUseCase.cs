using System;
using GameOff2023.Base.Domain.UseCase;
using UniRx;

namespace GameOff2023.Boot.Domain.UseCase
{
    public sealed class StateUseCase : BaseModelUseCase<BootState>
    {
        public IObservable<BootState> bootState => property.Where(x => x != BootState.None);
    }
}