using System;

using System.Reflection;

using UnityEngine;

namespace ZL
{
    [AttributeUsage(AttributeTargets.Class)]

    public sealed class CteateAfterSceneLoadAttribute : Attribute
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]

        private static void RuntimeInitialize()
        {
            foreach (var assemblies in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = assemblies.GetTypes();

                if (types == null)
                {
                    continue;
                }

                foreach (var type in types)
                {
                    if (type.GetCustomAttribute<CteateAfterSceneLoadAttribute>() == null)
                    {
                        continue;
                    }

                    GameObject gameObject = new(type.Name.ToTitleCase(), type);

                    gameObject.DontDestroyOnLoad();
                }
            }
        }
    }
}