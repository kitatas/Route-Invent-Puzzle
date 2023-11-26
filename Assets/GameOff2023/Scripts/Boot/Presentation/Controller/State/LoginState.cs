using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Boot.Domain.UseCase;
using GameOff2023.Boot.Presentation.View;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Boot.Presentation.Controller
{
    public sealed class LoginState : BaseState
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly LoginUseCase _loginUseCase;
        private readonly SoundUseCase _soundUseCase;

        public LoginState(LoadingUseCase loadingUseCase, LoginUseCase loginUseCase, SoundUseCase soundUseCase)
        {
            _loadingUseCase = loadingUseCase;
            _loginUseCase = loginUseCase;
            _soundUseCase = soundUseCase;
        }

        public override BootState state => BootState.Login;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            await _loadingUseCase.SetAsync(true, token);

            var isLoginSuccess = await _loginUseCase.LoginAsync(token);
            if (isLoginSuccess == false)
            {
                await RegisterAsync(token);
            }

            await UniTask.Yield(token);
            return BootState.None;
        }

        private async UniTask RegisterAsync(CancellationToken token)
        {
            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);

            while (true)
            {
                await _loadingUseCase.SetAsync(false, token);

                await modalContainer
                    .Push(ModalType.Register.ToResourcePath(), true, "Register")
                    .ToUniTask(cancellationToken: token);

                var userName = "";
                if (modalContainer.Modals.TryGetValue("Register", out var modal) &&
                    modal is RegisterModalView registerModalView)
                {
                    userName = await registerModalView.DecisionNameAsync(x => _soundUseCase.PlaySe(x), token);
                    await UniTaskHelper.DelayAsync(ModalConfig.ANIMATION_TIME, token);
                }

                await _loadingUseCase.SetAsync(true, token);

                // 名前登録
                var isSuccess = await _loginUseCase.RegisterAsync(userName, token);
                if (isSuccess)
                {
                    break;
                }
            }
        }
    }
}