using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace GameOff2023.Common.Presentation.Controller
{
    public sealed class DontDestroyController : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = default;
        private static DontDestroyController _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);

                this.UpdateAsObservable()
                    .Where(_ => !canvas.worldCamera)
                    .Subscribe(_ => canvas.worldCamera = FindAnyObjectByType<Camera>())
                    .AddTo(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}