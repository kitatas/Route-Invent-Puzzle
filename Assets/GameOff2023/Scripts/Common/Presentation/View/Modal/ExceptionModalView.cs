using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Base.Presentation.View;
using TMPro;
using UnityEngine;

namespace GameOff2023.Common.Presentation.View
{
    public sealed class ExceptionModalView : BaseModalView
    {
        [SerializeField] private TextMeshProUGUI exceptionMessage = default;

        public async UniTask SetMessageAndCloseAsync(string message, CancellationToken token)
        {
            exceptionMessage.text = $"{message}";

            await closeButtonView.PushAsync(token);
        }
    }
}