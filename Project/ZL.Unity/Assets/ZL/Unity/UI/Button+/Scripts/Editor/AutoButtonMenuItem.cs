using UnityEditor;

using UnityEngine;

using ZL.Unity.Tools;

namespace ZL.Unity.UI.Editor
{
    public static class AutoButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(Auto)", false)]

        public static void CreateAutoButton(MenuCommand menuCommand)
        {
            var autoButton = Creator.CreateUI<AutoButton>("Button (Auto)");

            autoButton.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = autoButton.gameObject;
        }
    }
}