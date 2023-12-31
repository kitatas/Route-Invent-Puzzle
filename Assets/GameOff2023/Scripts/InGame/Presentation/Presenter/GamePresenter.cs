using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.Common.Presentation.Controller;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.Controller;
using GameOff2023.InGame.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class GamePresenter : IPostStartable, IDisposable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly StateUseCase _stateUseCase;
        private readonly StateController _stateController;
        private readonly ExceptionController _exceptionController;
        private readonly GamePageView _gamePageView;
        private CancellationTokenSource _tokenSource;

        public GamePresenter(SoundUseCase soundUseCase, StateUseCase stateUseCase, StateController stateController,
            ExceptionController exceptionController, GamePageView gamePageView)
        {
            _soundUseCase = soundUseCase;
            _stateUseCase = stateUseCase;
            _stateController = stateController;
            _exceptionController = exceptionController;
            _gamePageView = gamePageView;
            _tokenSource = new CancellationTokenSource();
        }

        public void PostStart()
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
                var type = await _exceptionController.ShowAsync(e, token);
                if (type == ExceptionType.Retry)
                {
                    await ExecAsync(state, token);
                }

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