using GameOff2023.Common.Presentation.View;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class TopView : MonoBehaviour
    {
        [SerializeField] private ModalButtonView optionButtonView = default;
        [SerializeField] private ModalButtonView informationButtonView = default;

        public void Init(ModalContainer modalContainer)
        {
            optionButtonView.SetUp(modalContainer);
            informationButtonView.SetUp(modalContainer);
        }
    }
}