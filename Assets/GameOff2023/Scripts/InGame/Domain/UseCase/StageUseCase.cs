using System;
using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.Repository;
using UniEx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StageUseCase
    {
        private readonly StageEntity _stageEntity;
        private readonly StateEntity _stateEntity;
        private readonly StageRepository _stageRepository;

        public StageUseCase(StageEntity stageEntity, StateEntity stateEntity, StageRepository stageRepository)
        {
            _stageEntity = stageEntity;
            _stateEntity = stateEntity;
            _stageRepository = stageRepository;
        }

        public void Build()
        {
            for (int x = 1; x <= StageConfig.X; x++)
            {
                for (int y = 1; y <= StageConfig.Y; y++)
                {
                    var cell = Object.Instantiate(_stageRepository.GetCell());
                    cell.SetPosition(new Vector3(x, y, 0.0f));
                    _stageEntity.AddField(cell);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                var x = 12.0f + 1.5f * i;
                for (int j = 0; j < 5; j++)
                {
                    var y = 7.0f - j;
                    var cell = Object.Instantiate(_stageRepository.GetCell());
                    cell.SetPosition(new Vector3(x, y, 0.0f));
                    _stageEntity.AddStock(cell);

                    cell.SetType(CellType.Stock);
                }
            }

            var stageData = _stageRepository.FindStageData(new LevelEntity { value = 1 });
            stageData.cells.Each(cell =>
            {
                // 座標が一致するcellは固定マス扱い
                _stageEntity.FindFieldByPosition(cell.position)?.SetType(CellType.Fixed);

                switch (cell.type)
                {
                    case ObjectType.Player:
                        Object.FindObjectOfType<Presentation.View.PlayerView>().SetPosition(cell.position);
                        break;
                    case ObjectType.Goal:
                        Object.FindObjectOfType<Presentation.View.GoalView>().SetPosition(cell.position);
                        break;
                    // TODO: 他objectはtableからprefab生成する
                    default:
                        throw new Exception();
                }
            });

            var count = 0;
            stageData.panels.Each(panel =>
            {
                for (int i = 0; i < panel.num; i++)
                {
                    count++;
                    var data = _stageRepository.FindPanelData(panel.type);
                    var view = Object.Instantiate(data.view);
                    var x = count.IsEven() ? 13.5f : 12.0f;
                    var y = 8.0f - Mathf.CeilToInt(count / 2.0f);
                    view.SetUp(_stageEntity.notFixedCells, _stageEntity.FindPanelByPosition, _stateEntity.IsState,
                        new Vector3(x, y, 0.0f));

                    _stageEntity.AddPanel(view);
                }
            });
        }

        public void ExecPanelEffect(Presentation.View.PlayerView player)
        {
            _stageEntity.ExecEachPanel(panel => panel.ExecAction(player));
        }
    }
}