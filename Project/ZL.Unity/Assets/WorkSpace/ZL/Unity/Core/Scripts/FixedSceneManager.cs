using System.Collections;

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL
{
    public static partial class FixedSceneManager
    {
        public static void LoadScene(string sceneName)
        {
            LoadScene(null, 0f, sceneName);
        }

        public static void LoadScene(MonoBehaviour instance, float delay, string sceneName)
        {
            instance.StartCoroutine(LoadSceneRoutine(delay, sceneName));
        }

        public static IEnumerator LoadSceneRoutine(float delay, string sceneName)
        {
            if (delay > 0f)
            {
                yield return WaitFor.Seconds(delay);
            }

            FixedSelection.SetActiveObject(null);

            SceneManager.LoadScene(sceneName);
        }
    }
}