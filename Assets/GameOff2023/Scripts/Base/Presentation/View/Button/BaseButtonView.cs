using System;
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
            push.Subscribe(_ => _pushed?.Invoke())
                .AddTo(this);

            AddPushEvent(() =>
            {
                // 効果音再生
                playSe?.Invoke(seType);
            });
        }

        protected IObservable<Unit> push => button.OnClickAsObservable();

        public void AddPushEvent(Action action) => _pushed += action;
    }
}