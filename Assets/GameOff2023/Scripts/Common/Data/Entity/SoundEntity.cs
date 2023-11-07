using UnityEngine;

namespace GameOff2023.Common.Data.Entity
{
    public sealed class SoundEntity
    {
        public readonly AudioClip clip;
        public readonly float delay;

        public SoundEntity(AudioClip clip, float delay)
        {
            this.clip = clip;
            this.delay = delay;
        }
    }
}