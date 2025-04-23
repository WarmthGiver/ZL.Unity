using UnityEngine;

using UnityEngine.UI;

using ZL.Audio;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/Audio Mixer Volume Slider")]

    [DisallowMultipleComponent]

    public sealed class AudioMixerVolumeSlider : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnlyWhenPlayMode]

        [Essential]

        private Slider slider;

        [SerializeField]
        
        [UsingCustomProperty]
        
        [ReadOnlyWhenPlayMode]

        private string key;

        private AudioMixerManager audioMixerManager;

        private void Awake()
        {
            audioMixerManager = ISingleton<AudioMixerManager>.Instance;
        }

        public void Refresh()
        {
            slider.value = audioMixerManager.GetVolume(key) * 100f;
        }

        public void SetVolume(float value)
        {
            audioMixerManager.SetVolume(key, value * 0.01f);
        }
    }
}