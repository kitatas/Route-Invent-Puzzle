using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.Common.Presentation.View;
using UnityEngine.SceneManagement;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Common.Presentation.Controller
{
    public sealed class ExceptionController
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly SoundUseCase _soundUseCase;

        public ExceptionController(LoadingUseCase loadingUseCase, SoundUseCase soundUseCase)
        {
            _loadingUseCase = loadingUseCase;
            _soundUseCase = soundUseCase;
        }

        public async UniTask<ExceptionType> ShowAsync(Exception exception, CancellationToken token)
        {
            // Loading表示中の場合も考えられるので、非表示にする
            await _loadingUseCase.SetAsync(false, token);

            if (exception is OperationCanceledException)
            {
                // cancel時は何もしない
                return ExceptionType.Cancel;
            }

            // ExceptionModalの表示
            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);
            await modalContainer
                .Push(ModalType.Exception.ToResourcePath(), true, modalId: ModalConfig.EXCEPTION_PATH)
                .ToUniTask(cancellationToken: token);

            if (modalContainer.Modals.TryGetValue(ModalConfig.EXCEPTION_PATH, out var modal) &&
                modal is ExceptionModalView exceptionModalView)
            {
                exceptionModalView.SetUp(x => _soundUseCase.PlaySe(x));

                switch (exception)
                {
                    case RetryException:
                        await exceptionModalView.SetMessageAndCloseAsync(exception.Message, token);
                        return ExceptionType.Retry;
                    case RebootException:
                        await exceptionModalView.SetMessageAndCloseAsync(exception.Message, token);
                        SceneManager.LoadScene(SceneName.Boot.ToString());
                        return ExceptionType.Reboot;
                    default:
                        // 予期せぬ例外のため、強制終了させる
                        var message = exception is CrashException
                            ? exception.Message
                            : ExceptionConfig.UNKNOWN_ERROR;
                        await exceptionModalView.SetMessageAndCloseAsync(message, token);
                        return ExceptionType.Crash;
                }
            }

            return ExceptionType.None;
        }
    }
}