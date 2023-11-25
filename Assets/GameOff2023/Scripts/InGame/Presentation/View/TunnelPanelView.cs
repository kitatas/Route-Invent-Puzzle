using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class TunnelPanelView : PanelView
    {
        [SerializeField] private PanelType panelType = default;
        [SerializeField] private Direction scaleUp = default;
        [SerializeField] private Direction scaleDown = default;

        private bool _isScale = false;

        public override PanelType type => panelType;

        public override void ExecAction(PlayerView player)
        {
            if (_isScale)
            {
                return;
            }

            if (currentPosition.GetSqrLength(player.currentPosition) < StageConfig.JUDGE_DISTANCE)
            {
                if (player.direction.IsEnter(scaleDown) && player.scaleType == ScaleType.Small)
                {
                    player.SetDirection(scaleUp);
                    player.SetPosition(transform.position);
                    player.SetScaleType(ScaleType.Large);
                }
                else if (player.direction.IsEnter(scaleUp) && player.scaleType == ScaleType.Large)
                {
                    player.SetDirection(scaleDown);
                    player.SetPosition(transform.position);
                    player.SetScaleType(ScaleType.Small);
                }
                else
                {
                    player.SetDead();
                    return;
                }

                _isScale = true;
                this.Delay(1.0f, () => _isScale = false);
            }
        }

        protected override void TriggerEnterPlayer(PlayerView player)
        {
            if (player.direction.IsEnter(scaleDown) && player.scaleType == ScaleType.Large)
            {
                player.SetDead();
            }
        }
    }
}