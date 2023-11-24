using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.Controller;
using GameOff2023.InGame.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class GamePresenter : IStartable, IDisposable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly StateUseCase _stateUseCase;
        private readonly StateController _stateController;
        private readonly GamePageView _gamePageView;
        private CancellationTokenSource _tokenSource;

        public GamePresenter(SoundUseCase soundUseCase, StateUseCase stateUseCase, StateController stateController,
            GamePageView gamePageView)
        {
            _soundUseCase = soundUseCase;
            _stateUseCase = stateUseCase;
            _stateController = stateController;
            _gamePageView = gamePageView;
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _stateController.InitAsync(_tokenSource.Token).Forget();

            _stateUseCase.gameState
                .Subscribe(x => ExecAsync(x, _tokenSource.Token).Forget())
                .AddTo(_tokenSource.Token);

            _gamePageView.SetUp(x => _soundUseCase.PlaySe(x), () =>
            {
                _tokenSource?.Cancel();
                _tokenSource = new CancellationTokenSource();
                ExecAsync(GameState.Back, _tokenSource.Token).Forget();
            });
        }

        private async UniTask ExecAsync(GameState state, CancellationToken token)
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