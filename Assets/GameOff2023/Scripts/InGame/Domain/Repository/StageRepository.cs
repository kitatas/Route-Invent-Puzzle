using GameOff2023.InGame.Data.DataStore;

namespace GameOff2023.InGame.Domain.Repository
{
    public sealed class StageRepository
    {
        private readonly CellData _cellData;

        public StageRepository(CellData cellData)
        {
            _cellData = cellData;
        }

        public Presentation.View.CellView GetCell()
        {
            return _cellData.cell;
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
            };
        }
    }
}