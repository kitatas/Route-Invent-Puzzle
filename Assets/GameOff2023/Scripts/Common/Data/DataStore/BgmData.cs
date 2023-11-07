using UnityEngine;

namespace GameOff2023.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(BgmData), menuName = "DataTable/" + nameof(BgmData))]
    public sealed class BgmData : ScriptableObject
    {
        [SerializeField] private BgmType bgmType = default;
        [SerializeField] private AudioClip audioClip = default;

        public BgmType type => bgmType;
        public AudioClip clip => audioClip;
    }
}