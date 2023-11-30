using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class SendState : BaseState
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly UserProgressUseCase _userProgressUseCase;

        public SendState(LoadingUseCase loadingUseCase, UserProgressUseCase userProgressUseCase)
        {
            _loadingUseCase = loadingUseCase;
            _userProgressUseCase = userProgressUseCase;
        }

        public override GameState state => GameState.Send;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _loadingUseCase.SetAsync(true, token);
            await _userProgressUseCase.SendProgressAsync(token);
            await _loadingUseCase.SetAsync(false, token);

            return GameState.Clear;
        }
    }
}