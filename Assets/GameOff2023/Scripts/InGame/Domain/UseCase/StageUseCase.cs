using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Domain.Repository;
using GameOff2023.InGame.Data.Entity;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StageUseCase
    {
        private StageEntity[] _stages;
        private readonly LevelEntity _levelEntity;
        private readonly PlayFabRepository _playFabRepository;

        public StageUseCase(LevelEntity levelEntity, PlayFabRepository playFabRepository)
        {
            _levelEntity = levelEntity;
            _playFabRepository = playFabRepository;
        }

        public async UniTask LoadStageAsync(CancellationToken token)
        {
            var masterData = await _playFabRepository.FetchMasterDataAsync(token);
            _stages = masterData.DeserializeMaster<StageEntity[]>(PlayFabConfig.MASTER_STAGE_KEY);
        }

        public List<LevelEntity> levelEntities =>
            _stages
                .Select(x => x.level)
                .OrderBy(x => x.value)
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
                throw new Exception();
            }

            return data;
        }
    }
}