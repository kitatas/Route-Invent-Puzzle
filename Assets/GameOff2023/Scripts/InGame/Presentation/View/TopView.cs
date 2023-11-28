using GameOff2023.Common;
using MagicTween;
using TMPro;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class TopView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI version = default;
        [SerializeField] private TextMeshProUGUI touch = default;

        private void Awake()
        {
            version.text = $"Ver.{AppConfig.APP_VERSION}";

            touch
                .TweenColorAlpha(0.0f, 1.5f)
                .SetEase(Ease.InQuint)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(gameObject);
        }
    }
}