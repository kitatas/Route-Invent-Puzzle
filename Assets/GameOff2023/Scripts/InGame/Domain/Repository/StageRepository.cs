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
    }
}