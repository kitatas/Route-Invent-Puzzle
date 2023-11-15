using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Domain.UseCase;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class SetUpState : BaseState
    {
        private readonly StageUseCase _stageUseCase;

        public SetUpState(StageUseCase stageUseCase)
        {
            _stageUseCase = stageUseCase;
        }

        public override GameState state => GameState.SetUp;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _stageUseCase.Build();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return GameState.Edit;
        }
    }
}