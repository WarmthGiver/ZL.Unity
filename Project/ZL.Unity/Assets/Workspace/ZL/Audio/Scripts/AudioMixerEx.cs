using UnityEngine.Audio;

using ZL.CS;

namespace ZL.Unity
{
    public static partial class AudioMixerEx
    {
        public static void SetVolume(this AudioMixer instance, string key, float volume)
        {
            instance.SetFloat(key, MathFEx.PercentToDecibel(volume));
        }
    }
}