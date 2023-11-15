using UnityEngine;

namespace GameOff2023.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(CellData), menuName = "DataTable/" + nameof(CellData))]
    public sealed class CellData : ScriptableObject
    {
        [SerializeField] private Presentation.View.CellView cellView = default;
        public Presentation.View.CellView cell => cellView;
    }
}