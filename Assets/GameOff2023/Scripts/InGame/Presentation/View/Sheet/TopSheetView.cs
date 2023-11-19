using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class TopSheetView : BaseSheetView
    {
        [SerializeField] private TopButtonView topButtonView = default;

        public void SetUp(Action<SeType> playSe)
        {
            topButtonView.Init(playSe);

            topButtonView.AddPushEvent(() => StartCoroutine(ShowSheetCor(SheetConfig.SELECT_PATH)));
        }
    }
}