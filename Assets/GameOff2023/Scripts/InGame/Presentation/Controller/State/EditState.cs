using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class EditState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly EditCompButtonView _editCompButtonView;
        private readonly PlayerView _playerView;

        public EditState(SoundUseCase soundUseCase, EditCompButtonView editCompButtonView, PlayerView playerView)
        {
            _soundUseCase = soundUseCase;
            _editCompButtonView = editCompButtonView;
            _playerView = playerView;
        }

        public override GameState state => GameState.Edit;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _editCompButtonView.Init(x => _soundUseCase.PlaySe(x));
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _playerView.SetIsEdit(true);
            await _editCompButtonView.PushAsync(token);

            _playerView.SetIsEdit(false);
            return GameState.Move;
        }
    }
}