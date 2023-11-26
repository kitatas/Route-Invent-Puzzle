using System.Collections.Generic;
using GameOff2023.Common.Data.Entity;
using PlayFab.ClientModels;

namespace GameOff2023.Common.Data.DataStore
{
    public sealed class PlayFabRequestData
    {
        public static LoginWithCustomIDRequest LoginWithCustomIDRequest(string uid)
        {
            return new LoginWithCustomIDRequest
            {
                CustomId = uid,
                CreateAccount = true,
                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetUserData = true,
                    GetPlayerProfile = true,
                },
            };
        }

        public static UpdateUserTitleDisplayNameRequest UpdateUserTitleDisplayNameRequest(UserNameEntity nameEntity)
        {
            return new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = nameEntity.name,
            };
        }
    }
}