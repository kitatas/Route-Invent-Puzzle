using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2023.Base.Presentation.View;
using GameOff2023.Common;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameOff2023.Boot.Presentation.View
{
    public sealed class RegisterModalView : BaseModalView
    {
        [SerializeField] private TMP_InputField inputField = default;

        public async UniTask<string> DecisionNameAsync(Action<SeType> playSe, CancellationToken token)
        {
            SetUp(playSe);
            inputField.text = "user" + $"{Random.Range(0, 1000000):000000}";

            await closeButtonView.PushAsync(token);

            return inputField.text;
        }
    }
}