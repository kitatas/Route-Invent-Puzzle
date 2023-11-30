using System.Threading;
using Cysharp.Threading.Tasks;
using MagicTween;
using UniEx;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class PlayerView : StageObjectView, IPointerDownHandler
    {
        [SerializeField] private float moveSpeed = default;

        public Direction direction => _direction.Value;
        public ScaleType scaleType => _scaleType.Value;
        public bool isDead => _isDead.Value;

        private ReactiveProperty<Direction> _direction;
        private ReactiveProperty<ScaleType> _scaleType;
        private ReactiveProperty<bool> _isDead;
        private Vector3 _startPosition;
        private bool _isEdit;
        private int _directionIndex;

        protected override void Awake()
        {
            base.Awake();
            _direction = new ReactiveProperty<Direction>(Direction.Up);
            _direction
                .Subscribe(x =>
                {
                    spriteRenderer.transform
                        .TweenLocalRotation(x.ToQuaternion(), PlayerConfig.ADJUST_TIME)
                        .SetEase(Ease.Linear)
                        .SetLink(gameObject);
                })
                .AddTo(this);

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

            _directionIndex = 0;
        }

        public void SetUp()
        {
            SetDirection(PlayerConfig.DIRECTIONS[_directionIndex]);
            SetScaleType(ScaleType.Large);
            Show(StageObjectConfig.SHOW_TIME);
            _isDead.Value = false;
            SetPosition(_startPosition);
        }

        public void Tick(float deltaTime)
        {
            transform.Translate(deltaTime * moveSpeed * direction.ToVector2());
        }

        public void SetStartPosition(Vector3 position)
        {
            _startPosition = position;
        }

        public void SetIsEdit(bool value)
        {
            _isEdit = value;
        }

        public void SetDirection(Direction value)
        {
            _direction.Value = value;
        }

        public void SetScaleType(ScaleType type)
        {
            _scaleType.Value = type;
        }

        public void SetDead()
        {
            _isDead.Value = true;
        }

        public async UniTask TweenPositionAsync(Vector3 target, CancellationToken token)
        {
            await transform
                .TweenPosition(target, PlayerConfig.ADJUST_TIME)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .WithCancellation(token);
        }

        public Tween Hide(float duration, bool isDestroy = false)
        {
            return base.Hide(duration)
                .OnComplete(() =>
                {
                    if (isDestroy)
                    {
                        Destroy(gameObject);
                    }
                });
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isEdit == false) return;

            _directionIndex.RepeatIncrement(0, PlayerConfig.DIRECTIONS.GetLastIndex());
            SetDirection(PlayerConfig.DIRECTIONS[_directionIndex]);
        }
    }
}