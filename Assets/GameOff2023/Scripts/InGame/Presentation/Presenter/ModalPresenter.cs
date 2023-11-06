using GameOff2023.Base.Presentation.View;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
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

            _topView.Init();
        }
    }
}