using UnityEngine;

namespace ZL.Unity
{
    public static class FixedApplication
    {
        public static void Quit()
        {
#if UNITY_EDITOR

            FixedEditorApplication.isPlaying = false;

#else

            Application.Quit();

#endif
        }
    }
}