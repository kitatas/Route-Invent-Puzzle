using System;
using GameOff2023.Common.Data.Entity;
using GameOff2023.Common.Domain.Repository;
using UniRx;

namespace GameOff2023.Common.Domain.UseCase
{
    public sealed class SoundUseCase
    {
        private readonly SaveRepository _saveRepository;
        private readonly SoundRepository _soundRepository;

        private readonly ReactiveProperty<float> _bgmVolume;
        private readonly ReactiveProperty<float> _seVolume;
        private readonly Subject<SoundEntity> _playBgm;
        private readonly Subject<SoundEntity> _playSe;

        public SoundUseCase(SaveRepository saveRepository, SoundRepository soundRepository)
        {
            _saveRepository = saveRepository;
            _soundRepository = soundRepository;

            var data = _saveRepository.Load();
            _bgmVolume = new ReactiveProperty<float>(data.bgmVolume);
            _seVolume = new ReactiveProperty<float>(data.seVolume);
            _playBgm = new Subject<SoundEntity>();
            _playSe = new Subject<SoundEntity>();
        }

        public IReadOnlyReactiveProperty<float> bgmVolume => _bgmVolume;
        public IReadOnlyReactiveProperty<float> seVolume => _seVolume;
        public IObservable<SoundEntity> playBgm => _playBgm;
        public IObservable<SoundEntity> playSe => _playSe;

        public void SetBgmVolume(float value)
        {
            _bgmVolume.Value = value;
            _saveRepository.SaveBgm(value);
        }

        public void SetSeVolume(float value)
        {
            _seVolume.Value = value;
            _saveRepository.SaveSe(value);
        }

        public void PlayBgm(BgmType type, float delay = 0.0f)
        {
            var data = _soundRepository.FindBgm(type);
            var soundEntity = new SoundEntity(data.clip, delay);
            _playBgm?.OnNext(soundEntity);
        }

        public void PlaySe(SeType type, float delay = 0.0f)
        {
            var data = _soundRepository.FindSe(type);
            var soundEntity = new SoundEntity(data.clip, delay);
            _playSe?.OnNext(soundEntity);
        }
    }
}