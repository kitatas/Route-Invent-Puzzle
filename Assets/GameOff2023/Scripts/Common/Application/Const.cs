namespace GameOff2023.Common
{
    public sealed class SheetConfig
    {
        // container name
        public const string INGAME_CONTAINER = "InGameSheetContainer";

        // sheet prefab path
        private const string BASE_PATH = "Sheet";
        public const string TOP_PATH = BASE_PATH + "/Top";
        public const string SELECT_PATH = BASE_PATH + "/Select";
    }

    public sealed class ModalConfig
    {
        // container name
        public const string INGAME_CONTAINER = "InGameModalContainer";

        // modal prefab path
        private const string BASE_PATH = "Modal";
        public const string OPTION_PATH = BASE_PATH + "/Option";
        public const string INFORMATION_PATH = BASE_PATH + "/Information";
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