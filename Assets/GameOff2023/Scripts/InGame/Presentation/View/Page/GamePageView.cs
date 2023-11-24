using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class GamePageView : BasePageView
    {
        public void SetUp(Action<SeType> playSe, Action back)
        {
            base.SetUp(playSe, "");
            closeButtonView.AddPushEvent(() => back?.Invoke());
        }
    }
}