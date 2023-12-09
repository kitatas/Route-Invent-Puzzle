using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using UniEx;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class InformationModalView : BaseModalView
    {
        [SerializeField] private InformationButtonView[] informationButtonViews = default;

        public override void SetUp(Action<SeType> playSe)
        {
            base.SetUp(playSe);
            informationButtonViews.Each(x => x.SetUp(playSe));
        }
    }
}