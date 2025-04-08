using UnityEditor;

namespace ZL.Unity.UI
{
    public static class SwipeButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(Swipe)", false)]

        public static void CreateSwipeButton(MenuCommand menuCommand)
        {
            var button = Creator.CreateUI<SwipeButton>("Button (Swipe)");

            Selection.activeGameObject = button.gameObject;
        }
    }
}