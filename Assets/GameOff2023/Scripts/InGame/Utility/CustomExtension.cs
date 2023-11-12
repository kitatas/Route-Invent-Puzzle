using System;
using UnityEngine;

namespace GameOff2023.InGame
{
    public static class CustomExtension
    {
        public static Vector2 ToVector2(this Direction direction)
        {
            return direction switch
            {
                Direction.Up => Vector2.up,
                Direction.Down => Vector2.down,
                Direction.Left => Vector2.left,
                Direction.Right => Vector2.right,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public static Direction ToNextDirection(this CurveType type, Direction direction)
        {
            return (type, direction) switch
            {
                (CurveType.UpLeft, Direction.Down) => Direction.Left,
                (CurveType.UpLeft, Direction.Right) => Direction.Up,
                (CurveType.UpRight, Direction.Down) => Direction.Right,
                (CurveType.UpRight, Direction.Left) => Direction.Up,
                (CurveType.DownLeft, Direction.Up) => Direction.Left,
                (CurveType.DownLeft, Direction.Right) => Direction.Down,
                (CurveType.DownRight, Direction.Up) => Direction.Right,
                (CurveType.DownRight, Direction.Left) => Direction.Down,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}