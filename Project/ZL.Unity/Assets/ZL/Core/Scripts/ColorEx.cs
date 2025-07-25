using UnityEngine;

namespace ZL.Unity
{
    public static partial class ColorEx
    {
        public static Color Tone(this Color instance, in float tone)
        {
            instance.r *= tone;

            instance.g *= tone;

            instance.b *= tone;

            return instance;
        }

        public static Color Alpha(this Color instance, in float alpha)
        {
            instance.a = alpha;

            return instance;
        }
    }
}