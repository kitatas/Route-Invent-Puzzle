using System;
using GameOff2023.Common.Data.DataStore;

namespace GameOff2023.Common.Domain.Repository
{
    public sealed class SoundRepository
    {
        private readonly BgmTable _bgmTable;
        private readonly SeTable _seTable;

        public SoundRepository(BgmTable bgmTable, SeTable seTable)
        {
            _bgmTable = bgmTable;
            _seTable = seTable;
        }

        public BgmData FindBgm(BgmType type)
        {
            var data = _bgmTable.data.Find(x => x.type == type);
            if (data == null || data.clip == null)
            {
                // TODO: exception
                throw new Exception();
            }

            return data;
        }

        public SeData FindSe(SeType type)
        {
            var data = _seTable.data.Find(x => x.type == type);
            if (data == null || data.clip == null)
            {
                // TODO: exception
                throw new Exception();
            }

            return data;
        }
    }
}