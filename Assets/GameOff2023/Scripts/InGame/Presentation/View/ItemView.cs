using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class ItemView : StageObjectView
    {
        public bool isPicked { get; private set; } = false;

        public void SetUp()
        {
            isPicked = false;
            Show(StageObjectConfig.SHOW_TIME);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isPicked) return;

            if (other.TryGetComponent<PlayerView>(out var player))
            {
                isPicked = true;
                Hide(StageObjectConfig.HIDE_TIME);
                player.PlaySe(SeType.Item);
            }
        }
    }
}