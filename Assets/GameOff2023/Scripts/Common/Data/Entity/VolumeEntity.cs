namespace GameOff2023.Common.Data.Entity
{
    public sealed class VolumeEntity
    {
        public readonly float bgm;
        public readonly float se;

        public VolumeEntity(float bgm, float se)
        {
            this.bgm = bgm;
            this.se = se;
        }
    }
}