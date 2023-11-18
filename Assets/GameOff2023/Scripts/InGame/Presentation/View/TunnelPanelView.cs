using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class TunnelPanelView : PanelView
    {
        [SerializeField] private Direction scaleUp = default;
        [SerializeField] private Direction scaleDown = default;

        private bool _isScale = false;

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
                    player.direction = scaleUp;
                    player.SetScaleType(ScaleType.Large);
                }
                else if (player.direction.IsEnter(scaleUp) && player.scaleType == ScaleType.Large)
                {
                    player.direction = scaleDown;
                    player.SetScaleType(ScaleType.Small);
                }
                else
                {
                    // TODO: game over
                }

                _isScale = true;
                this.Delay(1.0f, () => _isScale = false);
            }
        }
    }
}