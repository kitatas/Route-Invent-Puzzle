using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class StageView : MonoBehaviour
    {
        [SerializeField] private FieldView fieldView = default;
        [SerializeField] private StockView stockView = default;

        public void Init()
        {
            fieldView.Init();
            stockView.Init();
        }

        public async UniTask BuildBaseAsync(CancellationToken token)
        {
            // Stageの基盤生成
            await (
                fieldView.BuildAsync(StageObjectConfig.SHOW_TIME, token),
                stockView.BuildAsync(StageObjectConfig.SHOW_TIME, token)
            );
        }

        public void BuildField(Data.Entity.CellEntity[] cellEntities, PlayerView player, GoalView goal)
        {
            foreach (var cellEntity in cellEntities)
            {
                fieldView.BuildField(cellEntity, player, goal);
            }
        }

        public void BuildPanel(Data.Entity.PanelEntity[] panelEntities)
        {
            var index = 0;
            foreach (var panelEntity in panelEntities)
            {
                for (int j = 0; j < panelEntity.num; j++)
                {
                    stockView.BuildPanel(index++, panelEntity);
                }
            }

            stockView.SetUpPanel(fieldView.notFixedCells);
        }

        public void ActivateEdit(bool value)
        {
            stockView.ExecPanel(panel => panel.SetIsEdit(value));
        }

        public void ResetPanel()
        {
            stockView.ExecPanel(panel => panel.ResetPosition());
        }

        public bool IsAllItemPicked()
        {
            return fieldView.IsAllItemPicked();
        }

        public void ExecPanelEffect(PlayerView playerView)
        {
            fieldView.ExecPanel(panel => panel.ExecAction(playerView));
            stockView.ExecPanel(panel => panel.ExecAction(playerView));
        }

        public void Hide(float duration)
        {
            fieldView.Hide(duration);
            stockView.Hide(duration);
        }
    }
}