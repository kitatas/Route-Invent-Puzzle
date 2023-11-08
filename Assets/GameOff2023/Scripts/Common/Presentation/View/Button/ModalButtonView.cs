using System;
using System.Linq;
using GameOff2023.Base.Presentation.View;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Common.Presentation.View
{
    public sealed class ModalButtonView : BaseButtonView
    {
        [SerializeField] private ModalType modalType = default;

        public void SetUp(ModalContainer modalContainer, Action<SeType> playSe)
        {
            AddPushEvent(() =>
            {
                // モーダル表示
                modalContainer.Push(modalType.ToResourcePath(), true).OnTerminate += () =>
                {
                    // 表示したモーダルの取得
                    var modal = modalContainer.Modals.Last().Value;
                    if (modal is BaseModalView baseModalView)
                    {
                        baseModalView.SetUp(playSe);
                    }
                };
            });
        }
    }
}