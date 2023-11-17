using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameOff2023.InGame.Data.Entity
{
    public sealed class StageEntity
    {
        private readonly List<Presentation.View.CellView> _fields;
        private readonly List<Presentation.View.CellView> _stocks;

        public StageEntity()
        {
            _fields = new List<Presentation.View.CellView>();
            _stocks = new List<Presentation.View.CellView>();
        }

        public List<Presentation.View.CellView> notFixedCells =>
            _fields
                .Where(x => x.cellType != CellType.Fixed)
                .Concat(_stocks)
                .ToList();

        public void AddField(Presentation.View.CellView field)
        {
            _fields.Add(field);
        }

        public void AddStock(Presentation.View.CellView stock)
        {
            _stocks.Add(stock);
        }

        public Presentation.View.CellView FindFieldByPosition(Vector3 position)
        {
            return _fields.Find(x => x.currentPosition == position);
        }
    }
}