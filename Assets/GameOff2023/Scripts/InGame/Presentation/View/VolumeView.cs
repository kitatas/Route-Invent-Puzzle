using System;
using GameOff2023.Common;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameOff2023.InGame.Presentation.View
{
    public sealed class VolumeView : MonoBehaviour
    {
        [SerializeField] private Slider bgm = default;
        [SerializeField] private Slider se = default;

        public void Init(Common.Data.Entity.VolumeEntity volumeEntity)
        {
            bgm.value = volumeEntity.bgm;
            se.value = volumeEntity.se;
        }

        public IObservable<float> updateBgmVolume => bgm.OnValueChangedAsObservable();
        public IObservable<float> updateSeVolume => se.OnValueChangedAsObservable();

        public IObservable<SeType> releaseVolume => releaseBgmVolume
            .Merge(releaseSeVolume)
            .Select(_ => SeType.Decision);

        private IObservable<PointerEventData> releaseBgmVolume => bgm.OnPointerUpAsObservable();
        private IObservable<PointerEventData> releaseSeVolume => se.OnPointerUpAsObservable();
    }
}