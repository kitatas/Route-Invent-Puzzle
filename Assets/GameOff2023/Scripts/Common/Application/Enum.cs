namespace GameOff2023.Common
{
    public enum SceneName
    {
        None,
        Boot,
        Main,
    }

    public enum ExceptionType
    {
        None,
        Cancel,
        Retry,
        Reboot,
        Crash,
    }

    public enum ModalType
    {
        None,
        Close,
        Option,
        Information,
        Clear,
        Fail,
        Loading,
        Register,
        Update,
        Exception,
    }

    public enum BgmType
    {
        None,
        Title,
        Main,
        Result,
    }

    public enum SeType
    {
        None,
        Decision,
        Pop,
        Hand,
        Goal,
        Item,
        ScaleUp,
        ScaleDown,
    }
}