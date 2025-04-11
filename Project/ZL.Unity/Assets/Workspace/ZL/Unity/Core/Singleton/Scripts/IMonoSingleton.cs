using UnityEngine;

namespace ZL.Unity
{
    public interface IMonoSingleton<TMonoBehaviour> : ISingleton<TMonoBehaviour>
        
        where TMonoBehaviour : MonoBehaviour, ISingleton<TMonoBehaviour>
    {
        bool ISingleton<TMonoBehaviour>.TrySetInstance()
        {
            if (IsDuplicated() == true)
            {
                ((TMonoBehaviour)this).gameObject.Destroy();

                return false;
            }

            Instance = (TMonoBehaviour)this;

            ((TMonoBehaviour)this).DontDestroyOnLoad();

            return true;
        }
    }
}