using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using MagicTween;
using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class StockView : MonoBehaviour
    {
        [SerializeField] private CellView cellView = default;
        [SerializeField] private List<PanelView> panelViews = default;

        private List<CellView> _stocks;
        private List<PanelView> _panels;

        public void Init()
        {
            _stocks = new List<CellView>();
            _panels = new List<PanelView>();
        }

        public async UniTask BuildAsync(float duration, CancellationToken token)
        {
            for (int i = 0; i < 2; i++)
            {
                var x = 11.0f + i;
                for (int j = 0; j < 5; j++)
                {
                    var y = 7.0f - j;
                    var cell = Instantiate(cellView, transform);
                    cell.SetType(CellType.Stock);
                    cell.SetPosition(new Vector3(x, y, 0.0f));
                    cell.Show(duration);
                    _stocks.Add(cell);
                }
            }

            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
        }

        public void BuildPanel(int index, Data.Entity.PanelEntity panelEntity)
        {
            if (_stocks.TryGetValue(index, out var cell))
            {
                var panel = panelViews.Find(x => x.type == panelEntity.type);
                if (panel == null)
                {
                    throw new Exception();
                }

                var view = Instantiate(panel, transform);
                view.SetInitPosition(cell.currentPosition);
                _panels.Add(view);
            }
        }

        public void ExecPanel(Action<PanelView> action)
        {
            _panels.Each(x => action?.Invoke(x));
        }

        public void SetUpPanel(List<CellView> notFixedCells)
        {
            var placeable = notFixedCells.Concat(_stocks).ToList();
            ExecPanel(panel =>
            {
                panel.SetUp(placeable, FindPanelByPosition);
                panel.Show(StageObjectConfig.SHOW_TIME);
            });
        }

        public PanelView FindPanelByPosition((PanelView panel, Vector3 position) condition)
        {
            return _panels
                .Find(x => x != condition.panel && x.currentPosition == condition.position);
        }

        public void Hide(float duration)
        {
            foreach (var stock in _stocks)
            {
                stock.Hide(duration)
                    .OnComplete(() => Destroy(stock.gameObject));
            }

            foreach (var panel in _panels)
            {
                panel.Hide(duration)
                    .OnComplete(() => Destroy(panel.gameObject));
            }
        }
    }
}