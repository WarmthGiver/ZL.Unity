using UnityEngine;

namespace ZL.Unity.Fixed
{
    public static class AssetDatabase
    {
        public static T LoadAssetAtPath<T>(string assetPath)

            where T : Object
        {
            return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(assetPath);
        }
    }
}