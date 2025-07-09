using System;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    public static partial class TransformEx
    {
        #region Get Component In Children

        public static bool TryGetComponentInChildren<TComponent>(this Transform instance, out TComponent component)

            where TComponent : Component
        {
            if (instance.TryGetComponent(out component) == false)
            {
                component = GetComponentInChildrenOnly<TComponent>(instance);
            }

            return component != null;
        }

        public static bool TryGetComponentInChildren(this Transform instance, System.Type type, out Component component)
        {
            if (instance.TryGetComponent(type, out component) == false)
            {
                component = GetComponentInChildrenOnly(instance, type);
            }

            return component != null;
        }

        public static bool TryGetComponentInChildrenOnly<TComponent>(this Transform instance, out TComponent component)

            where TComponent : Component
        {
            component = GetComponentInChildrenOnly<TComponent>(instance);

            return component != null;
        }

        public static bool TryGetComponentInChildrenOnly(this Transform instance, System.Type type, out Component component)
        {
            component = GetComponentInChildrenOnly(instance, type);

            return component != null;
        }

        private static TComponent GetComponentInChildrenOnly<TComponent>(this Transform instance)

            where TComponent : Component
        {
            foreach (Transform child in instance)
            {
                if (child.TryGetComponent(out TComponent component) == true)
                {
                    return component;
                }

                component = GetComponentInChildrenOnly<TComponent>(child);

                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }

        private static Component GetComponentInChildrenOnly(this Transform instance, System.Type type)
        {
            foreach (Transform child in instance)
            {
                if (child.TryGetComponent(type, out var component) == true)
                {
                    return component;
                }

                component = GetComponentInChildrenOnly(child, type);

                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }

        public static bool TryGetComponentsInChildren<TComponent>(this Transform instance, out List<TComponent> components)

            where TComponent : Component
        {
            components = new List<TComponent>();

            if (instance.TryGetComponent(out TComponent component) == true)
            {
                components.Add(component);
            }

            GetComponentsInChildrenOnly(instance, ref components);

            return components.Count > 0;
        }

        public static bool TryGetComponentsInChildrenOnly<TComponent>(this Transform instance, out List<TComponent> components)

            where TComponent : Component
        {
            components = new List<TComponent>();

            GetComponentsInChildrenOnly(instance, ref components);

            return components.Count > 0;
        }

        private static void GetComponentsInChildrenOnly<TComponent>(this Transform instance, ref List<TComponent> components)

            where TComponent : Component
        {
            foreach (Transform child in instance)
            {
                if (child.TryGetComponent(out TComponent component) == true)
                {
                    components.Add(component);
                }

                GetComponentsInChildrenOnly(child, ref components);
            }
        }

        #endregion

        #region Get Component In Parent

        public static bool TryGetComponentInParent<TComponent>(this Transform instance, out TComponent component)

            where TComponent : Component
        {
            component = GetComponentInParent<TComponent>(instance);

            return component != null;
        }

        public static bool TryGetComponentInParent(this Transform instance, System.Type type, out Component component)
        {
            component = GetComponentInParent(instance, type);

            return component != null;
        }

        public static bool TryGetComponentInParentOnly<TComponent>(this Transform instance, out TComponent component)

            where TComponent : Component
        {
            component = GetComponentInParent<TComponent>(instance.parent);

            return component != null;
        }

        public static bool TryGetComponentInParentOnly(this Transform instance, System.Type type, out Component component)
        {
            component = GetComponentInParent(instance.parent, type);

            return component != null;
        }

        private static TComponent GetComponentInParent<TComponent>(this Transform instance)

            where TComponent : Component
        {
            while (instance != null)
            {
                if (instance.TryGetComponent(out TComponent component) == true)
                {
                    return component;
                }

                instance = instance.parent;
            }

            return null;
        }

        private static Component GetComponentInParent(this Transform instance, System.Type type)
        {
            while (instance != null)
            {
                if (instance.TryGetComponent(type, out var component) == true)
                {
                    return component;
                }

                instance = instance.parent;
            }

            return null;
        }

        public static bool TryGetComponentsInParent<TComponent>(this Transform instance, out List<TComponent> components)

            where TComponent : Component
        {
            components = new List<TComponent>();

            if (instance.TryGetComponent<TComponent>(out var component) == true)
            {
                components.Add(component);
            }

            GetComponentsInParentOnly(instance, ref components);

            return components.Count > 0;
        }

        public static bool TryGetComponentsInParentOnly<TComponent>(this Transform instance, out List<TComponent> components)

            where TComponent : Component
        {
            components = new List<TComponent>();

            GetComponentsInParentOnly(instance, ref components);

            return components.Count > 0;
        }

        private static void GetComponentsInParentOnly<TComponent>(this Transform instance, ref List<TComponent> components)

            where TComponent : Component
        {
            var parent = instance.parent;

            while (parent != null)
            {
                if (parent.TryGetComponent<TComponent>(out var component) == true)
                {
                    components.Add(component);
                }

                parent = parent.parent;
            }
        }

        #endregion

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