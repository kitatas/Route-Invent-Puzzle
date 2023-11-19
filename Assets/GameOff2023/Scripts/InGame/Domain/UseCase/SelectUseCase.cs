using System.Collections.Generic;
using System.Linq;
using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.Repository;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class SelectUseCase
    {
        private readonly LevelEntity _levelEntity;
        private readonly StageRepository _stageRepository;

        public SelectUseCase(LevelEntity levelEntity, StageRepository stageRepository)
        {
            _levelEntity = levelEntity;
            _stageRepository = stageRepository;
        }

        public List<LevelEntity> levelEntities =>
            _stageRepository.stageData
                .Select(x => x.level)
                .OrderBy(x => x.value)
                .ToList();

        public void SelectLevel(LevelEntity levelEntity)
        {
            _levelEntity.SetValue(levelEntity.value);
        }
    }
}