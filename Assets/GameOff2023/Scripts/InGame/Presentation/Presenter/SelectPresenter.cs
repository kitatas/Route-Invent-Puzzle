using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class SelectPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly StageUseCase _stageUseCase;
        private readonly SelectPageView _selectPageView;

        public SelectPresenter(SoundUseCase soundUseCase, StageUseCase stageUseCase, SelectPageView selectPageView)
        {
            _soundUseCase = soundUseCase;
            _stageUseCase = stageUseCase;
            _selectPageView = selectPageView;
        }

        public void Start()
        {
            _selectPageView.SetUp(x => _soundUseCase.PlaySe(x), PageConfig.TOP_PATH);

            foreach (var levelEntity in _stageUseCase.levelEntities)
            {
                _selectPageView.Init(x => _soundUseCase.PlaySe(x), levelEntity, _stageUseCase.SelectLevel);
            }
        }
    }
}