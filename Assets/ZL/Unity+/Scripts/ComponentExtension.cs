using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL
{
    public static partial class ComponentExtension
    {
        #region GetComponentInChildren

        public static bool TryGetComponentInChildren<TComponent>(this Component instance, out TComponent component)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInChildren(out component);
        }

        public static bool TryGetComponentInChildren(this Component instance, Type type, out Component component)
        {
            return instance.transform.TryGetComponentInChildren(type, out component);
        }

        public static bool TryGetComponentInChildrenOnly<TComponent>(this Component instance, out TComponent component)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInChildrenOnly(out component);
        }

        public static bool TryGetComponentInChildrenOnly(this Component instance, Type type, out Component component)
        {
            return instance.transform.TryGetComponentInChildrenOnly(type, out component);
        }

        public static bool TryGetComponentsInChildren<TComponent>(this Component instance, out List<TComponent> components)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInChildren(out components);
        }

        public static bool TryGetComponentsInChildrenOnly<TComponent>(this Component instance, out List<TComponent> components)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInChildrenOnly(out components);
        }

        #endregion

        #region GetComponentInParent

        public static bool TryGetComponentInParent<TComponent>(this Component instance, out TComponent component)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInParent(out component);
        }

        public static bool TryGetComponentInParent(this Component instance, Type type, out Component component)
        {
            return instance.transform.TryGetComponentInParent(type, out component);
        }

        public static bool TryGetComponentInParentOnly<TComponent>(this Component instance, out TComponent component)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInParentOnly(out component);
        }

        public static bool TryGetComponentInParentOnly(this Component instance, Type type, out Component component)
        {
            return instance.transform.TryGetComponentInParentOnly(type, out component);
        }

        public static bool TryGetComponentsInParent<TComponent>(this Component instance, out List<TComponent> components)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInParent(out components);
        }

        public static bool TryGetComponentsInParentOnly<TComponent>(this Component instance, out List<TComponent> components)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInParentOnly(out components);
        }

        #endregion

        public static T AddComponent<T>(this T instance)

            where T : Component
        {
            return instance.gameObject.AddComponent<T>();
        }

        public static T AddComponents<T>(this T instance, params Type[] components)

            where T : Component
        {
            instance.gameObject.AddComponents(components);

            return instance;
        }

        public static T SetActive<T>(this T instance, bool value)

            where T : Component
        {
            instance.gameObject.SetActive(value);
            
            return instance;
        }
    }
}