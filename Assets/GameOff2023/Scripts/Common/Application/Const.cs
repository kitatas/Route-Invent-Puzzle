namespace GameOff2023.Common
{
    public sealed class AppConfig
    {
        public const int MAJOR_VERSION = 1;
        public const int MINOR_VERSION = 1;
        public static readonly string APP_VERSION = $"{MAJOR_VERSION.ToString()}.{MINOR_VERSION.ToString()}";
    }

    public sealed class UrlConfig
    {
        public const string APP_NAME = "RIPuzzle";
        public const string DEVELOPER_APP = "https://play.google.com/store/apps/developer?id=KitaLab";
        public const string APP = "https://play.google.com/store/apps/details?id=com.KitaLab." + APP_NAME;

        public const string INFORMATION = "https://kitatas.github.io/games/route_invent_puzzle/";
        public const string CREDIT = INFORMATION + "credit";
        public const string LICENSE = INFORMATION + "license";
        public const string POLICY = INFORMATION + "policy";
    }

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
        public const string UPDATE_PATH = BASE_PATH + "/Update";
        public const string EXCEPTION_PATH = BASE_PATH + "/Exception";
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
        public const string UNKNOWN_ERROR = "UNKNOWN_ERROR";
        public const string NOT_FOUND_STATE = "NOT_FOUND_STATE";
        public const string NOT_FOUND_BGM = "NOT_FOUND_BGM";
        public const string NOT_FOUND_SE = "NOT_FOUND_SE";
        public const string NOT_FOUND_STAGE = "NOT_FOUND_STAGE";
        public const string NOT_FOUND_PANEL = "NOT_FOUND_PANEL";
        public const string NOT_FOUND_STAGE_OBJECT = "NOT_FOUND_STAGE_OBJECT";
        public const string NOT_FOUND_DATA = "NOT_FOUND_DATA";
        public const string NOT_FOUND_DIRECTION = "NOT_FOUND_DIRECTION";
        public const string NOT_FOUND_SCALE = "NOT_FOUND_SCALE";
        public const string NOT_FOUND_OBJECT = "NOT_FOUND_OBJECT";
        public const string NOT_FOUND_MODAL = "NOT_FOUND_MODAL";
        public const string NOT_FOUND_INFORMATION = "NOT_FOUND_INFORMATION";
        public const string UNMATCHED_USER_NAME_RULE = "UNMATCHED_USER_NAME_RULE";
        public const string FAILED_LOGIN = "FAILED_LOGIN";
        public const string FAILED_UPDATE_DATA = "FAILED_UPDATE_DATA";
        public const string FAILED_DESERIALIZE_MASTER = "FAILED_DESERIALIZE_MASTER";
        public const string FAILED_RESPONSE_DATA = "FAILED_RESPONSE_DATA";
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
        public const string MASTER_STAGE_KEY = "";
        public const string MASTER_APP_VERSION_KEY = "";

        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 10;
    }

    public sealed class SaveConfig
    {
        public const string ES3_KEY = "";
    }
}