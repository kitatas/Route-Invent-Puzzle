using GameOff2023.Common.Data.Entity;

namespace GameOff2023.InGame.Data.Entity
{
    public sealed class ProgressEntity
    {
        public readonly LevelEntity levelEntity;
        private readonly UserProgressEntity _progressEntity;

        public ProgressEntity(LevelEntity levelEntity, UserProgressEntity progressEntity)
        {
            this.levelEntity = levelEntity;
            _progressEntity = progressEntity;
        }

        public int level => levelEntity.value;
        public bool isOpen => _progressEntity.level + 1 >= level;
        public bool isClear => _progressEntity.level >= level;
    }
}