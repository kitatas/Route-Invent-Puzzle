using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MagicTween;
using UniRx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class PlayerView : StageObjectView
    {
        [SerializeField] private float moveSpeed = default;

        [HideInInspector] public Direction direction = default;
        public ScaleType scaleType => _scaleType.Value;

        private ReactiveProperty<ScaleType> _scaleType;

        private void Awake()
        {
            _scaleType = new ReactiveProperty<ScaleType>(ScaleType.Large);
            _scaleType
                .Subscribe(x =>
                {
                    transform
                        .TweenLocalScale(x.ToScale(), PlayerConfig.ADJUST_TIME)
                        .SetEase(Ease.Linear)
                        .SetLink(gameObject);
                })
                .AddTo(this);
        }

        public void SetUp()
        {
            direction = Direction.Up;
            SetScaleType(ScaleType.Large);
        }

        public void Tick(float deltaTime)
        {
            transform.Translate(deltaTime * moveSpeed * direction.ToVector2());
        }

        public void SetScaleType(ScaleType type)
        {
            _scaleType.Value = type;
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