using GameOff2023.Base.Data.DataStore;
using UnityEngine;

namespace GameOff2023.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(PanelTable), menuName = "DataTable/" + nameof(PanelTable))]
    public sealed class PanelTable : BaseTable<PanelData>
    {
    }
}