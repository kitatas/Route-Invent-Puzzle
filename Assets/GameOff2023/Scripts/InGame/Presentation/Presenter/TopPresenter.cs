using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class TopPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly TopPageView _topPageView;

        [Inject]
        public TopPresenter(SoundUseCase soundUseCase, TopPageView topPageView)
        {
            _soundUseCase = soundUseCase;
            _topPageView = topPageView;
        }

        public void Start()
        {
            _topPageView.SetUp(x => _soundUseCase.PlaySe(x), PageConfig.SELECT_PATH);
        }
    }
}