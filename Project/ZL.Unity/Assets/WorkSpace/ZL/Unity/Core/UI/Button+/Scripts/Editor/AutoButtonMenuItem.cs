using UnityEditor;

namespace ZL.Unity.UI
{
    public static class AutoButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(Auto)", false)]

        public static void CreateAutoButton(MenuCommand menuCommand)
        {
            var button = Creator.CreateUI<AutoButton>("Button (Auto)");

            Selection.activeGameObject = button.gameObject;
        }
    }
}