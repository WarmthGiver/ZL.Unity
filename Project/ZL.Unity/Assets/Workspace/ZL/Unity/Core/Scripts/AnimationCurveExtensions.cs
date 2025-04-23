using UnityEngine;

namespace ZL
{
    public static partial class AnimationCurveExtensions
    {
        public static float LerpTime(this AnimationCurve instance)
        {
            return instance.keys[^1].time;
        }
    }
}