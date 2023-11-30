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
        Item = 4,
        CurveUpLeft = 5,
        CurveUpRight = 6,
        CurveDownLeft = 7,
        CurveDownRight = 8,
        TunnelUpUpDownDown = 9,
        TunnelUpDownDownUp = 10,
        TunnelUpLeftDownRight = 11,
        TunnelUpRightDownLeft = 12,
        StreetLargeVertical = 13,
        StreetLargeHorizontal = 14,
        StreetSmallVertical = 15,
        StreetSmallHorizontal = 16,
        TurnUp = 17,
        TurnDown = 18,
        TurnLeft = 19,
        TurnRight = 20,
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
        TurnUp = 13,
        TurnDown = 14,
        TurnLeft = 15,
        TurnRight = 16,
    }

    public enum CellType
    {
        None,
        Empty,
        Fixed,
        Stock,
    }
}