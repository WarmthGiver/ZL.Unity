using UnityEngine;

namespace ZL.Unity
{
    public abstract class Singleton<T> : MonoBehaviour

        where T : Singleton<T>
    {
        public static T Instance { get; private set; } = null;

        protected virtual void Awake()
        {
            TrySetInstance();
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        protected virtual bool TrySetInstance()
        {
            if (IsDuplicated() == true)
            {
                return false;
            }

            Instance = (T)this;

            return true;
        }

        protected virtual bool IsDuplicated()
        {
            if (Instance == null)
            {
                return false;
            }

            FixedDebug.LogWarning($"{typeof(T)} instance is duplicated.");

            return true;
        }
    }
}