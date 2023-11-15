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
}