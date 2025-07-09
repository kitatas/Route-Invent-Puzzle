using System;
using System.Collections.Generic;
using DG.Tweening;
using GameOff2023.Common;
using UniEx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameOff2023.InGame.Presentation.View
{
    public abstract class PanelView : StageObjectView, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private PanelType panelType = default;
        
        private CameraView _cameraView;
        private List<CellView> _cellViews;
        private Func<(PanelView, Vector3), PanelView> _findPanel;
        private Action<SeType> _playSe;
        private bool _isEdit;
        private Vector3 _initPosition;
        private Vector3 _startPosition;

        public PanelType type => panelType;

        public void SetUp(List<CellView> cellViews, Func<(PanelView, Vector3), PanelView> findPanel)
        {
            _cameraView = FindAnyObjectByType<CameraView>();
            _cellViews = cellViews;
            _findPanel = findPanel;

            ResetPosition();
        }

        public void SetInitPosition(Vector3 position)
        {
            _initPosition = position;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void ResetPosition()
        {
            SetPosition(_initPosition);
        }

        public void SetPlaySe(Action<SeType> playSe)
        {
            _playSe = playSe;
        }

        public void SetIsEdit(bool value)
        {
            _isEdit = value;
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (_isEdit == false) return;

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

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (_isEdit == false) return;
            spriteRenderer.sortingLayerName = "Hands";
            _playSe?.Invoke(SeType.Hand);

            _startPosition = currentPosition;

            transform
                .DOScale(Vector3.one * PanelConfig.SCALE_UP_RATE, PanelConfig.ADJUST_TIME)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (_isEdit == false) return;
            spriteRenderer.sortingLayerName = "Panel";
            _playSe?.Invoke(SeType.Hand);

            var cell = _cellViews.Find(cell => cell.IsEqualPosition(currentXToInt, currentYToInt));
            if (cell)
            {
                // Panelを配置済みであれば入れ替え
                var nextPosition = new Vector3(currentXToInt, currentYToInt);
                var panel = _findPanel?.Invoke((this, nextPosition));
                if (panel)
                {
                    panel.SetPosition(_startPosition, PanelConfig.ADJUST_TIME);
                }

                // 配置可能であれば配置し、cellの色を戻す
                cell.SetColor(CellConfig.DEFAULT_COLOR);
                SetPosition(nextPosition);
            }
            else
            {
                // 配置不可であれば取得位置に戻す
                SetPosition(_startPosition, PanelConfig.ADJUST_TIME);
            }

            transform
                .DOScale(Vector3.one * StageObjectConfig.SHOW_SCALE_RATE, PanelConfig.ADJUST_TIME)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isEdit) return;

            if (other.TryGetComponent<PlayerView>(out var player))
            {
                TriggerEnterPlayer(player);
            }
        }

        public abstract void ExecAction(PlayerView player);

        protected abstract void TriggerEnterPlayer(PlayerView player);
    }
}