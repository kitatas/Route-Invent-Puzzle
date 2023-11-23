using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.InGame.Presentation.View;
using UnityScreenNavigator.Runtime.Core.Page;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class BackState : BaseState
    {
        private readonly StageView _stageView;

        public BackState(StageView stageView)
        {
            _stageView = stageView;
        }

        public override GameState state => GameState.Back;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _stageView.Hide();

            var pageContainer = PageContainer.Find(PageConfig.INGAME_CONTAINER);
            pageContainer.Push(PageConfig.SELECT_PATH, true, stack: false);

            await UniTask.Yield(token);

            return GameState.None;
        }
    }
}