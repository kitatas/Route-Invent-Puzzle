namespace GameOff2023.InGame
{
    public enum GameState
    {
        None,
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
    }

    public enum CellType
    {
        None,
        Empty,
        Fixed,
        Stock,
    }
}