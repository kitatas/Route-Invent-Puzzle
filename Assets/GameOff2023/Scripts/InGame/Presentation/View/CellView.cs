using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class CellView : StageObjectView
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

        public bool IsEqualPosition(int x, int y)
        {
            return currentPosition.x.IsEqual(x) && currentPosition.y.IsEqual(y);
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}