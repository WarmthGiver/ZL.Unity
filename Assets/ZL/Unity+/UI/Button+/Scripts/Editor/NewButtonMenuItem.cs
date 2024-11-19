using UnityEditor;

using UnityEngine;

namespace ZL.UI.Editor
{
    using ZL.Tools;

    public static class NewButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(New)", false)]

        public static void CreateNewButton(MenuCommand menuCommand)
        {
            var newButton = CreateTool.CreateUI<NewButton>("Button (New)");

            newButton.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = newButton.gameObject;
        }
    }
}