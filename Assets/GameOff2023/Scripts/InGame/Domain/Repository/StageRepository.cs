using System;
using GameOff2023.InGame.Data.DataStore;

namespace GameOff2023.InGame.Domain.Repository
{
    public sealed class StageRepository
    {
        private readonly CellData _cellData;
        private readonly PanelTable _panelTable;

        public StageRepository(CellData cellData, PanelTable panelTable)
        {
            _cellData = cellData;
            _panelTable = panelTable;
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

        public StageData FindStageData()
        {
            // TODO: ベタ書き修正
            return new StageData
            {
                cells = new[]
                {
                    new Data.Entity.CellEntity { type = (ObjectType)1, x = 2, y = 2 },
                    new Data.Entity.CellEntity { type = (ObjectType)2, x = 5, y = 7 },
                },
                panels = new[]
                {
                    new Data.Entity.PanelEntity { type = (PanelType)1, num = 2 },
                    new Data.Entity.PanelEntity { type = (PanelType)2, num = 2 },
                    new Data.Entity.PanelEntity { type = (PanelType)3, num = 1 },
                    new Data.Entity.PanelEntity { type = (PanelType)4, num = 1 },
                },
            };
        }
    }
}