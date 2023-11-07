using UniEx;
using UnityEngine;

namespace GameOff2023.Common.Presentation.View
{
    public sealed class SoundView : MonoBehaviour
    {
        [SerializeField] private AudioSource bgmSource = default;

        public void PlayBgm(AudioClip clip, float delay)
        {
            this.Delay(delay, () =>
            {
                bgmSource.clip = clip;
                bgmSource.Play();
            });
        }
    }
}