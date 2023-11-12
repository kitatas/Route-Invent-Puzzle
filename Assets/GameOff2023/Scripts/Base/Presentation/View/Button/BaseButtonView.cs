using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using MagicTween;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2023.Base.Presentation.View
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] private Button button = default;
        [SerializeField] private SeType seType = default;

        private Action _pushed;

        public virtual void Init(Action<SeType> playSe)
        {
            push.Subscribe(_ => _pushed?.Invoke())
                .AddTo(this);

            var defaultScale = transform.localScale;

            AddPushEvent(() =>
            {
                // 効果音再生
                playSe?.Invoke(seType);

                transform
                    .TweenLocalScale(defaultScale * 0.8f, UiConfig.PUSH_TIME)
                    .SetEase(Ease.Linear)
                    .SetLoops(2, LoopType.Yoyo)
                    .SetLink(gameObject);
            });
        }

        protected IObservable<Unit> push => button.OnClickAsObservable();

        public async UniTask PushAsync(CancellationToken token)
        {
            await push.ToUniTask(true, token);
        }

        public void AddPushEvent(Action action) => _pushed += action;
    }
}