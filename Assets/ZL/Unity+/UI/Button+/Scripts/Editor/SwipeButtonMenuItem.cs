using UnityEditor;

using UnityEngine;

namespace ZL.UI.Editor
{
    using ZL.Tools;

    public static class SwipeButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(Swipe)", false)]

        public static void CreateSwipeButton(MenuCommand menuCommand)
        {
            var swipeButton = CreateTool.CreateUI<SwipeButton>("Button (Swipe)");

            swipeButton.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = swipeButton.gameObject;
        }
    }
}