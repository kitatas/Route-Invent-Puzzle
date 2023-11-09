using UniEx;
using UnityEngine;

namespace GameOff2023.Common.Presentation.View
{
    public sealed class SoundView : MonoBehaviour
    {
        [SerializeField] private AudioSource bgmSource = default;
        [SerializeField] private AudioSource seSource = default;

        public void SetBgmVolume(float value)
        {
            bgmSource.volume = value;
        }

        public void SetSeVolume(float value)
        {
            seSource.volume = value;
        }

        public void PlayBgm(AudioClip clip, float delay)
        {
            this.Delay(delay, () =>
            {
                bgmSource.clip = clip;
                bgmSource.Play();
            });
        }

        public void PlaySe(AudioClip clip, float delay)
        {
            this.Delay(delay, () =>
            {
                seSource.PlayOneShot(clip);
            });
        }
    }
}