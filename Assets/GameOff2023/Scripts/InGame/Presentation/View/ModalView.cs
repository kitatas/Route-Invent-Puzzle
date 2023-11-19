using System;
using GameOff2023.Common;
using GameOff2023.Common.Presentation.View;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class ModalView : MonoBehaviour
    {
        [SerializeField] private ModalButtonView optionButtonView = default;
        [SerializeField] private ModalButtonView informationButtonView = default;

        public void Init(Action<SeType> playSe, ModalContainer modalContainer)
        {
            optionButtonView.SetUp(playSe, modalContainer);
            informationButtonView.SetUp(playSe, modalContainer);
        }
    }
}