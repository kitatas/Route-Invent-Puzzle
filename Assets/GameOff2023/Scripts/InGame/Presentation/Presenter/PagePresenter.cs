using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.InGame.Domain.UseCase;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class PagePresenter : IStartable, IDisposable
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly StageUseCase _stageUseCase;
        private readonly CancellationTokenSource _tokenSource;

        public PagePresenter(LoadingUseCase loadingUseCase, StageUseCase stageUseCase)
        {
            _loadingUseCase = loadingUseCase;
            _stageUseCase = stageUseCase;
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            InitAsync(_tokenSource.Token).Forget();
        }

        private async UniTask InitAsync(CancellationToken token)
        {
            // Stage情報を取得してからTopを表示する
            await _loadingUseCase.SetAsync(true, token);
            await _stageUseCase.LoadStageAsync(token);
            await _loadingUseCase.SetAsync(false, token);

            var pageContainer = PageContainer.Find(PageConfig.INGAME_CONTAINER);
            await pageContainer.Push(PageConfig.TOP_PATH, true, stack: false);
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}