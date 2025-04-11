using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("")]

    [DefaultExecutionOrder(-1)]

    [DisallowMultipleComponent]

    public abstract class Singleton<TSingleton> :

        MonoBehaviour, ISingleton<TSingleton>

        where TSingleton : Singleton<TSingleton>
    {
        protected virtual void Awake()
        {
            ISingleton<TSingleton>.TrySetInstance((TSingleton)this);
        }

        protected virtual void OnDestroy()
        {
            ISingleton<TSingleton>.Release((TSingleton)this);
        }
    }
}