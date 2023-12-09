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
                ModalType.Fail => ModalConfig.FAIL_PATH,
                ModalType.Loading => ModalConfig.LOADING_PATH,
                ModalType.Register => ModalConfig.REGISTER_PATH,
                ModalType.Update => ModalConfig.UPDATE_PATH,
                ModalType.Exception => ModalConfig.EXCEPTION_PATH,
                _ => throw new CrashException(ExceptionConfig.NOT_FOUND_MODAL),
            };
        }

        public static string ToInformationUrl(this InformationType type)
        {
            return type switch
            {
                InformationType.Credit => UrlConfig.CREDIT,
                InformationType.License => UrlConfig.LICENSE,
                InformationType.Policy => UrlConfig.POLICY,
                InformationType.OtherApp => UrlConfig.DEVELOPER_APP,
                _ => throw new CrashException(ExceptionConfig.NOT_FOUND_INFORMATION),
            };
        }
    }
}