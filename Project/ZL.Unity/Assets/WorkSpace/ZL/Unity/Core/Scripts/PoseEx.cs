using UnityEngine;

namespace ZL.Unity
{
    public static partial class PoseEx
    {
        public static void Set(this Pose instance, Transform value)
        {
            instance.position = value.position;

            instance.rotation = value.rotation;
        }
    }
}