namespace GameOff2023.Common.Data.Entity
{
    public sealed class UserEntity
    {
        public string id;
        public UserNameEntity nameEntity;
        public UserProgressEntity progressEntity;

        public void Set(UserEntity entity)
        {
            id = entity.id;
            nameEntity = entity.nameEntity;
            progressEntity = entity.progressEntity;
        }

        public void SetName(UserNameEntity name)
        {
            nameEntity = name;
        }

        public void SetProgress(UserProgressEntity progress)
        {
            progressEntity = progress;
        }

        public bool IsEmptyUserName()
        {
            return nameEntity == null || string.IsNullOrEmpty(nameEntity.name);
        }
    }
}