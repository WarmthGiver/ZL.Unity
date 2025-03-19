using UnityEditor;

namespace ZL.Unity.UI
{
    public static class NewButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(New)", false)]

        public static void CreateNewButton(MenuCommand menuCommand)
        {
            var button = Creator.CreateUI<NewButton>("Button (New)");

            Selection.activeGameObject = button.gameObject;
        }
    }
}