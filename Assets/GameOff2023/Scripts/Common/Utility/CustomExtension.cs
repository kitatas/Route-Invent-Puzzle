using System;

namespace GameOff2023.Common
{
    public static class CustomExtension
    {
        public static string ToResourcePath(this ModalType type)
        {
            return type switch
            {
                ModalType.Option => ModalConfig.OPTION_PATH,
                ModalType.Information => ModalConfig.INFORMATION_PATH,
                ModalType.Clear => ModalConfig.CLEAR_PATH,
                _ => throw new Exception(),
            };
        }
    }
}