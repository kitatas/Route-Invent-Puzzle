using GameOff2023.Common.Domain.UseCase;
using GameOff2023.Common.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace GameOff2023.Common.Presentation.Presenter
{
    public sealed class SoundPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly SoundView _soundView;

        public SoundPresenter(SoundUseCase soundUseCase, SoundView soundView)
        {
            _soundUseCase = soundUseCase;
            _soundView = soundView;
        }

        public void Start()
        {
            _soundUseCase.playBgm
                .Subscribe(x => _soundView.PlayBgm(x.clip, x.delay))
                .AddTo(_soundView);

            _soundUseCase.playSe
                .Subscribe(x => _soundView.PlaySe(x.clip, x.delay))
                .AddTo(_soundView);
        }
    }
}