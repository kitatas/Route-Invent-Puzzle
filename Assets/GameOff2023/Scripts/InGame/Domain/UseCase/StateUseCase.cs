using System;
using GameOff2023.Base.Domain.UseCase;
using UniRx;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StateUseCase : BaseModelUseCase<GameState>
    {
        public StateUseCase()
        {
            Set(GameConfig.INIT_STATE);
        }

        public IObservable<GameState> gameState => property.Where(x => x != GameState.None);

        public bool IsEqual(GameState state)
        {
            return currentValue == state;
        }
    }
}