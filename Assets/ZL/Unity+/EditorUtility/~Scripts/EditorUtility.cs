using System.IO;

using UnityEngine;

namespace ZL
{
    public static class EditorUtility
    {
        public static T LoadScriptableObject<T>(string directoryPath, string assetPath)

            where T : ScriptableObject
        {
            var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(assetPath);

            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<T>();

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                UnityEditor.AssetDatabase.CreateAsset(asset, assetPath);

                UnityEditor.AssetDatabase.SaveAssets();

                UnityEditor.AssetDatabase.Refresh();
            }

            return asset;
        }
    }
}