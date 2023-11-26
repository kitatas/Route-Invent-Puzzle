using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2023.Common
{
    public sealed class UniTaskHelper
    {
        public static async UniTask DelayAsync(float duration, CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
        }
    }
}