using System.Collections.Generic;
using GameOff2023.Common.Data.Entity;
using Newtonsoft.Json;
using PlayFab.ClientModels;

namespace GameOff2023.Common.Data.DataStore
{
    public sealed class UserData
    {
        public static UserEntity New(string uid, string name, Dictionary<string, UserDataRecord> records)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new UserEntity
                {
                    id = uid,
                    // UserNameEntity の初期化は行わない 
                    progressEntity = GetUserProgress(records),
                };
            }
            else
            {
                return new UserEntity
                {
                    id = uid,
                    nameEntity = new UserNameEntity(name),
                    progressEntity = GetUserProgress(records),
                };
            }
        }

        private static UserProgressEntity GetUserProgress(Dictionary<string, UserDataRecord> records)
        {
            return records.TryGetValue(PlayFabConfig.USER_PROGRESS_KEY, out var record)
                ? JsonConvert.DeserializeObject<UserProgressEntity>(record.Value)
                : UserProgressEntity.Default();
        }
    }
}