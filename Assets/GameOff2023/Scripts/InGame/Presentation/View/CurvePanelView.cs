using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class CurvePanelView : PanelView
    {
        [SerializeField] private Direction direction1 = default;
        [SerializeField] private Direction direction2 = default;

        private bool _isCurving = false;

        public override void ExecAction(PlayerView player)
        {
            if (currentPosition.GetSqrLength(player.currentPosition) < StageConfig.JUDGE_DISTANCE)
            {
                if (_isCurving)
                {
                    return;
                }

                if (player.direction.IsEnter(direction1))
                {
                    player.SetDirection(direction2);
                    player.SetPosition(transform.position);
                }
                else if (player.direction.IsEnter(direction2))
                {
                    player.SetDirection(direction1);
                    player.SetPosition(transform.position);
                }
                else
                {
                    player.SetDead();
                    return;
                }

                _isCurving = true;
            }
            else
            {
                _isCurving = false;
            }
        }

        protected override void TriggerEnterPlayer(PlayerView player)
        {
            if (player.direction.IsEnter(direction1)) return;
            if (player.direction.IsEnter(direction2)) return;
            player.SetDead();
        }
    }
}