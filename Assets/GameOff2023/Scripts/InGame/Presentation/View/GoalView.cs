using MagicTween;
using UniEx;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class GoalView : StageObjectView
    {
        public void Init()
        {
            spriteRenderer.SetColorA(0.0f);
        }

        public bool IsGoal(PlayerView player)
        {
            return currentPosition.GetSqrLength(player.currentPosition) < StageConfig.JUDGE_DISTANCE;
        }

        public override Tween Hide(float duration)
        {
            return base.Hide(duration)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}