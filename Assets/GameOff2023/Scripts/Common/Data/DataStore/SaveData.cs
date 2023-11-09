namespace GameOff2023.Common.Data.DataStore
{
    public sealed class SaveData
    {
        public string uid;
        public float bgmVolume;
        public float seVolume;

        public static SaveData Create()
        {
            return new SaveData
            {
                uid = "",
                bgmVolume = SoundConfig.INIT_VOLUME,
                seVolume = SoundConfig.INIT_VOLUME,
            };
        }
    }
}