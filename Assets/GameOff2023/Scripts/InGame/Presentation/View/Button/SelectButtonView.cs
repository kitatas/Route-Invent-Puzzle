using System;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class SelectButtonView : BaseButtonView
    {
        [SerializeField] private TextMeshProUGUI levelText = default;
        [SerializeField] private Image lockIcon = default;
        [SerializeField] private Image clearIcon = default;

        public void SetUp(Action<SeType> playSe, Data.Entity.ProgressEntity progressEntity)
        {
            Init(playSe);

            if (progressEntity.isOpen)
            {
                Activate(true);
                levelText.text = $"{progressEntity.level}";
                lockIcon.enabled = false;
            }
            else
            {
                Activate(false);
                levelText.text = $"";
                lockIcon.enabled = true;
            }

            clearIcon.enabled = progressEntity.isClear;
        }
    }
}