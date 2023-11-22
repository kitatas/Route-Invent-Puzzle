using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class FailModalView : BaseModalView
    {
        [SerializeField] private BaseButtonView backButtonView = default;

        public override void SetUp(Action<SeType> playSe)
        {
            base.SetUp(playSe);

            backButtonView.Init(playSe);
            backButtonView.AddPushEvent(() =>
            {
                // モーダルの非表示
                modalContainer.Pop(true);
            });
        }

        public async UniTask<FailNextType> PushCloseAsync(CancellationToken token)
        {
            var index = await UniTask.WhenAny(
                closeButtonView.PushAsync(token),
                backButtonView.PushAsync(token)
            );

            return index == 0
                ? FailNextType.Retry
                : FailNextType.Retire;
        }
    }
}