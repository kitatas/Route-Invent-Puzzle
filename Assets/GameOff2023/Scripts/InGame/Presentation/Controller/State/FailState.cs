using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class FailState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;

        public FailState(SoundUseCase soundUseCase)
        {
            _soundUseCase = soundUseCase;
        }

        public override GameState state => GameState.Fail;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // FailModalの表示
            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);
            await modalContainer.Push(ModalType.Fail.ToResourcePath(), true, modalId: ModalConfig.CLEAR_PATH);

            if (modalContainer.Modals.TryGetValue(ModalConfig.CLEAR_PATH, out var modal) &&
                modal is FailModalView failModalView)
            {
                // closeボタン押下待ち
                failModalView.SetUp(x => _soundUseCase.PlaySe(x));
                var next = await failModalView.PushCloseAsync(token);

                switch (next)
                {
                    case FailNextType.Retry:
                        // TODO: やり直し
                        break;
                    case FailNextType.Retire:
                        // TODO: Stage削除
                        // TODO: Selectに戻る
                        return GameState.None;
                    default:
                        throw new Exception();
                }
            }

            return GameState.None;
        }
    }
}