using UnityEditor;

using UnityEngine;

using ZL.Unity.Tools;

namespace ZL.Unity.UI.Editor
{
    public static class NewButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(New)", false)]

        public static void CreateNewButton(MenuCommand menuCommand)
        {
            var newButton = Creator.CreateUI<NewButton>("Button (New)");

            newButton.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = newButton.gameObject;
        }
    }
}