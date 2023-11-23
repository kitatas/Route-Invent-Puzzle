using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class StockView : MonoBehaviour
    {
        [SerializeField] private CellView cellView = default;

        private List<CellView> _stocks;

        public void Init()
        {
            _stocks = new List<CellView>();
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
    }
}