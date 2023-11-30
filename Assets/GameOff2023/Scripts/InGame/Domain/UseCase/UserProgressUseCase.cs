using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Data.Entity;
using GameOff2023.Common.Domain.Repository;
using GameOff2023.InGame.Data.Entity;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class UserProgressUseCase
    {
        private readonly LevelEntity _levelEntity;
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;

        public UserProgressUseCase(LevelEntity levelEntity, UserEntity userEntity, PlayFabRepository playFabRepository)
        {
            _levelEntity = levelEntity;
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
        }


        public async UniTask SendProgressAsync(CancellationToken token)
        {
            if (_userEntity.progressEntity.IsUpdate(_levelEntity))
            {
                var progress = _userEntity.progressEntity.Update(_levelEntity);
                await _playFabRepository.UpdateUserProgressAsync(progress, token);

                _userEntity.SetProgress(progress);
            }
            else
            {
                await UniTask.Yield(token);
            }
        }
    }
}