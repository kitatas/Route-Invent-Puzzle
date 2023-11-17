using GameOff2023.Base.Data.Entity;

namespace GameOff2023.InGame.Data.Entity
{
    public sealed class StateEntity : BaseEntity<GameState>
    {
        public bool IsState(GameState state)
        {
            return value == state;
        }
    }
}