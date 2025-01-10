using UnityEngine;

namespace ZL.Unity
{
    public static class MonoBehaviourExtensions
    {
        public static bool TryGetSingleton<T>(this T instance, out T result)

            where T : MonoBehaviour
        {
            result = UnityEngine.Object.FindObjectOfType<T>();

            if (result == instance)
            {
                instance.gameObject.DontDestroyOnLoad();

                return true;
            }

            instance.gameObject.Destroy();

            return false;
        }
    }
}