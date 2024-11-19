#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Fixed
{
    public static class EditorUtility
    {
        public static void SetDirty(Object target)
        {
            UnityEditor.EditorUtility.SetDirty(target);
        }
    }
}

#endif