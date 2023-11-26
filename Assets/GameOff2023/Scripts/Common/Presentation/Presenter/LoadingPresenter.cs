using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common.Domain.UseCase;
using UniRx;
using UnityScreenNavigator.Runtime.Core.Modal;
using VContainer.Unity;

namespace GameOff2023.Common.Presentation.Presenter
{
    public sealed class LoadingPresenter : IStartable, IDisposable
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly CancellationTokenSource _tokenSource;

        public LoadingPresenter(LoadingUseCase loadingUseCase)
        {
            _loadingUseCase = loadingUseCase;
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            var modalContainer = ModalContainer.Find(ModalConfig.INGAME_CONTAINER);

            _loadingUseCase.property
                .SkipLatestValueOnSubscribe()
                .Subscribe(x =>
                {
                    if (x)
                    {
                        modalContainer.Push(ModalType.Loading.ToResourcePath(), true, modalId: "Loading");
                    }
                    else
                    {
                        modalContainer.Pop(true, destinationModalId: "Loading");
                    }
                })
                .AddTo(_tokenSource.Token);
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}