using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Base.Presentation.View;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class ClearModalView : BaseModalView
    {
        public async UniTask PushCloseAsync(CancellationToken token)
        {
            await closeButtonView.PushAsync(token);
        }
    }
}