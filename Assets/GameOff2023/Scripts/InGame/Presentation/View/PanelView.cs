using System;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class PanelView : StageObjectView, IDragHandler
    {
        private CameraView _cameraView;

        private void Start()
        {
            _cameraView = FindObjectOfType<CameraView>();
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            var position = _cameraView.GetWorldPoint(eventData.position);
            position.z = 0;
            SetPosition(position);
        }
    }
}