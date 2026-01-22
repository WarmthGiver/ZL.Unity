using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    public static partial class RigidbodyEx
    {
        public static void MoveForward(this Rigidbody instance, float distance)
        {
            var nextPosition = instance.position + instance.rotation * Vector3.forward * distance;

            instance.MovePosition(nextPosition);
        }

        public static void MoveTowards(this Rigidbody instance, Transform target, float maxDistanceDelta)
        {
            MoveTowards(instance, target.position, maxDistanceDelta);
        }

        public static void MoveTowards(this Rigidbody instance, Vector3 targetPosition, float maxDistanceDelta)
        {
            var nextPosition = Vector3.MoveTowards(instance.position, targetPosition, maxDistanceDelta);

            instance.MovePosition(nextPosition);
        }

        public static void ForceMovePosition(this Rigidbody instance, Vector3 position)
        {
            var constraints = instance.constraints;

            instance.constraints = ~(RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);

            instance.MovePosition(position);

            instance.constraints = constraints;
        }

        public static bool TryLookTowards(this Rigidbody instance, Vector3 worldPosition, Axis ignoreAxes, float maxDegreesDelta)
        {
            return TryLookTowards(instance, worldPosition, Vector3.up, ignoreAxes, maxDegreesDelta);
        }

        public static bool TryLookTowards(this Rigidbody instance, Vector3 worldPosition, Vector3 upwards, Axis ignoreAxes, float maxDegreesDelta)
        {
            var forward = Vector3Ex.Direction(instance.position, worldPosition, ignoreAxes);

            return TryLookTowards(instance, forward, upwards, maxDegreesDelta);
        }

        public static bool TryLookTowards(this Rigidbody instance, Vector3 forward, float maxDegreesDelta)
        {
            return TryLookTowards(instance, forward, Vector3.up, maxDegreesDelta);
        }

        public static bool TryLookTowards(this Rigidbody instance, Vector3 forward, Vector3 upwards, float maxDegreesDelta)
        {
            if (!QuaternionEx.TryLookTowards(instance.rotation, forward, upwards, maxDegreesDelta, out var nextRotation))
            {
                return false;
            }

            instance.MoveRotation(nextRotation);

            return true;
        }
    }
}