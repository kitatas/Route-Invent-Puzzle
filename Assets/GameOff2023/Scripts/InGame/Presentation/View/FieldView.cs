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
    public sealed class FieldView : MonoBehaviour
    {
        [SerializeField] private CellView cellView = default;
        [SerializeField] private WallView wallView = default;
        [SerializeField] private List<PanelView> panelViews = default;

        [SerializeField] private GoalView goalView = default;
        [SerializeField] private PlayerView playerView = default;

        private List<CellView> _fields;
        private List<WallView> _walls;
        private List<PanelView> _panels;

        public List<CellView> notFixedCells =>
            _fields
                .Where(x => x.cellType != CellType.Fixed)
                .ToList();

        public void Init()
        {
            _fields = new List<CellView>();
            _walls = new List<WallView>();
            _panels = new List<PanelView>();
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
                case ObjectType.Wall:
                    var wall = Instantiate(wallView, transform);
                    _walls.Add(wall);
                    stageObjectView = wall;
                    break;
                case ObjectType.CurveUpLeft:
                case ObjectType.CurveUpRight:
                case ObjectType.CurveDownLeft:
                case ObjectType.CurveDownRight:
                case ObjectType.TunnelUpUpDownDown:
                case ObjectType.TunnelUpDownDownUp:
                case ObjectType.TunnelUpLeftDownRight:
                case ObjectType.TunnelUpRightDownLeft:
                case ObjectType.StreetLargeVertical:
                case ObjectType.StreetLargeHorizontal:
                case ObjectType.StreetSmallVertical:
                case ObjectType.StreetSmallHorizontal:
                    var panelView = panelViews.Find(x => x.type == cellEntity.type.ToPanel());
                    if (panelView == null)
                    {
                        throw new Exception();
                    }

                    var panel = Instantiate(panelView, transform);
                    _panels.Add(panel);
                    stageObjectView = panel;
                    break;
                default:
                    throw new Exception();
            }

            stageObjectView.SetPosition(cellEntity.position);
            stageObjectView.Show(StageObjectConfig.SHOW_TIME);
        }

        public void ExecPanel(Action<PanelView> action)
        {
            _panels.Each(x => action?.Invoke(x));
        }

        public void Hide(float duration)
        {
            foreach (var field in _fields)
            {
                field.Hide(duration)
                    .OnComplete(() => Destroy(field.gameObject));
            }

            foreach (var wall in _walls)
            {
                wall.Hide(duration)
                    .OnComplete(() => Destroy(wall.gameObject));
            }

            foreach (var panel in _panels)
            {
                panel.Hide(duration)
                    .OnComplete(() => Destroy(panel.gameObject));
            }

            goalView.Hide(duration);
            playerView.Hide(duration);
        }
    }
}