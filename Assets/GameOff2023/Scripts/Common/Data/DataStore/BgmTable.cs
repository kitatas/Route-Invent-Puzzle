using GameOff2023.Base.Data.DataStore;
using UnityEngine;

namespace GameOff2023.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(BgmTable), menuName = "DataTable/" + nameof(BgmTable))]
    public sealed class BgmTable : BaseTable<BgmData>
    {
    }
}