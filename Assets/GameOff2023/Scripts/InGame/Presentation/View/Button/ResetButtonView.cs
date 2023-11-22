using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class ResetButtonView : BaseButtonView
    {
        public void Init(Action<SeType> playSe, Action reset)
        {
            base.Init(playSe);
            AddPushEvent(() => reset?.Invoke());
        }
    }
}