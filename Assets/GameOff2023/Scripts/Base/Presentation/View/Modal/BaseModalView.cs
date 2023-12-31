using System;
using System.Collections;
using GameOff2023.Common;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Base.Presentation.View
{
    public abstract class BaseModalView : Modal
    {
        [SerializeField] protected BaseButtonView closeButtonView = default;

        protected ModalContainer modalContainer => ModalContainer.Of(transform);

        public override IEnumerator Initialize()
        {
            if (closeButtonView)
            {
                closeButtonView.AddPushEvent(() =>
                {
                    // モーダルの非表示
                    modalContainer.Pop(true);
                });
            }

            yield break;
        }

        public virtual void SetUp(Action<SeType> playSe)
        {
            closeButtonView.Init(playSe);
        }
    }
}