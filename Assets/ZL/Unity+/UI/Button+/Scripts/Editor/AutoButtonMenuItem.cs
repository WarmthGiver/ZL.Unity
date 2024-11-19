using UnityEditor;

using UnityEngine;

namespace ZL.UI.Editor
{
    using ZL.Tools;

    public static class AutoButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(Auto)", false)]

        public static void CreateAutoButton(MenuCommand menuCommand)
        {
            var autoButton = CreateTool.CreateUI<AutoButton>("Button (Auto)");

            autoButton.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = autoButton.gameObject;
        }
    }
}