using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class ClearView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem left = default;
        [SerializeField] private ParticleSystem right = default;

        public async UniTask PlayAsync(CancellationToken token)
        {
            left.Play();
            right.Play();

            await UniTaskHelper.DelayAsync(2.0f, token);
        }
    }
}