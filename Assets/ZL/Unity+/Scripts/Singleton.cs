using UnityEngine;

namespace ZL
{
    [DisallowMultipleComponent]

    public abstract class Singleton<TComponent> : MonoBehaviour

        where TComponent : Singleton<TComponent>
    {
        public static TComponent Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = (TComponent)this;
        }
    }
}