using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class TopPresenter : IStartable, IDisposable
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly SoundUseCase _soundUseCase;
        private readonly StageUseCase _stageUseCase;
        private readonly TopPageView _topPageView;
        private readonly CancellationTokenSource _tokenSource;

        [Inject]
        public TopPresenter(LoadingUseCase loadingUseCase, SoundUseCase soundUseCase, StageUseCase stageUseCase,
            TopPageView topPageView)
        {
            _loadingUseCase = loadingUseCase;
            _soundUseCase = soundUseCase;
            _stageUseCase = stageUseCase;
            _topPageView = topPageView;
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            LoadAsync(_tokenSource.Token).Forget();
        }

        private async UniTask LoadAsync(CancellationToken token)
        {
            // await _loadingUseCase.SetAsync(true, token);
            await _stageUseCase.LoadStageAsync(token);
            // await _loadingUseCase.SetAsync(false, token);
            _topPageView.SetUp(x => _soundUseCase.PlaySe(x), PageConfig.SELECT_PATH);
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}