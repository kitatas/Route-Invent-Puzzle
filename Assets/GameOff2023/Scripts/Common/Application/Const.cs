namespace GameOff2023.Common
{
    public sealed class ModalConfig
    {
        // container name
        public const string INGAME_CONTAINER = "InGameModalContainer";

        // modal prefab path
        private const string BASE_PATH = "Modal";
        public const string OPTION_PATH = BASE_PATH + "/Option";
        public const string INFORMATION_PATH = BASE_PATH + "/Information";
        public const string CLEAR_PATH = BASE_PATH + "/Clear";
        public const string FAIL_PATH = BASE_PATH + "/Fail";
        public const string LOADING_PATH = BASE_PATH + "/Loading";
    }

    public sealed class PageConfig
    {
        public const float ANIMATION_TIME = 0.3f;
        
        // container name
        public const string INGAME_CONTAINER = "InGamePageContainer";

        // page prefab path
        private const string BASE_PATH = "Page";
        public const string TOP_PATH = BASE_PATH + "/Top";
        public const string SELECT_PATH = BASE_PATH + "/Select";
        public const string GAME_PATH = BASE_PATH + "/Game";
    }

    public sealed class UiConfig
    {
        public const float PUSH_TIME = 0.1f;
    }

    public sealed class SoundConfig
    {
        public const float INIT_VOLUME = 0.5f;
    }

    public sealed class SaveConfig
    {
        public const string ES3_KEY = "";
    }
}