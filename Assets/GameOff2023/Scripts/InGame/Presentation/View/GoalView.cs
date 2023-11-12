using UniEx;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class GoalView : StageObjectView
    {
        public bool IsGoal(PlayerView player)
        {
            return currentPosition.GetSqrLength(player.currentPosition) < StageConfig.JUDGE_DISTANCE;
        }
    }
}