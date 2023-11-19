using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using TMPro;
using UnityEngine;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class SelectButtonView : BaseButtonView
    {
        [SerializeField] private TextMeshProUGUI levelText = default;

        public void SetUp(Action<SeType> playSe, Data.Entity.LevelEntity level)
        {
            Init(playSe);
            levelText.text = $"{level.value}";
        }
    }
}