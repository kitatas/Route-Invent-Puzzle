using System;
using GameOff2023.Base.Domain.UseCase;
using GameOff2023.Common.Data.Entity;
using UniRx;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StateUseCase : BaseModelUseCase<GameState>
    {
        private readonly StateEntity _stateEntity;

        public StateUseCase(StateEntity stateEntity)
        {
            _stateEntity = stateEntity;
            Set(GameConfig.INIT_STATE);
        }

        public IObservable<GameState> gameState => property.Where(x => x != GameState.None);

        public override void Set(GameState value)
        {
            _stateEntity.Set(value);
            base.Set(_stateEntity.value);
        }

        public bool IsEqual(GameState state)
        {
            return _stateEntity.IsState(state);
        }
    }
}