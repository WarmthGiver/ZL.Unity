using UnityEditor;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    public static class ButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button", false)]

        public static void CreateAutoButton(MenuCommand menuCommand)
        {
            var button = Creator.CreateUI<Button>("Button");

            Selection.activeGameObject = button.gameObject;
        }
    }
}