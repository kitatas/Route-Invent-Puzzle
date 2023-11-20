using GameOff2023.Common;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer.Unity;

namespace GameOff2023.InGame.Presentation.Presenter
{
    public sealed class PagePresenter : IStartable
    {
        public void Start()
        {
            var pageContainer = PageContainer.Find(PageConfig.INGAME_CONTAINER);
            pageContainer.Push(PageConfig.TOP_PATH, true, stack: false);
        }
    }
}