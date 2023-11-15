namespace GameOff2023.InGame
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.SetUp;
    }

    public sealed class StageConfig
    {
        public const int X = 9;
        public const int Y = 7;

        public const float JUDGE_DISTANCE = 0.01f;
    }

    public sealed class PlayerConfig
    {
        public const float ADJUST_TIME = 0.1f;
    }
}