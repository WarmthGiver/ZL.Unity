namespace ZL.Fixed
{
    public static class Application
    {
        public static void Quit()
        {
#if UNITY_EDITOR

            EditorApplication.isPlaying = false;

#else

            UnityEngine.Application.Quit();

#endif
        }
    }
}