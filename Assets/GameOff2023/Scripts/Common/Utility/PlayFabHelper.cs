using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using PlayFab;

namespace GameOff2023.Common
{
    public sealed class PlayFabHelper
    {
        public static async UniTask<TResponse> CallApiAsync<TRequest, TResponse>(
            TRequest request,
            Action<TRequest, Action<TResponse>, Action<PlayFabError>, object, Dictionary<string, string>> playFabApi,
            Func<PlayFabError, Exception> errorException,
            Exception responseException,
            CancellationToken token)
        {
            var completionSource = new UniTaskCompletionSource<TResponse>();
            playFabApi(
                request,
                result => completionSource.TrySetResult(result),
                error => completionSource.TrySetException(errorException?.Invoke(error)),
                null,
                null);

            var response = await completionSource.Task;
            if (response == null)
            {
                throw responseException;
            }

            return response;
        }
    }
}