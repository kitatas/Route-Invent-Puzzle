using GameOff2023.Base.Data.DataStore;
using UnityEngine;

namespace GameOff2023.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SeTable), menuName = "DataTable/" + nameof(SeTable))]
    public sealed class SeTable : BaseTable<SeData>
    {
    }
}