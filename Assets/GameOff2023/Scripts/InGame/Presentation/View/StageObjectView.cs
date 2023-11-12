using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class StageObjectView : MonoBehaviour
    {
        public Vector3 currentPosition => transform.position;

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}