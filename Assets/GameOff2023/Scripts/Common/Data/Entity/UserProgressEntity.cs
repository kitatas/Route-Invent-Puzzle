using GameOff2023.InGame.Data.Entity;
using Newtonsoft.Json;

namespace GameOff2023.Common.Data.Entity
{
    public sealed class UserProgressEntity
    {
        public int level;

        public static UserProgressEntity Default()
        {
            return new UserProgressEntity
            {
                level = 0,
            };
        }

        public bool IsUpdate(LevelEntity levelEntity)
        {
            return levelEntity.value > level;
        }

        public UserProgressEntity Update(LevelEntity levelEntity)
        {
            return new UserProgressEntity
            {
                level = IsUpdate(levelEntity) ? levelEntity.value : level,
            };
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}