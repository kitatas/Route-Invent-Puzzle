using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class TopPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly TopSheetView _topSheetView;

        [Inject]
        public TopPresenter(SoundUseCase soundUseCase, TopSheetView topSheetView)
        {
            _soundUseCase = soundUseCase;
            _topSheetView = topSheetView;
        }

        public void Start()
        {
            _topSheetView.SetUp(x => _soundUseCase.PlaySe(x));
        }
    }
}