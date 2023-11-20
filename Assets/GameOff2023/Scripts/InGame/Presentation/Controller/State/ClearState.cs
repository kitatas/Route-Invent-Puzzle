using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class ClearState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;

        public ClearState(SoundUseCase soundUseCase)
        {
            _soundUseCase = soundUseCase;
        }

        public override GameState state => GameState.Clear;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // ClearModalの表示
            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);
            await modalContainer.Push(ModalType.Clear.ToResourcePath(), true, modalId: ModalConfig.CLEAR_PATH);

            if (modalContainer.Modals.TryGetValue(ModalConfig.CLEAR_PATH, out var modal) &&
                modal is ClearModalView clearModalView)
            {
                // closeボタン押下待ち
                clearModalView.SetUp(x => _soundUseCase.PlaySe(x));
                await clearModalView.PushCloseAsync(token);
            }

            return GameState.None;
        }
    }
}