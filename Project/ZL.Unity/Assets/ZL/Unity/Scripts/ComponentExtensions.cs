using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity
{
    public static partial class ComponentExtensions
    {
        #region GetComponentInChildren

        public static bool TryGetComponentInChildren<TComponent>(this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInChildren(out result);
        }

        public static bool TryGetComponentInChildren(this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInChildren(type, out result);
        }

        public static bool TryGetComponentInChildrenOnly<TComponent>(this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInChildrenOnly(out result);
        }

        public static bool TryGetComponentInChildrenOnly(this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInChildrenOnly(type, out result);
        }

        public static bool TryGetComponentsInChildren<TComponent>(this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInChildren(out result);
        }

        public static bool TryGetComponentsInChildrenOnly<TComponent>(this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInChildrenOnly(out result);
        }

        #endregion

        #region GetComponentInParent

        public static bool TryGetComponentInParent<TComponent>(this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInParent(out result);
        }

        public static bool TryGetComponentInParent(this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInParent(type, out result);
        }

        public static bool TryGetComponentInParentOnly<TComponent>(this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInParentOnly(out result);
        }

        public static bool TryGetComponentInParentOnly(this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInParentOnly(type, out result);
        }

        public static bool TryGetComponentsInParent<TComponent>(this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInParent(out result);
        }

        public static bool TryGetComponentsInParentOnly<TComponent>(this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInParentOnly(out result);
        }

        #endregion

        public static T AddComponent<T>(this Component instance)

            where T : Component
        {
            return instance.gameObject.AddComponent<T>();
        }

        public static GameObject AddComponents<T>(this T instance, params Type[] components)

            where T : Component
        {
            return instance.gameObject.AddComponents(components);
        }
    }
}