using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Presentation.View;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class EditState : BaseState
    {
        private readonly EditCompButtonView _editCompButtonView;

        public EditState(EditCompButtonView editCompButtonView)
        {
            _editCompButtonView = editCompButtonView;
        }

        public override GameState state => GameState.Edit;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _editCompButtonView.PushAsync(token);
            
            return GameState.Move;
        }
    }
}