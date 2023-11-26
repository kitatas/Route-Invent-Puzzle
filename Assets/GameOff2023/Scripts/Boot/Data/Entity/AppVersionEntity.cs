using GameOff2023.Common;

namespace GameOff2023.Boot.Data.Entity
{
    public sealed class AppVersionEntity
    {
        public int major;
        public int minor;

        public bool IsForceUpdate()
        {
            return (major > AppConfig.MAJOR_VERSION) ||
                   (major == AppConfig.MAJOR_VERSION && minor > AppConfig.MINOR_VERSION);
        }
    }
}