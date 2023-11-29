using GameOff2023.InGame.Data.Entity;
using UnityEngine;

namespace GameOff2023.InGame
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.Build;
    }

    public sealed class StageConfig
    {
        public const int X = 9;
        public const int Y = 7;

        public const float JUDGE_DISTANCE = 0.01f;

        public static readonly CellEntity[] FRAME_WALL = new[]
        {
            new CellEntity { type = ObjectType.Wall, x = 1, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 1, y = 2 },
            new CellEntity { type = ObjectType.Wall, x = 1, y = 3 },
            new CellEntity { type = ObjectType.Wall, x = 1, y = 4 },
            new CellEntity { type = ObjectType.Wall, x = 1, y = 5 },
            new CellEntity { type = ObjectType.Wall, x = 1, y = 6 },
            new CellEntity { type = ObjectType.Wall, x = 1, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 2, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 2, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 3, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 3, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 4, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 4, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 5, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 5, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 6, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 6, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 7, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 7, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 8, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 8, y = 7 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 1 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 2 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 3 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 4 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 5 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 6 },
            new CellEntity { type = ObjectType.Wall, x = 9, y = 7 },
        };
    }

    public sealed class StageObjectConfig
    {
        public const float SHOW_TIME = 0.25f;
        public const float HIDE_TIME = 0.25f;

        public const float HIDE_SCALE_RATE = 0.5f;
        public const float SHOW_SCALE_RATE = 1.0f;
    }

    public sealed class CellConfig
    {
        public static readonly Color DEFAULT_COLOR = Color.white;
        public static readonly Color PLACEABLE_COLOR = Color.yellow;
    }

    public sealed class PanelConfig
    {
        public const float ADJUST_TIME = 0.1f;
        public const float SCALE_UP_RATE = 1.2f;

        public static readonly Color STOCK_COLOR = new Color(1.0f, 1.0f, 0.75f);
    }

    public sealed class PlayerConfig
    {
        public const float ADJUST_TIME = 0.1f;

        public static readonly Direction[] DIRECTIONS = new[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left,
        };
    }
}