using DG.Tweening;
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

        protected virtual void Awake()
        {
            spriteRenderer.SetColorA(0.0f);
            transform.localScale = Vector3.one * StageObjectConfig.HIDE_SCALE_RATE;
        }

        public void SetPosition(Vector3 position, float duration = 0.0f)
        {
            if (duration.IsZero())
            {
                transform.position = position;
            }
            else
            {
                transform
                    .DOMove(position, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject);
            }
        }

        public virtual Tween Show(float duration)
        {
            return DOTween.Sequence()
                .Append(spriteRenderer
                    .DOFade(1.0f, duration))
                .Join(transform
                    .DOScale(Vector3.one * StageObjectConfig.SHOW_SCALE_RATE, duration))
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public virtual Tween Hide(float duration)
        {
            return DOTween.Sequence()
                .Append(spriteRenderer
                    .DOFade(0.0f, duration))
                .Join(transform
                    .DOScale(Vector3.one * StageObjectConfig.HIDE_SCALE_RATE, duration))
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }
    }
}