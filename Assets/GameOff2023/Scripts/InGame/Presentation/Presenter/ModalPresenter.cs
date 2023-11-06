using GameOff2023.Base.Presentation.View;
using UnityEngine;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class ModalPresenter : IStartable
    {
        public void Start()
        {
            foreach (var buttonView in Object.FindObjectsOfType<BaseButtonView>())
            {
                buttonView.Init();
            }
        }
    }
}