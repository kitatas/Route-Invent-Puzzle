using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class MoveState : BaseState
    {
        private readonly PlayerView _playerView;

        public MoveState(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public override GameState state => GameState.Move;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            while (true)
            {
                var deltaTime = Time.deltaTime;
                _playerView.Tick(deltaTime);

                await UniTask.Yield(token);
            }

            return GameState.None;
        }
    }
}