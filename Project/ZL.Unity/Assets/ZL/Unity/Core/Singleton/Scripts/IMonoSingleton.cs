using UnityEngine;

namespace ZL.Unity
{
    public interface IMonoSingleton<T> : ISingleton<T>
        
        where T : MonoBehaviour, ISingleton<T>
    {
        protected static new bool TrySetInstance(T instance)
        {
            if (ISingleton<T>.TrySetInstance(instance) == true)
            {
                instance.DontDestroyOnLoad();

                return true;
            }

            instance.Destroy();

            return false;
        }
    }
}