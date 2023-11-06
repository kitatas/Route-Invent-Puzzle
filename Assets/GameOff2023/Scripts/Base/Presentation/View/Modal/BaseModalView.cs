using System.Collections;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace GameOff2023.Base.Presentation.View
{
    public abstract class BaseModalView : Modal
    {
        [SerializeField] private BaseButtonView closeButtonView = default;

        public override IEnumerator Initialize()
        {
            closeButtonView.Init();
            closeButtonView.AddPushEvent(() =>
            {
                // モーダルの非表示
                var modalContainer = ModalContainer.Of(transform);
                modalContainer.Pop(true);
            });

            Init();

            yield break;
        }

        protected virtual void Init()
        {
        }
    }
}