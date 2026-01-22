using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/UI/Audio Mixer Volume Slider")]

    public sealed class AudioMixerVolumeSlider : MonoBehaviour
    {
        [Space]

        [Essential]

        [UsingCustomProperty]

        [SerializeField]

        private Slider slider;

        [SerializeField]

        private string key;

        public void Refresh()
        {
            Debug.Log(AudioMixerManager.Instance.GetVolume(key));

            slider.value = AudioMixerManager.Instance.GetVolume(key);
        }

        public void SetVolume(float value)
        {
            AudioMixerManager.Instance.SetVolume(key, value);
        }
    }
}