using System.Threading;
using Cysharp.Threading.Tasks;
using MagicTween;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class PlayerView : StageObjectView
    {
        [SerializeField] private float moveSpeed = default;

        [HideInInspector] public Direction direction = default;

        public void SetUp()
        {
            direction = Direction.Up;
        }

        public void Tick(float deltaTime)
        {
            transform.Translate(deltaTime * moveSpeed * direction.ToVector2());
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