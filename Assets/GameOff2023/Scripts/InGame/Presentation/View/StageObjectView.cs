using MagicTween;
using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class StageObjectView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer spriteRenderer = default;

        public Vector3 currentPosition => transform.position;

        public int currentXToInt => Mathf.RoundToInt(currentPosition.x);
        public int currentYToInt => Mathf.RoundToInt(currentPosition.y);

        public void SetPosition(Vector3 position, float duration = 0.0f)
        {
            if (duration.IsZero())
            {
                transform.position = position;
            }
            else
            {
                transform
                    .TweenPosition(position, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject);
            }
        }

        public virtual Tween Show(float duration)
        {
            return spriteRenderer
                .TweenColorAlpha(1.0f, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public virtual Tween Hide(float duration)
        {
            return spriteRenderer
                .TweenColorAlpha(0.0f, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }
    }
}