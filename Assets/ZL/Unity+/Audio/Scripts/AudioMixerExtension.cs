using UnityEngine.Audio;

namespace ZL
{
    public static partial class AudioMixerExtension
    {
        public static void SetVolume(this AudioMixer instance, string key, float value)
        {
            instance.SetFloat(key, MathEx.LinearToDecibel(value));
        }

        public static float GetVolume(this AudioMixer instance, string key)
        {
            instance.GetFloat(key, out float value);

            return MathEx.LinearToDecibel(value);
        }
    }
}