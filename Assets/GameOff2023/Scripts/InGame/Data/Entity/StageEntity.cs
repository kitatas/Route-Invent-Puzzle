using System;
using System.Collections.Generic;
using System.Linq;
using MagicTween;
using UniEx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameOff2023.InGame.Data.Entity
{
    public sealed class StageEntity
    {
        private readonly List<Presentation.View.CellView> _fields;
        private readonly List<Presentation.View.CellView> _stocks;
        private readonly List<Presentation.View.PanelView> _panels;

        public StageEntity()
        {
            _fields = new List<Presentation.View.CellView>();
            _stocks = new List<Presentation.View.CellView>();
            _panels = new List<Presentation.View.PanelView>();
        }

        public List<Presentation.View.CellView> notFixedCells =>
            _fields
                .Where(x => x.cellType != CellType.Fixed)
                .Concat(_stocks)
                .ToList();

        public void AddField(Presentation.View.CellView field)
        {
            _fields.Add(field);
        }

        public void AddStock(Presentation.View.CellView stock)
        {
            _stocks.Add(stock);
        }

        public void AddPanel(Presentation.View.PanelView panel)
        {
            _panels.Add(panel);
        }

        public Presentation.View.CellView FindFieldByPosition(Vector3 position)
        {
            return _fields.Find(x => x.currentPosition == position);
        }

        public Presentation.View.PanelView FindPanelByPosition(
            (Presentation.View.PanelView panel, Vector3 position) condition)
        {
            return _panels
                .Find(x => x != condition.panel && x.currentPosition == condition.position);
        }

        public void ExecEachPanel(Action<Presentation.View.PanelView> action)
        {
            _panels.Each(panel => action?.Invoke(panel));
        }

        public void ClearAll(float duration)
        {
            foreach (var field in _fields)
            {
                field.Hide(duration)
                    .OnComplete(() => Object.Destroy(field.gameObject));
            }

            foreach (var stock in _stocks)
            {
                stock.Hide(duration)
                    .OnComplete(() => Object.Destroy(stock.gameObject));
            }

            foreach (var panel in _panels)
            {
                panel.Hide(duration)
                    .OnComplete(() => Object.Destroy(panel.gameObject));
            }
        }
    }
}