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

        public async UniTask BuildAsync(CancellationToken token)
        {
            // Stageの基盤生成
            await (
                fieldView.BuildAsync(StageObjectConfig.SHOW_TIME, token),
                stockView.BuildAsync(StageObjectConfig.SHOW_TIME, token)
            );
        }
    }
}