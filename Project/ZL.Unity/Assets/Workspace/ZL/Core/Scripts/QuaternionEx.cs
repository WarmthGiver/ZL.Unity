using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    public static partial class QuaternionEx
    {
        public static bool TryLookTowards(Quaternion rotation, Vector3 from, Vector3 to, Axis ignoreAxes, float maxDegreesDelta, out Quaternion nextRotation)
        {
            return TryLookTowards(rotation, from, to, Vector3.up, ignoreAxes, maxDegreesDelta, out nextRotation);
        }

        public static bool TryLookTowards(Quaternion rotation, Vector3 from, Vector3 to, Vector3 upwards, Axis ignoreAxes, float maxDegreesDelta, out Quaternion nextRotation)
        {
            var forward = Vector3Ex.Direction(from, to, ignoreAxes);

            return TryLookTowards(rotation, forward, upwards, maxDegreesDelta, out nextRotation);
        }

        public static bool TryLookTowards(Quaternion rotation, Vector3 forward, float maxDegreesDelta, out Quaternion nextRotation)
        {
            return TryLookTowards(rotation, forward, Vector3.up, maxDegreesDelta, out nextRotation);
        }

        public static bool TryLookTowards(Quaternion rotation, Vector3 forward, Vector3 upwards, float maxDegreesDelta, out Quaternion nextRotation)
        {
            if (!TryGetLookRotation(forward, upwards, out var lookRotation) || rotation == lookRotation)
            {
                nextRotation = rotation;

                return false;
            }

            nextRotation = Quaternion.RotateTowards(rotation, lookRotation, maxDegreesDelta);

            return true;
        }

        public static bool TryGetLookRotation(Vector3 from, Vector3 to, Axis ignoreAxes, out Quaternion lookRotation)
        {
            return TryGetLookRotation(from, to, Vector3.up, ignoreAxes, out lookRotation);
        }

        public static bool TryGetLookRotation(Vector3 from, Vector3 to, Vector3 upwards, Axis ignoreAxes, out Quaternion lookRotation)
        {
            var forward = Vector3Ex.Direction(from, to, ignoreAxes);

            return TryGetLookRotation(forward, upwards, out lookRotation);
        }

        public static bool TryGetLookRotation(Vector3 forward, out Quaternion lookRotation)
        {
            return TryGetLookRotation(forward, Vector3.up, out lookRotation);
        }

        public static bool TryGetLookRotation(Vector3 forward, Vector3 upwards, out Quaternion lookRotation)
        {
            if (forward.sqrMagnitude <= 0.0001f) // safe epsilon
            {
                lookRotation = default;

                return false;
            }

            lookRotation = Quaternion.LookRotation(forward, upwards);

            return true;
        }
    }
}