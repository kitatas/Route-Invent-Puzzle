using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class ItemView : StageObjectView
    {
        public bool isPicked { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerView>(out var player))
            {
                isPicked = true;
                Hide(StageObjectConfig.HIDE_TIME);
            }
        }
    }
}