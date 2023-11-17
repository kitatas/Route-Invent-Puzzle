using System;
using System.Collections.Generic;
using UniEx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class PanelView : StageObjectView, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private CameraView _cameraView;
        private List<CellView> _cellViews;
        private Func<(PanelView, Vector3), PanelView> _findPanel;
        private Func<GameState, bool> _isState;
        private Vector3 _startPosition;

        public void SetUp(List<CellView> cellViews, Func<(PanelView, Vector3), PanelView> findPanel,
            Func<GameState, bool> isState, Vector3 position)
        {
            _cameraView = FindObjectOfType<CameraView>();
            _cellViews = cellViews;
            _findPanel = findPanel;
            _isState = isState;

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
                _cellViews.Each(cell =>
                {
                    var color = cell.IsEqualPosition(currentXToInt, currentYToInt)
                        ? CellConfig.PLACEABLE_COLOR
                        : CellConfig.DEFAULT_COLOR;
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
            var cell = _cellViews.Find(cell => cell.IsEqualPosition(currentXToInt, currentYToInt));
            if (cell)
            {
                // Panelを配置済みであれば入れ替え
                var nextPosition = new Vector3(currentXToInt, currentYToInt);
                var panel = _findPanel?.Invoke((this, nextPosition));
                if (panel)
                {
                    panel.SetPosition(_startPosition);
                }

                // 配置可能であれば配置し、cellの色を戻す
                cell.SetColor(CellConfig.DEFAULT_COLOR);
                SetPosition(nextPosition);
            }
            else
            {
                // 配置不可であれば取得位置に戻す
                SetPosition(_startPosition);
            }
        }
    }
}