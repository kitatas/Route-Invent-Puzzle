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

        public void BuildField(Data.Entity.CellEntity[] cellEntities)
        {
            foreach (var cellEntity in cellEntities)
            {
                fieldView.BuildField(cellEntity);
            }
        }

        public void BuildPanel(Data.Entity.PanelEntity[] panelEntities)
        {
            for (int i = 0; i < panelEntities.Length; i++)
            {
                stockView.BuildPanel(i, panelEntities[i]);
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

        public void ExecPanelEffect(PlayerView playerView)
        {
            stockView.ExecPanel(panel => panel.ExecAction(playerView));
        }

        public void Hide()
        {
            fieldView.Hide(StageObjectConfig.HIDE_TIME);
            stockView.Hide(StageObjectConfig.HIDE_TIME);
        }
    }
}