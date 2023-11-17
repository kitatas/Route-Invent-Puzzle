namespace GameOff2023.InGame
{
    public enum GameState
    {
        None,
        SetUp,
        Edit,
        Move,
    }

    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    public enum CurveType
    {
        None,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
    }

    public enum ObjectType
    {
        None = 0,
        Player = 1,
        Goal = 2,
    }

    public enum PanelType
    {
        None = 0,
        CurveUpLeft = 1,
        CurveUpRight = 2,
        CurveDownLeft = 3,
        CurveDownRight = 4,
    }

    public enum CellType
    {
        None,
        Empty,
        Fixed,
    }
}