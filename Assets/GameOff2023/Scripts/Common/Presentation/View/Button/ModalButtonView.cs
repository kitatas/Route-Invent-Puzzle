using GameOff2023.Base.Presentation.View;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Common.Presentation.View
{
    public sealed class ModalButtonView : BaseButtonView
    {
        [SerializeField] private ModalType modalType = default;

        public void SetUp(ModalContainer modalContainer)
        {
            AddPushEvent(() =>
            {
                // モーダル表示
                modalContainer.Push(modalType.ToResourcePath(), true);
            });
        }
    }
}