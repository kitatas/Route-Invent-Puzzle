using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Boot.Domain.UseCase;
using GameOff2023.Boot.Presentation.View;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using UnityEngine.SceneManagement;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Boot.Presentation.Controller
{
    public sealed class CheckState : BaseState
    {
        private readonly AppVersionUseCase _appVersionUseCase;
        private readonly LoadingUseCase _loadingUseCase;
        private readonly SoundUseCase _soundUseCase;

        public CheckState(AppVersionUseCase appVersionUseCase, LoadingUseCase loadingUseCase, SoundUseCase soundUseCase)
        {
            _appVersionUseCase = appVersionUseCase;
            _loadingUseCase = loadingUseCase;
            _soundUseCase = soundUseCase;
        }

        public override BootState state => BootState.Check;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            await _loadingUseCase.SetAsync(true, token);

            // マスタからバージョンチェック
            var isUpdate = await _appVersionUseCase.CheckUpdateAsync(token);

            await _loadingUseCase.SetAsync(false, token);

            if (isUpdate)
            {
                // 強制アップデート
                var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);
                await modalContainer
                    .Push(ModalType.Update.ToResourcePath(), true, "Update")
                    .ToUniTask(cancellationToken: token);

                if (modalContainer.Modals.TryGetValue("Update", out var modal) &&
                    modal is UpdateModalView updateModalView)
                {
                    updateModalView.Init(x => _soundUseCase.PlaySe(x));
                }
            }
            else
            {
                SceneManager.LoadScene(SceneName.Main.ToString());
            }

            return BootState.None;
        }
    }
}