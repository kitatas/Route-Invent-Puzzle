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

        public static bool IsEnter(this Direction direction1, Direction direction2)
        {
            return (direction1, direction2) switch
            {
                (Direction.Up, Direction.Down) => true,
                (Direction.Down, Direction.Up) => true,
                (Direction.Left, Direction.Right) => true,
                (Direction.Right, Direction.Left) => true,
                _ => false,
            };
        }

        public static Vector3 ToScale(this ScaleType type)
        {
            return type switch
            {
                ScaleType.Small => Vector3.one * 0.5f,
                ScaleType.Large => Vector3.one,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static Quaternion ToQuaternion(this Direction direction)
        {
            return direction switch
            {
                Direction.Up => Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)),
                Direction.Down => Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f)),
                Direction.Left => Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f)),
                Direction.Right => Quaternion.Euler(new Vector3(0.0f, 0.0f, 270.0f)),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public static PanelType ToPanel(this ObjectType type)
        {
            return type switch
            {
                ObjectType.CurveUpLeft => PanelType.CurveUpLeft,
                ObjectType.CurveUpRight => PanelType.CurveUpRight,
                ObjectType.CurveDownLeft => PanelType.CurveDownLeft,
                ObjectType.CurveDownRight => PanelType.CurveDownRight,
                ObjectType.TunnelUpUpDownDown => PanelType.TunnelUpUpDownDown,
                ObjectType.TunnelUpDownDownUp => PanelType.TunnelUpDownDownUp,
                ObjectType.TunnelUpLeftDownRight => PanelType.TunnelUpLeftDownRight,
                ObjectType.TunnelUpRightDownLeft => PanelType.TunnelUpRightDownLeft,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}