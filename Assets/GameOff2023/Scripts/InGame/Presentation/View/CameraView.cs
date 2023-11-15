using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class CameraView : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera = default;

        public Vector3 GetWorldPoint(Vector3 cursorPosition)
        {
            return mainCamera.ScreenToWorldPoint(cursorPosition);
        }
    }
}