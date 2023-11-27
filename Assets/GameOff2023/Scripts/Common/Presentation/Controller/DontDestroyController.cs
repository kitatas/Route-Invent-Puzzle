using UnityEngine;

namespace GameOff2023.Common.Presentation.Controller
{
    public sealed class DontDestroyController : MonoBehaviour
    {
        private static DontDestroyController _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}