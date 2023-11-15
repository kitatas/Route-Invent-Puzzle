using UnityEngine;

namespace GameOff2023.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(PanelData), menuName = "DataTable/" + nameof(PanelData))]
    public sealed class PanelData : ScriptableObject
    {
        [SerializeField] private PanelType panelType = default;
        [SerializeField] private Presentation.View.PanelView panelView = default;

        public PanelType type => panelType;
        public Presentation.View.PanelView view => panelView;
    }
}