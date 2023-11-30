using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class EditCompButtonView : BaseButtonView
    {
        public override void Init(Action<SeType> playSe)
        {
            base.Init(playSe);
            Activate(false);
        }
    }
}