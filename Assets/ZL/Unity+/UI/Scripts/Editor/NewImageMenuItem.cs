using UnityEditor;

using UnityEngine;

namespace ZL.UI.Editor
{
    using ZL.Tools;

    public static class NewImageMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Image (New)", false)]

        public static void CreateNewImage(MenuCommand menuCommand)
        {
            var image = CreateTool.CreateUI<NewImage>("Image (New)");

            image.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = image.gameObject;
        }
    }
}