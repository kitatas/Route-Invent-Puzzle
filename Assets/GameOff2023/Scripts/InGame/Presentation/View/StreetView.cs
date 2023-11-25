using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class StreetView : PanelView
    {
        [SerializeField] private ScaleType scaleType = default;
        [SerializeField] private Direction direction1 = default;
        [SerializeField] private Direction direction2 = default;

        public override void ExecAction(PlayerView player)
        {
        }

        protected override void TriggerEnterPlayer(PlayerView player)
        {
            if (player.direction.IsEnter(direction1) || 
                player.direction.IsEnter(direction2))
            {
                if (player.scaleType == scaleType) return;
                if (player.scaleType == ScaleType.Small && scaleType == ScaleType.Large) return;
            }

            player.SetDead();
        }
    }
}