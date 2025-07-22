using UnityEngine;

namespace ZL.Unity
{
    public static partial class ComponentEx
    {
        public static TComponent AddComponent<TComponent>(this Component instance)

            where TComponent : Component
        {
            return instance.gameObject.AddComponent<TComponent>();
        }

        public static GameObject AddComponents<TComponent>(this TComponent instance, params System.Type[] components)

            where TComponent : Component
        {
            return instance.gameObject.AddComponents(components);
        }
    }
}