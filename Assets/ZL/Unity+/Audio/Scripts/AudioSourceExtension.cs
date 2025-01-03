using UnityEngine;

namespace ZL
{
    public static partial class AudioSourceExtension
    {
        public static void Initialize(this AudioSource instance, AudioSource original)
        {
            instance.volume = original.volume;

            instance.pitch = original.pitch;

            instance.panStereo = original.panStereo;

            instance.spatialBlend = original.spatialBlend;

            instance.spatialize = original.spatialize;

            instance.spatializePostEffects = original.spatializePostEffects;

            instance.reverbZoneMix = original.reverbZoneMix;
        }
    }
}