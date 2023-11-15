using System;
using GameOff2023.InGame.Domain.Repository;
using UniEx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameOff2023.InGame.Domain.UseCase
{
    public sealed class StageUseCase
    {
        private readonly Transform _stage;
        private readonly StageRepository _stageRepository;

        public StageUseCase(Transform stage, StageRepository stageRepository)
        {
            _stage = stage;
            _stageRepository = stageRepository;
        }

        public void Build()
        {
            for (int x = 1; x <= StageConfig.X; x++)
            {
                for (int y = 1; y <= StageConfig.Y; y++)
                {
                    var cell = Object.Instantiate(_stageRepository.GetCell(), _stage);
                    cell.SetPosition(new Vector3(x, y, 0.0f));
                }
            }

            var stageData = _stageRepository.FindStageData();
            stageData.cells.Each(cell =>
            {
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
        }
    }
}