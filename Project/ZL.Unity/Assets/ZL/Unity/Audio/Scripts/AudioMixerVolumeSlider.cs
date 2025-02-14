using UnityEngine;

using ZL.Unity.UI;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Mixer Volume Slider")]

    [DisallowMultipleComponent]

    public sealed class AudioMixerVolumeSlider : SliderValueDisplayer_TMP
    {
        [Space]

        [SerializeField]
        
        [UsingCustomProperty]
        
        [ReadOnlyWhenPlayMode]

        private string key;

        public void Refresh()
        {
            slider.value = AudioMixerManager.Instance.GetVolume(key) * 100f;
        }

        public override void OnValueChanged()
        {
            base.OnValueChanged();

            AudioMixerManager.Instance.SetVolume(key, slider.value * 0.01f);
        }
    }
}