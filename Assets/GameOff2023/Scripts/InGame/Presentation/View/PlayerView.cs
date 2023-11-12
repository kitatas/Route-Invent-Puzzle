using System.Threading;
using Cysharp.Threading.Tasks;
using MagicTween;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class PlayerView : StageObjectView
    {
        [SerializeField] private float moveSpeed = default;

        public void Tick(float deltaTime)
        {
            var direction = Vector2.up;
            transform.Translate(deltaTime * moveSpeed * direction);
        }

        public async UniTask TweenPositionAsync(Vector3 target, CancellationToken token)
        {
            await transform
                .TweenPosition(target, PlayerConfig.ADJUST_TIME)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .WithCancellation(token);
        }
    }
}