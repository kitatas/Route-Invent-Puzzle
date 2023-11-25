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
        private readonly ResetButtonView _resetButtonView;
        private readonly PlayerView _playerView;
        private readonly StageView _stageView;

        public EditState(SoundUseCase soundUseCase, EditCompButtonView editCompButtonView,
            ResetButtonView resetButtonView, PlayerView playerView, StageView stageView)
        {
            _soundUseCase = soundUseCase;
            _editCompButtonView = editCompButtonView;
            _resetButtonView = resetButtonView;
            _playerView = playerView;
            _stageView = stageView;
        }

        public override GameState state => GameState.Edit;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _editCompButtonView.Init(x => _soundUseCase.PlaySe(x));
            _resetButtonView.Init(x => _soundUseCase.PlaySe(x), _stageView.ResetPanel);
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _editCompButtonView.Activate(true);
            _resetButtonView.Activate(true);
            _playerView.SetIsEdit(true);
            _stageView.ActivateEdit(true);
            await _editCompButtonView.PushAsync(token);

            _editCompButtonView.Activate(false);
            _resetButtonView.Activate(false);
            _playerView.SetIsEdit(false);
            _stageView.ActivateEdit(false);
            return GameState.Move;
        }
    }
}