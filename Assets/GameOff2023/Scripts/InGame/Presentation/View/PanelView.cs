using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class PanelView : StageObjectView, IDragHandler
    {
        private CameraView _cameraView;
        private Func<GameState, bool> _isState;

        public void SetUp(Func<GameState, bool> isState, Vector3 position)
        {
            _cameraView = FindObjectOfType<CameraView>();
            _isState = isState;
            SetPosition(position);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            var isEdit = _isState?.Invoke(GameState.Edit);
            if (isEdit.HasValue && isEdit.Value)
            {
                var position = _cameraView.GetWorldPoint(eventData.position);
                position.z = 0;
                SetPosition(position);
            }
        }
    }
}