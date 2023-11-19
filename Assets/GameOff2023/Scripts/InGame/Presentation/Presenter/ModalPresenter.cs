using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using UnityScreenNavigator.Runtime.Core.Modal;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class ModalPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly ModalView _modalView;

        public ModalPresenter(ModalView modalView, SoundUseCase soundUseCase)
        {
            _soundUseCase = soundUseCase;
            _modalView = modalView;
        }

        public void Start()
        {
            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);
            _modalView.Init(x => _soundUseCase.PlaySe(x), modalContainer);
        }
    }
}