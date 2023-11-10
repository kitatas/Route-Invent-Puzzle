using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class OptionPresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly OptionModalView _optionModalView;
        private readonly VolumeView _volumeView;

        [Inject]
        public OptionPresenter(SoundUseCase soundUseCase, OptionModalView optionModalView, VolumeView volumeView)
        {
            _soundUseCase = soundUseCase;
            _optionModalView = optionModalView;
            _volumeView = volumeView;
        }

        public void Start()
        {
            _optionModalView.SetUp(x => _soundUseCase.PlaySe(x));
            _volumeView.Init(_soundUseCase.volumeEntity);

            _volumeView.updateBgmVolume
                .Subscribe(_soundUseCase.SetBgmVolume)
                .AddTo(_volumeView);

            _volumeView.updateSeVolume
                .Subscribe(_soundUseCase.SetSeVolume)
                .AddTo(_volumeView);

            _volumeView.releaseVolume
                .Subscribe(x => _soundUseCase.PlaySe(x))
                .AddTo(_volumeView);
        }
    }
}