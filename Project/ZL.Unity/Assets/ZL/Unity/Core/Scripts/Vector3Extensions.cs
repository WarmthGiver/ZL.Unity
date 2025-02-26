using UnityEngine;

namespace ZL.Unity
{
    public static partial class Vector3Extensions
    {
        public static Color ToColor(this Vector3 instance, bool normalize)
        {
            instance = Absoulute(instance);

            if (normalize == true)
            {
                instance = instance.normalized;
            }
            
            else
            {
                float max = Max(instance);

                float scale = 1 / max;

                instance *= scale;
            }

            return new(instance.x, instance.y, instance.z);
        }

        public static Vector3 Absoulute(this Vector3 instance)
        {
            if (instance.x < 0)
            {
                instance.x = -instance.x;
            }

            if (instance.y < 0)
            {
                instance.y = -instance.y;
            }

            if (instance.z < 0)
            {
                instance.z = -instance.z;
            }

            return instance;
        }

        public static float Max(this Vector3 instance)
        {
            float max = instance.x;

            if (max < instance.y)
            {
                max = instance.x;
            }

            if (max < instance.z)
            {
                max = instance.x;
            }

            return max;
        }
    }
}