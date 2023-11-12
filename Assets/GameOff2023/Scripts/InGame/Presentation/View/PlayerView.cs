using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = default;

        public void Tick(float deltaTime)
        {
            var direction = Vector2.up;
            transform.Translate(deltaTime * moveSpeed * direction);
        }
    }
}