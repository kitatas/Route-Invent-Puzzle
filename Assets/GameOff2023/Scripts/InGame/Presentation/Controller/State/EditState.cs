using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class EditState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly StageUseCase _stageUseCase;
        private readonly EditCompButtonView _editCompButtonView;
        private readonly ResetButtonView _resetButtonView;
        private readonly PlayerView _playerView;

        public EditState(SoundUseCase soundUseCase, StageUseCase stageUseCase, EditCompButtonView editCompButtonView,
            ResetButtonView resetButtonView, PlayerView playerView)
        {
            _soundUseCase = soundUseCase;
            _stageUseCase = stageUseCase;
            _editCompButtonView = editCompButtonView;
            _resetButtonView = resetButtonView;
            _playerView = playerView;
        }

        public override GameState state => GameState.Edit;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _editCompButtonView.Init(x => _soundUseCase.PlaySe(x));
            _resetButtonView.Init(x => _soundUseCase.PlaySe(x), _stageUseCase.ResetPanel);
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