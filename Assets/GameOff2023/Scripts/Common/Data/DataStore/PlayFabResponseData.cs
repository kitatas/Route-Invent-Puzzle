using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameOff2023.Common.Data.DataStore
{
    public sealed class PlayFabResponseData
    {
        public sealed class MasterData
        {
            private readonly Dictionary<string, string> _resultData;

            public MasterData(Dictionary<string, string> resultData)
            {
                _resultData = resultData;
            }

            public T DeserializeMaster<T>(string key)
            {
                return _resultData.TryGetValue(key, out var json)
                    ? JsonConvert.DeserializeObject<T>(json)
                    : throw new CrashException(ExceptionConfig.FAILED_DESERIALIZE_MASTER);
            }
        }
    }
}