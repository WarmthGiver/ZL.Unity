using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/UI/Screen Group")]

    public sealed class ScreenUIGroup : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private ScreenUI mainScreen = null;

        [SerializeField]

        private ScreenUI currentScreen = null;

        [Space]

        [SerializeField]

        private bool disappearCurrentOnSwap = true;

        [SerializeField]

        private bool sortSibling = true;

        public void AppearMainScreen()
        {
            if (mainScreen != null)
            {
                mainScreen.Appear();
            }
        }

        public void SwapCurrentScreen(ScreenUI newScreen)
        {
            if (disappearCurrentOnSwap == true)
            {
                DisappearCurrentScreen();
            }

            currentScreen = newScreen;

            if (sortSibling == true)
            {
                currentScreen.transform.SetAsLastSibling();
            }
        }

        public void DisappearCurrentScreen()
        {
            if (currentScreen != null)
            {
                currentScreen.Disappear();
            }
        }
    }
}