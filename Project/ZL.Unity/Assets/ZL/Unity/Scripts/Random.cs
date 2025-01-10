using UnityEngine;

namespace ZL.Unity
{
    public static partial class Random
    {
        public static void Range(in int min, in int max, out int @out)
        {
            @out = UnityEngine.Random.Range(min, max);
        }

        public static Vector3 Range(in Vector3 min, in Vector3 max)
        {
            return new Vector3
            {
                x = UnityEngine.Random.Range(min.x, max.x),

                y = UnityEngine.Random.Range(min.y, max.y),

                z = UnityEngine.Random.Range(min.z, max.z)
            };
        }

        public static Vector3 Euler()
        {
            return new Vector3
            {
                x = UnityEngine.Random.Range(0f, 360f),

                y = UnityEngine.Random.Range(0f, 360f),

                z = UnityEngine.Random.Range(0f, 360f)
            };
        }
    }
}