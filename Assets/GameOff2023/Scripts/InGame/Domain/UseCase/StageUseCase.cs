using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.Repository;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StageUseCase
    {
        private readonly LevelEntity _levelEntity;
        private readonly StageRepository _stageRepository;

        public StageUseCase(LevelEntity levelEntity, StageRepository stageRepository)
        {
            _levelEntity = levelEntity;
            _stageRepository = stageRepository;
        }

        public Data.DataStore.StageData GetStageData()
        {
            return _stageRepository.FindStageData(_levelEntity);
        }
    }
}