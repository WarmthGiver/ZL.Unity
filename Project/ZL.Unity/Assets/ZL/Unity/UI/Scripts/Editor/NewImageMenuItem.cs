using UnityEditor;

using UnityEngine;

using ZL.Unity.Tools;

namespace ZL.Unity.UI.Editor
{
    public static class NewImageMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Image (New)", false)]

        public static void CreateNewImage(MenuCommand menuCommand)
        {
            var image = Creator.CreateUI<NewImage>("Image (New)");

            image.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = image.gameObject;
        }
    }
}