using UnityEngine;

namespace ZL.Unity
{
    public static partial class RandomEx
    {
        public static Vector3 Range(in Vector3 minInclusive, in Vector3 maxInclusive)
        {
            return new()
            {
                x = Random.Range(minInclusive.x, maxInclusive.x),

                y = Random.Range(minInclusive.y, maxInclusive.y),

                z = Random.Range(minInclusive.z, maxInclusive.z)
            };
        }

        public static Vector3 Angles()
        {
            return new()
            {
                x = Random.Range(0f, 360f),

                y = Random.Range(0f, 360f),

                z = Random.Range(0f, 360f)
            };
        }
    }
}