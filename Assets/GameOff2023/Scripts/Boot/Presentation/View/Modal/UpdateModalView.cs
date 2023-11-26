using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using GameOff2023.Common.Presentation.View;
using UnityEngine;

namespace GameOff2023.Boot.Presentation.View
{
    public sealed class UpdateModalView : BaseModalView
    {
        [SerializeField] private DecisionButtonView openStoreButtonView = default;

        public void Init(Action<SeType> playSe)
        {
            openStoreButtonView.Init(playSe);
            openStoreButtonView.AddPushEvent(() => Application.OpenURL(UrlConfig.APP));
        }
    }
}