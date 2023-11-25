using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class WallView : StageObjectView
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerView>(out var player))
            {
                player.SetDead();
            }
        }
    }
}