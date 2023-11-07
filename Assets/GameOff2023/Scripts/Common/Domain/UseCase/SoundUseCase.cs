using System;
using GameOff2023.Common.Data.Entity;
using GameOff2023.Common.Domain.Repository;
using UniRx;

namespace GameOff2023.Common.Domain.UseCase
{
    public sealed class SoundUseCase
    {
        private readonly SoundRepository _soundRepository;

        private readonly Subject<SoundEntity> _playBgm;

        public SoundUseCase(SoundRepository soundRepository)
        {
            _soundRepository = soundRepository;

            _playBgm = new Subject<SoundEntity>();
        }

        public IObservable<SoundEntity> playBgm => _playBgm;

        public void PlayBgm(BgmType type, float delay = 0.0f)
        {
            var data = _soundRepository.FindBgm(type);
            var soundEntity = new SoundEntity(data.clip, delay);
            _playBgm?.OnNext(soundEntity);
        }
    }
}