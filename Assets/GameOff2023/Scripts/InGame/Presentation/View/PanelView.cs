using System;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class PanelView : StageObjectView, IDragHandler
    {
        public virtual void OnDrag(PointerEventData eventData)
        {
        }
    }
}