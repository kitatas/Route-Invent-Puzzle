using System;
using GameOff2023.Common.Data.DataStore;

namespace GameOff2023.Common.Domain.Repository
{
    public sealed class SoundRepository
    {
        private readonly BgmTable _bgmTable;

        public SoundRepository(BgmTable bgmTable)
        {
            _bgmTable = bgmTable;
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
    }
}