using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Data.Entity;
using GameOff2023.Common.Domain.Repository;
using GameOff2023.InGame.Data.Entity;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StageUseCase
    {
        private StageEntity[] _stages;
        private readonly LevelEntity _levelEntity;
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;

        public StageUseCase(LevelEntity levelEntity, UserEntity userEntity, PlayFabRepository playFabRepository)
        {
            _levelEntity = levelEntity;
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
        }

        public async UniTask LoadStageAsync(CancellationToken token)
        {
            var masterData = await _playFabRepository.FetchMasterDataAsync(token);
            _stages = masterData.DeserializeMaster<StageEntity[]>(PlayFabConfig.MASTER_STAGE_KEY);
        }

        public List<ProgressEntity> progressEntities =>
            _stages
                .Select(x => new ProgressEntity(x.level, _userEntity.progressEntity))
                .OrderBy(x => x.level)
                .ToList();

        public void SelectLevel(LevelEntity levelEntity)
        {
            _levelEntity.SetValue(levelEntity.value);
        }

        public StageEntity GetStage()
        {
            var data = _stages.ToList().Find(x => x.level.IsEqual(_levelEntity));
            if (data == null)
            {
                throw new CrashException(ExceptionConfig.NOT_FOUND_STAGE);
            }

            return data;
        }
    }
}