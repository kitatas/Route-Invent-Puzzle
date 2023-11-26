namespace GameOff2023.Common
{
    public sealed class ModalConfig
    {
        public const float ANIMATION_TIME = 0.3f;

        // container name
        public const string INGAME_CONTAINER = "InGameModalContainer";

        // modal prefab path
        private const string BASE_PATH = "Modal";
        public const string OPTION_PATH = BASE_PATH + "/Option";
        public const string INFORMATION_PATH = BASE_PATH + "/Information";
        public const string CLEAR_PATH = BASE_PATH + "/Clear";
        public const string FAIL_PATH = BASE_PATH + "/Fail";
        public const string LOADING_PATH = BASE_PATH + "/Loading";
        public const string REGISTER_PATH = BASE_PATH + "/Register";
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

    public sealed class ExceptionConfig
    {
        public const string NOT_FOUND_DATA = "NOT_FOUND_DATA";
        public const string UNMATCHED_USER_NAME_RULE = "UNMATCHED_USER_NAME_RULE";
        public const string FAILED_LOGIN = "FAILED_LOGIN";
        public const string FAILED_UPDATE_DATA = "FAILED_UPDATE_DATA";
    }

    public sealed class UiConfig
    {
        public const float PUSH_TIME = 0.1f;
    }

    public sealed class SoundConfig
    {
        public const float INIT_VOLUME = 0.5f;
    }

    public sealed class PlayFabConfig
    {
        public const string TITLE_ID = "";
        public const string USER_PROGRESS_KEY = "";

        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 10;
    }

    public sealed class SaveConfig
    {
        public const string ES3_KEY = "";
    }
}