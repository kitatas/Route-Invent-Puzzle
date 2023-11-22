using System.Threading;
using Cysharp.Threading.Tasks;
using MagicTween;
using UniEx;
using UniRx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class PlayerView : StageObjectView
    {
        [SerializeField] private float moveSpeed = default;

        [HideInInspector] public Direction direction = default;
        public ScaleType scaleType => _scaleType.Value;
        public bool isDead => _isDead.Value;

        private ReactiveProperty<ScaleType> _scaleType;
        private ReactiveProperty<bool> _isDead;
        private Vector3 _hidePosition;

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

            _isDead = new ReactiveProperty<bool>(false);
            _isDead
                .Where(x => x)
                .Subscribe(_ =>
                {
                    // TODO: 演出追加
                    Hide(StageObjectConfig.HIDE_TIME);
                })
                .AddTo(this);
        }

        public void Init()
        {
            direction = Direction.Up;
            SetScaleType(ScaleType.Large);
            spriteRenderer.SetColorA(0.0f);
            _isDead.Value = false;
            _hidePosition = currentPosition;
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

        public void SetDead()
        {
            _isDead.Value = true;
        }

        public override Tween Hide(float duration)
        {
            return base.Hide(duration)
                .OnComplete(() => SetPosition(_hidePosition));
        }
    }
}