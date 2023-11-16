using GameOff2023.Base.Data.Entity;
using GameOff2023.InGame;

namespace GameOff2023.Common.Data.Entity
{
    public sealed class StateEntity : BaseEntity<GameState>
    {
        public bool IsState(GameState state)
        {
            return value == state;
        }
    }
}