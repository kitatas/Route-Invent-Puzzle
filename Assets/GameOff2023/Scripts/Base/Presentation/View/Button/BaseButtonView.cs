using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2023.Base.Presentation.View
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] private Button button = default;

        private Action _pushed;

        public virtual void Init()
        {
            push.Subscribe(_ => _pushed?.Invoke())
                .AddTo(this);
        }

        protected IObservable<Unit> push => button.OnClickAsObservable();

        public void AddPushEvent(Action action) => _pushed += action;
    }
}