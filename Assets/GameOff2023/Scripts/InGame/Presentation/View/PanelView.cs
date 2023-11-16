using System;
using System.Collections.Generic;
using System.Linq;
using UniEx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class PanelView : StageObjectView, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private CameraView _cameraView;
        private Func<GameState, bool> _isState;
        private List<CellView> _cellViews;
        private Vector3 _startPosition;

        public void SetUp(Func<GameState, bool> isState, Vector3 position)
        {
            _cameraView = FindObjectOfType<CameraView>();
            _isState = isState;
            _cellViews = FindObjectsOfType<CellView>().ToList();
            SetPosition(position);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            var isEdit = _isState?.Invoke(GameState.Edit);
            if (isEdit.HasValue && isEdit.Value)
            {
                var position = _cameraView.GetWorldPoint(eventData.position);
                position.z = -1.0f;
                SetPosition(position);

                // 最も近い座標のcellの色を変更する
                var x = Mathf.RoundToInt(currentPosition.x);
                var y = Mathf.RoundToInt(currentPosition.y);
                _cellViews.Each(cell =>
                {
                    var color = cell.IsEqualPosition(x, y) ? CellConfig.PLACEABLE_COLOR : CellConfig.DEFAULT_COLOR;
                    cell.SetColor(color);
                });
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _startPosition = currentPosition;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            var x = Mathf.RoundToInt(currentPosition.x);
            var y = Mathf.RoundToInt(currentPosition.y);
            var cell = _cellViews.Find(cell => cell.IsEqualPosition(x, y));
            if (cell)
            {
                // 配置可能であれば配置し、cellの色を戻す
                cell.SetColor(CellConfig.DEFAULT_COLOR);
                SetPosition(new Vector3(x, y));
            }
            else
            {
                // 配置不可であれば取得位置に戻す
                SetPosition(_startPosition);
            }
        }
    }
}