using System;

namespace GameOff2023.InGame.Data.Entity
{
    [Serializable]
    public sealed class LevelEntity
    {
        public int value;

        public void SetValue(int levelValue)
        {
            value = levelValue;
        }

        public bool IsEqual(LevelEntity levelEntity)
        {
            return levelEntity.value == value;
        }
    }
}