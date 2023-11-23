using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class FieldView : MonoBehaviour
    {
        [SerializeField] private CellView cellView = default;

        private List<CellView> _fields;

        public void Init()
        {
            _fields = new List<CellView>();
        }

        public async UniTask BuildAsync(float duration, CancellationToken token)
        {
            for (int x = 1; x <= StageConfig.X; x++)
            {
                for (int y = 1; y <= StageConfig.Y; y++)
                {
                    var cell = Instantiate(cellView, transform);
                    cell.SetPosition(new Vector3(x, y, 0.0f));
                    cell.Show(duration);
                    _fields.Add(cell);
                }
            }

            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
        }
    }
}