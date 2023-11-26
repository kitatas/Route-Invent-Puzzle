using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Boot.Domain.UseCase;
using GameOff2023.Boot.Presentation.Controller;
using UniRx;
using VContainer.Unity;

namespace GameOff2023.Boot.Presentation.Presenter
{
    public sealed class BootPresenter : IStartable, IDisposable
    {
        private readonly StateUseCase _stateUseCase;
        private readonly StateController _stateController;
        private CancellationTokenSource _tokenSource;

        public BootPresenter(StateUseCase stateUseCase, StateController stateController)
        {
            _stateUseCase = stateUseCase;
            _stateController = stateController;
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _stateController.InitAsync(_tokenSource.Token).Forget();

            _stateUseCase.bootState
                .Subscribe(x => ExecAsync(x, _tokenSource.Token).Forget())
                .AddTo(_tokenSource.Token);
        }

        private async UniTask ExecAsync(BootState state, CancellationToken token)
        {
            try
            {
                var nextState = await _stateController.TickAsync(state, token);
                _stateUseCase.Set(nextState);
            }
            catch (Exception e)
            {
                // TODO: Retry
                throw;
            }
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}