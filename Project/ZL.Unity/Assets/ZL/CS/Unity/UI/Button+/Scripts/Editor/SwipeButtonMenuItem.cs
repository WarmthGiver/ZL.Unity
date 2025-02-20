using UnityEditor;

using UnityEngine;

namespace ZL.CS.Unity.UI
{
    public static class SwipeButtonMenuItem
    {
        [MenuItem("GameObject/ZL/UI/Button(Swipe)", false)]

        public static void CreateSwipeButton(MenuCommand menuCommand)
        {
            var swipeButton = Creator.CreateUI<SwipeButton>("Button (Swipe)");

            swipeButton.gameObject.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = swipeButton.gameObject;
        }
    }
}