using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class InformationButtonView : BaseButtonView
    {
        [SerializeField] private InformationType type = default;

        public void SetUp(Action<SeType> playSe)
        {
            Init(playSe);
            AddPushEvent(() => Application.OpenURL(type.ToInformationUrl()));
        }
    }
}