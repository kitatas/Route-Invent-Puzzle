using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2023.InGame.Presentation.Controller
{
    public sealed class StateController
    {
        private readonly List<BaseState> _states;

        public StateController(IEnumerable<BaseState> states)
        {
            _states = states.ToList();
        }

        public async UniTaskVoid InitAsync(CancellationToken token)
        {
            foreach (var state in _states)
            {
                state.InitAsync(token).Forget();
            }

            await UniTask.Yield(token);
        }

        public async UniTask<GameState> TickAsync(GameState state, CancellationToken token)
        {
            var currentState = _states.Find(x => x.state == state);
            if (currentState == null)
            {
                // TODO: ExceptionConfig
                throw new Exception();
            }

            return await currentState.TickAsync(token);
        }
    }
}