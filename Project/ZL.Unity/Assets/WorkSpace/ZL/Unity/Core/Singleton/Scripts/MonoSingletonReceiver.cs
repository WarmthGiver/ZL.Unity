using UnityEngine;

namespace ZL
{
    public abstract class MonoSingletonReceiver<TMonoSingleton> : MonoBehaviour

        where TMonoSingleton : MonoBehaviour, ISingleton<TMonoSingleton>
    {
        protected TMonoSingleton Target
        {
            get => ISingleton<TMonoSingleton>.Instance;
        }
    }
}