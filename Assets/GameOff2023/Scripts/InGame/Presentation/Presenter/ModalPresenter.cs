using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class ModalPresenter : IStartable
    {
        private readonly TopView _topView;

        public ModalPresenter(TopView topView)
        {
            _topView = topView;
        }

        public void Start()
        {
            foreach (var buttonView in Object.FindObjectsOfType<BaseButtonView>())
            {
                buttonView.Init();
            }

            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);
            _topView.Init(modalContainer);
        }
    }
}