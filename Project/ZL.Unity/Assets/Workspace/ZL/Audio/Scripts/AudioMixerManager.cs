#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using UnityEngine.Audio;

using ZL.CS;

using ZL.Unity.Collections;

using ZL.Unity.Singleton;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Mixer Manager (Singleton)")]

    public sealed class AudioMixerManager : MonoSingleton<AudioMixerManager>
    {
        [Space]

        [Essential]

        [PropertyField]

        [Button("SerializaVolumes")]

        [UsingCustomProperty]

        [SerializeField]

        private AudioMixer audioMixer = null;

        [Space]

        [Button(nameof(LoadVolumes))]

        [Button(nameof(SaveVolumes))]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private SerializableDictionary<string, FloatPref> volumePrefs = null;

        #if UNITY_EDITOR

        private void OnValidate()
        {
            if (volumePrefs == null)
            {
                return;
            }

            foreach (var volumePref in volumePrefs.Values)
            {
                volumePref.Value = Mathf.Clamp(volumePref.Value, 0f, 100f);
            }
        }

        public void SerializaVolumes()
        {
            volumePrefs.Clear();

            if (audioMixer != null)
            {
                foreach (var audioMixerGroup in audioMixer.FindMatchingGroups(""))
                {
                    var key = audioMixerGroup.name;

                    audioMixer.GetFloat(key, out float decibel);

                    var volume = MathFEx.DecibelToPercent(decibel);

                    var volumePref = new FloatPref($"{audioMixer.name}.{key}", volume);

                    volumePref.TryLoadValue();

                    volumePrefs.Add(key, volumePref);
                }
            }

            EditorUtility.SetDirty(this);
        }

        #endif

        private void Start()
        {
            foreach ((var key, var volumePref) in volumePrefs)
            {
                volumePref.OnValueChangedAction += (value) =>
                {
                    audioMixer.SetVolume(key, value);
                };
            }

            LoadVolumes();
        }

        public void LoadVolumes()
        {
            foreach (var volumePref in volumePrefs.Values)
            {
                volumePref.TryLoadValue();
            }
        }

        public void SaveVolumes()
        {
            foreach (var volumePref in volumePrefs.Values)
            {
                volumePref.SaveValue();
            }
        }

        public float GetVolume(string key)
        {
            return volumePrefs[key].Value;
        }

        public void SetVolume(string key, float value)
        {
            volumePrefs[key].Value = value;
        }
    }
}