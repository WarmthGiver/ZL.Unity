using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("")]

    [DefaultExecutionOrder(-2)]

    [DisallowMultipleComponent]

    public abstract class MonoSingleton<TMonoSingleton> :
        
        MonoBehaviour, IMonoSingleton<TMonoSingleton>

        where TMonoSingleton : MonoSingleton<TMonoSingleton>
    {
        protected virtual void Awake()
        {
            IMonoSingleton<TMonoSingleton>.TrySetInstance((TMonoSingleton)this);
        }

        protected virtual void OnDestroy()
        {
            IMonoSingleton<TMonoSingleton>.Release((TMonoSingleton)this);
        }

        bool ISingleton<TMonoSingleton>.IsDuplicated()
        {
            if (ISingleton<TMonoSingleton>.Instance == null)
            {
                return false;
            }

            return true;
        }
    }
}