using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class SelectSheetView : BaseSheetView
    {
        [SerializeField] private Transform selectButtonParent = default;
        [SerializeField] private SelectButtonView selectButtonView = default;

        public void Init(Action<SeType> playSe, Data.Entity.LevelEntity level, Action<Data.Entity.LevelEntity> select)
        {
            var selectButton = Instantiate(selectButtonView, selectButtonParent);
            selectButton.SetUp(playSe, level);

            selectButton.AddPushEvent(() =>
            {
                select?.Invoke(level);
                StartCoroutine(ShowSheetCor(SheetConfig.GAME_PATH));
            });
        }
    }
}