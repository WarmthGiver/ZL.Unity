using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    public static partial class TransformEx
    {
        public static void SetPositionAndRotation(this Transform instance, Transform transform)
        {
            instance.SetPositionAndRotation(transform.position, transform.rotation);
        }

        public static void SetPositionAndRotation(this Transform instance, in Pose pose)
        {
            instance.SetPositionAndRotation(pose.position, pose.rotation);
        }

        public static void SetPositionAndRotation(this Transform instance, in Vector3 position, in Vector3 eulerAngles)
        {
            instance.SetPositionAndRotation(position, Quaternion.Euler(eulerAngles));
        }

        public static void SetPositionRandom(this Transform instance, in Vector3 min, in Vector3 max)
        {
            instance.position = RandomEx.Range(min, max);
        }

        public static void SetLocalPositionRandom(this Transform instance, in Vector3 min, in Vector3 max)
        {
            instance.localPosition = RandomEx.Range(min, max);
        }

        public static void SetRotationRandom(this Transform instance, in Vector3 min, in Vector3 max)
        {
            instance.rotation = Quaternion.Euler(RandomEx.Range(min, max));
        }

        public static void SetRotationRandom(this Transform instance)
        {
            instance.rotation = Quaternion.Euler(RandomEx.EulerAngles());
        }

        public static void SetLocalRotationRandom(this Transform instance, in Vector3 min, in Vector3 max)
        {
            instance.localRotation = Quaternion.Euler(RandomEx.Range(min, max));
        }

        public static void SetLocalRotationRandom(this Transform instance)
        {
            instance.localRotation = Quaternion.Euler(RandomEx.EulerAngles());
        }

        public static TComponent GetLastChild<TComponent>(this Transform instance)

            where TComponent : Component
        {
            return GetLastChild(instance).GetComponent<TComponent>();
        }

        public static Transform GetLastChild(this Transform instance)
        {
            return instance.GetChild(instance.childCount - 1);
        }

        public static void LookAt(this Transform instance, Vector3 worldPosition, Axis ignoreAxes)
        {
            LookAt(instance, worldPosition, Vector3.up, ignoreAxes);
        }

        public static void LookAt(this Transform instance, Vector3 worldPosition, Vector3 worldUp, Axis ignoreAxes)
        {
            instance.rotation = LookRotation(instance, worldPosition, worldUp, ignoreAxes);
        }

        public static Quaternion LookRotation(this Transform instance, Vector3 worldPosition, Axis ignoreAxes)
        {
            return LookRotation(instance, worldPosition, Vector3.up, ignoreAxes);
        }

        public static Quaternion LookRotation(this Transform instance, Vector3 worldPosition, Vector3 worldUp, Axis ignoreAxes)
        {
            if (QuaternionEx.TryLookRotation(instance.position, worldPosition, worldUp, ignoreAxes, out var rotation) == true)
            {
                return rotation;
            }

            return instance.rotation;
        }

        public static Transform FindClosest<TComponent>(this Transform instance, IEnumerable<TComponent> targets, Axis ignoreAxes, float minDistance = float.MaxValue)

            where TComponent : Component
        {
            Transform closest = null;

            foreach (var target in targets)
            {
                float distance = instance.position.DistanceTo(target.transform.position, ignoreAxes);

                if (minDistance >= distance)
                {
                    minDistance = distance;

                    closest = target.transform;
                }
            }

            return closest;
        }
    }
}