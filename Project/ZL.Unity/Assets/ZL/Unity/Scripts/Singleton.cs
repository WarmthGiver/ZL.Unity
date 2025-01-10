using UnityEngine;

namespace ZL.Unity
{
    public abstract class Singleton<T> : MonoBehaviour
        
        where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        [Space]

        [SerializeField]

        private bool dontDestroy = true;

        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;

                if (dontDestroy == true)
                {
                    DontDestroyOnLoad(gameObject);
                }

                OnAwake();

                return;
            }

            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        protected abstract void OnAwake();
    }
}