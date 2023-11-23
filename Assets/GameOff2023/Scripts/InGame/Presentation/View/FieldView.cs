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
        [SerializeField] private GoalView goalView = default;
        [SerializeField] private PlayerView playerView = default;

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

        public void BuildField(Data.Entity.CellEntity cellEntity)
        {
            var cell = _fields.Find(x => x.currentPosition == cellEntity.position);
            if (cell == null)
            {
                throw new Exception();
            }

            cell.SetType(CellType.Fixed);

            StageObjectView stageObjectView;
            switch (cellEntity.type)
            {
                case ObjectType.Player:
                    playerView.SetStartPosition(cellEntity.position);
                    stageObjectView = playerView;
                    break;
                case ObjectType.Goal:
                    stageObjectView = goalView;
                    break;
                default:
                    throw new Exception();
            }

            stageObjectView.SetPosition(cellEntity.position);
            stageObjectView.Show(StageObjectConfig.SHOW_TIME);
        }
    }
}