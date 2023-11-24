using MagicTween;
using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class BackgroundView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer field = default;
        [SerializeField] private SpriteRenderer stock = default;

        public void Init()
        {
            field.SetColorA(0.0f);
            stock.SetColorA(0.0f);
        }

        public Tween Show(float duration)
        {
            return TweenAlpha(1.0f, duration);
        }

        public Tween Hide(float duration)
        {
            return TweenAlpha(0.0f, duration);
        }

        private Tween TweenAlpha(float target, float duration)
        {
            return Sequence.Create()
                .Append(field
                    .TweenColorAlpha(target, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject))
                .Join(stock
                    .TweenColorAlpha(target, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject));
        }
    }
}