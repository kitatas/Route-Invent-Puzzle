using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class GamePresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly GamePageView _gamePageView;

        public GamePresenter(SoundUseCase soundUseCase, GamePageView gamePageView)
        {
            _soundUseCase = soundUseCase;
            _gamePageView = gamePageView;
        }

        public void Start()
        {
            _gamePageView.SetUp(x => _soundUseCase.PlaySe(x), PageConfig.SELECT_PATH);
        }
    }
}