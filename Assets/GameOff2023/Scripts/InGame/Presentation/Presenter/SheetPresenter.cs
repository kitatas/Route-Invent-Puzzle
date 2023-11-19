using GameOff2023.Common;
using UnityScreenNavigator.Runtime.Core.Sheet;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class SheetPresenter : IStartable
    {
        public void Start()
        {
            var sheetContainer = SheetContainer.Find(SheetConfig.INGAME_CONTAINER);
            sheetContainer.Register(SheetConfig.TOP_PATH, sheetId: SheetConfig.TOP_PATH).OnTerminate += () =>
            {
                // 初回はTopを表示する
                sheetContainer.Show(SheetConfig.TOP_PATH, false);
            };
        }
    }
}