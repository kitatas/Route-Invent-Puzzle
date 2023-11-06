using System;

namespace GameOff2023.Common
{
    public static class CustomExtension
    {
        public static string ToResourcePath(this ModalType type)
        {
            return type switch
            {
                ModalType.Information => ModalConfig.INFORMATION_PATH,
                _ => throw new Exception(),
            };
        }
    }
}