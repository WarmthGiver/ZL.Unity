using System;

using System.Collections.Generic;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace ZL.Unity
{
    public static partial class ComponentExtensions
    {
        #region GetComponentInChildren

        public static bool TryGetComponentInChildren<TComponent>
            
            (this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInChildren(out result);
        }

        public static bool TryGetComponentInChildren
            
            (this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInChildren(type, out result);
        }

        public static bool TryGetComponentInChildrenOnly<TComponent>
            
            (this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInChildrenOnly(out result);
        }

        public static bool TryGetComponentInChildrenOnly
            
            (this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInChildrenOnly(type, out result);
        }

        public static bool TryGetComponentsInChildren<TComponent>
            
            (this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInChildren(out result);
        }

        public static bool TryGetComponentsInChildrenOnly<TComponent>
            
            (this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInChildrenOnly(out result);
        }

        #endregion

        #region GetComponentInParent

        public static bool TryGetComponentInParent<TComponent>
            
            (this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInParent(out result);
        }

        public static bool TryGetComponentInParent
            
            (this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInParent(type, out result);
        }

        public static bool TryGetComponentInParentOnly<TComponent>
            
            (this Component instance, out TComponent result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentInParentOnly(out result);
        }

        public static bool TryGetComponentInParentOnly
            
            (this Component instance, Type type, out Component result)
        {
            return instance.transform.TryGetComponentInParentOnly(type, out result);
        }

        public static bool TryGetComponentsInParent<TComponent>
            
            (this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInParent(out result);
        }

        public static bool TryGetComponentsInParentOnly<TComponent>
            
            (this Component instance, out List<TComponent> result)

            where TComponent : Component
        {
            return instance.transform.TryGetComponentsInParentOnly(out result);
        }

        #endregion

        public static TComponent AddComponent<TComponent>
            
            (this Component instance)

            where TComponent : Component
        {
            return instance.gameObject.AddComponent<TComponent>();
        }

        public static GameObject AddComponents<TComponent>
            
            (this TComponent instance, params Type[] components)

            where TComponent : Component
        {
            return instance.gameObject.AddComponents(components);
        }

        public static TComponent SetActive<TComponent>
            
            (this TComponent instance, bool value)

            where TComponent : Component
        {
            instance.gameObject.SetActive(value);

            return instance;
        }

        public static void DisallowMultiple<TComponent>
            
            (this TComponent instance)

            where TComponent : Component
        {
            void DestroyImmediate()
            {
                instance.DestroyImmediate();

                string typeName = instance.GetType().Name;

                FixedEditorUtility.DisplayDialog
                (
                    "Invalid operation.",
                    
                    $"Can't add '{typeName}' to {instance.gameObject.name} because a '{typeName}' is already added to the game object!",
                    
                    "Ok"
                );
            }

            if (instance.GetType().IsInheritGeneric(out var type) == true)
            {
                Component[] components = instance.GetComponents<Component>();

                foreach (var component in components)
                {
                    if (component == instance)
                    {
                        continue;
                    }

                    if (component.GetType().IsInheritGeneric(out var compareType) == true)
                    {
                        if (type.GetGenericTypeDefinition() == compareType.GetGenericTypeDefinition())
                        {
                            DestroyImmediate();

                            return;
                        }
                    }
                }
            }

            else if (instance.GetComponents<TComponent>().Length > 1)
            {
                DestroyImmediate();
            }
        }

        public static void DestroyImmediate<TComponent>
            
            (this TComponent instance)

            where TComponent : Component
        {
#if UNITY_EDITOR

            if (Application.isPlaying == false)
            {
                void Callback()
                {
                    var gameObject = instance.gameObject;

                    UnityObject.DestroyImmediate(instance);

                    EditorUtility.SetDirty(gameObject);

                    EditorApplication.update -= Callback;
                }

                EditorApplication.update += Callback;

                return;
            }

#endif

            UnityObject.DestroyImmediate(instance);
        }
    }
}