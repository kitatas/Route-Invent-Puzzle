using GameOff2023.InGame.Data.Entity;

namespace GameOff2023.InGame.Data.DataStore
{
    public sealed class StageData
    {
        public LevelEntity level;
        public CellEntity[] cells;
        public PanelEntity[] panels;
    }
}