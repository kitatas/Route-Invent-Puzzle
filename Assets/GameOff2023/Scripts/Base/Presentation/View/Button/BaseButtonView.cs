using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameOff2023.Common;
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
            push.ThrottleFirst(TimeSpan.FromSeconds(UiConfig.PUSH_TIME * 2))
                .Subscribe(_ => _pushed?.Invoke())
                .AddTo(this);

            var defaultScale = transform.localScale;

            AddPushEvent(() =>
            {
                // 効果音再生
                playSe?.Invoke(seType);

                transform
                    .DOScale(0.8f, UiConfig.PUSH_TIME)
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

        public void Activate(bool value)
        {
            button.interactable = value;
        }
    }
}