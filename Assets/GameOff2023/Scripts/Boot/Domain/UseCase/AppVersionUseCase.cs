using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Boot.Data.Entity;
using GameOff2023.Common;
using GameOff2023.Common.Domain.Repository;

namespace GameOff2023.Boot.Domain.UseCase
{
    public sealed class AppVersionUseCase
    {
        private readonly PlayFabRepository _playFabRepository;

        public AppVersionUseCase(PlayFabRepository playFabRepository)
        {
            _playFabRepository = playFabRepository;
        }

        public async UniTask<bool> CheckUpdateAsync(CancellationToken token)
        {
#if UNITY_WEBGL
            await UniTask.Yield(token);
            return false;
#else
            var masterData = await _playFabRepository.FetchMasterDataAsync(token);
            var appVersion = masterData.DeserializeMaster<AppVersionEntity>(PlayFabConfig.MASTER_APP_VERSION_KEY);
            return appVersion.IsForceUpdate();
#endif
        }
    }
}