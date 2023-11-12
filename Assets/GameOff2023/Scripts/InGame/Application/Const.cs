namespace GameOff2023.InGame
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.Edit;
    }

    public sealed class StageConfig
    {
        public const float JUDGE_DISTANCE = 0.01f;
    }

    public sealed class PlayerConfig
    {
        public const float ADJUST_TIME = 0.1f;
    }
}