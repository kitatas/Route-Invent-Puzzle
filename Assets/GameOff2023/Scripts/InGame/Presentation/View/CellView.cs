using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class CellView : StageObjectView
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

        public CellType cellType { get; private set; } = CellType.Empty;

        public void SetType(CellType type)
        {
            cellType = type;
        }

        public bool IsEqualPosition(int x, int y)
        {
            return currentPosition.x.IsEqual(x) && currentPosition.y.IsEqual(y);
        }

        public void SetColor(Color color)
        {
            // Stockの場合は色変えしない
            if (cellType == CellType.Stock)
            {
                return;
            }

            spriteRenderer.color = color;
        }
    }
}