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

        public override IEnumerator Initialize()
        {
            closeButtonView.AddPushEvent(() =>
            {
                // モーダルの非表示
                var modalContainer = ModalContainer.Of(transform);
                modalContainer.Pop(true);
            });

            yield break;
        }

        public virtual void SetUp(Action<SeType> playSe)
        {
            closeButtonView.Init(playSe);
        }
    }
}