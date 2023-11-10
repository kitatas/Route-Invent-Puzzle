using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class InformationModalPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly InformationModalView _informationModal;

        [Inject]
        public InformationModalPresenter(SoundUseCase soundUseCase, InformationModalView informationModal)
        {
            _soundUseCase = soundUseCase;
            _informationModal = informationModal;
        }

        public void Start()
        {
            _informationModal.SetUp(x => _soundUseCase.PlaySe(x));
        }
    }
}