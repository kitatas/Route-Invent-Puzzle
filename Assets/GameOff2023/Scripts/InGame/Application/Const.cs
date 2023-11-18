using UnityEngine;

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

    public sealed class CellConfig
    {
        public static readonly Color DEFAULT_COLOR = Color.cyan;
        public static readonly Color PLACEABLE_COLOR = Color.yellow;
    }

    public sealed class PanelConfig
    {
        public const float ADJUST_TIME = 0.1f;
        public const float SCALE_UP_RATE = 1.2f;
    }

    public sealed class PlayerConfig
    {
        public const float ADJUST_TIME = 0.1f;
    }
}