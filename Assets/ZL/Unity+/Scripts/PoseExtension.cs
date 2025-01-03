using UnityEngine;

namespace ZL
{
    public static partial class PoseExtension
    {
        public static void Set(this Pose instance, Transform value)
        {
            instance.position = value.position;

            instance.rotation = value.rotation;
        }
    }
}