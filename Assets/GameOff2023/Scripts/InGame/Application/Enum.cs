namespace GameOff2023.InGame
{
    public enum GameState
    {
        None,
        Build,
        SetUp,
        Edit,
        Move,
        Clear,
        Fail,
        Back,
    }

    public enum FailNextType
    {
        None,
        Retry,
        Retire,
    }

    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    public enum ScaleType
    {
        None,
        Small,
        Large,
    }

    public enum ObjectType
    {
        None = 0,
        Player = 1,
        Goal = 2,
        Wall = 3,
        CurveUpLeft = 4,
        CurveUpRight = 5,
        CurveDownLeft = 6,
        CurveDownRight = 7,
        TunnelUpUpDownDown = 8,
        TunnelUpDownDownUp = 9,
        TunnelUpLeftDownRight = 10,
        TunnelUpRightDownLeft = 11,
        StreetLargeVertical = 12,
        StreetLargeHorizontal = 13,
        StreetSmallVertical = 14,
        StreetSmallHorizontal = 15,
    }

    public enum PanelType
    {
        None = 0,
        CurveUpLeft = 1,
        CurveUpRight = 2,
        CurveDownLeft = 3,
        CurveDownRight = 4,
        TunnelUpUpDownDown = 5,
        TunnelUpDownDownUp = 6,
        TunnelUpLeftDownRight = 7,
        TunnelUpRightDownLeft = 8,
        StreetLargeVertical = 9,
        StreetLargeHorizontal = 10,
        StreetSmallVertical = 11,
        StreetSmallHorizontal = 12,
    }

    public enum CellType
    {
        None,
        Empty,
        Fixed,
        Stock,
    }
}