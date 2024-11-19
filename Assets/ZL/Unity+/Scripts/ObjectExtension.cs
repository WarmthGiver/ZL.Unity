using UnityEngine;

namespace ZL
{
    public static partial class ObjectExtension
    {
        public static void DontDestroyOnLoad(this Object instance)
        {
            Object.DontDestroyOnLoad(instance);
        }
    }
}