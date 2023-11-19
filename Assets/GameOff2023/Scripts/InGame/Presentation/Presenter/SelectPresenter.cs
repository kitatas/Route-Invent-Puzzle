using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class SelectPresenter : IStartable
    {
        private readonly SelectUseCase _selectUseCase;
        private readonly SoundUseCase _soundUseCase;
        private readonly SelectSheetView _selectSheetView;

        public SelectPresenter(SelectUseCase selectUseCase, SoundUseCase soundUseCase, SelectSheetView selectSheetView)
        {
            _selectUseCase = selectUseCase;
            _soundUseCase = soundUseCase;
            _selectSheetView = selectSheetView;
        }

        public void Start()
        {
            foreach (var levelEntity in _selectUseCase.levelEntities)
            {
                _selectSheetView.Init(x => _soundUseCase.PlaySe(x), levelEntity, _selectUseCase.SelectLevel);
            }
        }
    }
}