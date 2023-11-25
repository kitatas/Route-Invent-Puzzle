using System;
using System.Collections.Generic;
using GameOff2023.InGame.Data.DataStore;

namespace GameOff2023.InGame.Domain.Repository
{
    public sealed class StageRepository
    {
        private readonly CellData _cellData;
        private readonly PanelTable _panelTable;
        private readonly List<StageData> _stageData;

        public StageRepository(CellData cellData, PanelTable panelTable)
        {
            _cellData = cellData;
            _panelTable = panelTable;

            // TODO: ベタ書き修正
            _stageData = new List<StageData>
            {
                new StageData
                {
                    level = new Data.Entity.LevelEntity { value = 1 },
                    cells = new[]
                    {
                        new Data.Entity.CellEntity { type = (ObjectType)1, x = 2, y = 2 },
                        new Data.Entity.CellEntity { type = (ObjectType)2, x = 5, y = 7 },
                        new Data.Entity.CellEntity { type = (ObjectType)3, x = 1, y = 2 },
                        new Data.Entity.CellEntity { type = (ObjectType)4, x = 3, y = 3 },
                        new Data.Entity.CellEntity { type = (ObjectType)5, x = 4, y = 4 },
                        new Data.Entity.CellEntity { type = (ObjectType)6, x = 5, y = 5 },
                        new Data.Entity.CellEntity { type = (ObjectType)7, x = 6, y = 6 },
                        new Data.Entity.CellEntity { type = (ObjectType)8, x = 7, y = 7 },
                        new Data.Entity.CellEntity { type = (ObjectType)9, x = 1, y = 1 },
                        new Data.Entity.CellEntity { type = (ObjectType)10, x = 2, y = 3 },
                        new Data.Entity.CellEntity { type = (ObjectType)11, x = 3, y = 5 },
                    },
                    panels = new[]
                    {
                        new Data.Entity.PanelEntity { type = (PanelType)1, num = 3 },
                        new Data.Entity.PanelEntity { type = (PanelType)2, num = 2 },
                        new Data.Entity.PanelEntity { type = (PanelType)3, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)4, num = 1 },
                    },
                },
                new StageData
                {
                    level = new Data.Entity.LevelEntity { value = 2 },
                    cells = new[]
                    {
                        new Data.Entity.CellEntity { type = (ObjectType)1, x = 5, y = 7 },
                        new Data.Entity.CellEntity { type = (ObjectType)2, x = 2, y = 2 },
                    },
                    panels = new[]
                    {
                        new Data.Entity.PanelEntity { type = (PanelType)1, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)2, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)3, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)4, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)5, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)6, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)7, num = 1 },
                        new Data.Entity.PanelEntity { type = (PanelType)8, num = 1 },
                    },
                },
            };
        }

        public Presentation.View.CellView GetCell()
        {
            return _cellData.cell;
        }

        public PanelData FindPanelData(PanelType type)
        {
            var data = _panelTable.data.Find(x => x.type == type);
            if (data == null || data.view == null)
            {
                throw new Exception();
            }

            return data;
        }

        public List<StageData> stageData => _stageData;

        public StageData FindStageData(Data.Entity.LevelEntity levelEntity)
        {
            var data = stageData.Find(x => x.level.IsEqual(levelEntity));
            if (data == null)
            {
                throw new Exception();
            }

            return data;
        }
    }
}