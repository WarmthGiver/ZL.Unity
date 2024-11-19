using System.Diagnostics;

using UnityEngine;

#if UNITY_EDITOR

using Base = UnityEditor.AnimationUtility;

#endif

namespace ZL.Fixed
{
    public static class AnimationUtility
    {
        [Conditional("UNITY_EDITOR")]

        public static void SetKeyRightTangentMode(AnimationCurve curve, int index, TangentMode tangentMode)
        {
#if UNITY_EDITOR

            Base.SetKeyRightTangentMode(curve, index, tangentMode.ToEnum<TangentMode, Base.TangentMode>());

#endif
        }

        [Conditional("UNITY_EDITOR")]

        public static void SetKeyLeftTangentMode(AnimationCurve curve, int index, TangentMode tangentMode)
        {
#if UNITY_EDITOR

            Base.SetKeyLeftTangentMode(curve, index, (Base.TangentMode)tangentMode);

#endif
        }
    }
}