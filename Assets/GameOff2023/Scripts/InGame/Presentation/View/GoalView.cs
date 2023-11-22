using MagicTween;
using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class GoalView : StageObjectView
    {
        private Vector3 _hidePosition;

        private void Awake()
        {
            _hidePosition = currentPosition;
        }

        public bool IsGoal(PlayerView player)
        {
            return currentPosition.GetSqrLength(player.currentPosition) < StageConfig.JUDGE_DISTANCE;
        }

        public override Tween Hide(float duration)
        {
            return base.Hide(duration)
                .OnComplete(() => SetPosition(_hidePosition));
        }
    }
}