using UniEx;

namespace GameOff2023.Common.Data.Entity
{
    public sealed class UserNameEntity
    {
        public readonly string name;

        public UserNameEntity(string name)
        {
            if (IsInvalid(name))
            {
                throw new RetryException(ExceptionConfig.UNMATCHED_USER_NAME_RULE);
            }

            this.name = name;
        }

        private static bool IsInvalid(string value)
        {
            return
                string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value) ||
                value.Length.IsBetween(PlayFabConfig.MIN_NAME_LENGTH, PlayFabConfig.MAX_NAME_LENGTH) == false;
        }
    }
}