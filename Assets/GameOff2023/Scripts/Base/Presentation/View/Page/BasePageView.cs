using System;
using GameOff2023.Common;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;

namespace GameOff2023.Base.Presentation.View
{
    public abstract class BasePageView : Page
    {
        [SerializeField] protected BaseButtonView closeButtonView = default;

        protected PageContainer container => PageContainer.Of(transform);

        public virtual void SetUp(Action<SeType> playSe, string nextResourceKey)
        {
            closeButtonView.Init(playSe);

            if (string.IsNullOrEmpty(nextResourceKey) == false)
            {
                closeButtonView.AddPushEvent(() =>
                {
                    // 次に表示するPageのResourceKey
                    container.Push(nextResourceKey, true, stack: false);
                });
            }
        }
    }
}