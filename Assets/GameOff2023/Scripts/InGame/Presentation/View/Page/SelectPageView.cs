using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class SelectPageView : BasePageView
    {
        [SerializeField] private Transform selectButtonParent = default;
        [SerializeField] private SelectButtonView selectButtonView = default;

        public void Init(Action<SeType> playSe, Data.Entity.ProgressEntity progress, Action<Data.Entity.LevelEntity> select)
        {
            var selectButton = Instantiate(selectButtonView, selectButtonParent);
            selectButton.SetUp(playSe, progress);

            selectButton.AddPushEvent(() =>
            {
                select?.Invoke(progress.levelEntity);
                container.Push(PageConfig.GAME_PATH, true, stack: false);
            });
        }
    }
}