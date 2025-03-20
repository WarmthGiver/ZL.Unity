using UnityEngine;

namespace ZL.Unity.Pooling
{
    public abstract class PoolablePlayable<T> : MonoBehaviour

        where T : Component
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        protected T @base;

        public T Base => @base;

        public abstract bool IsPlaying { get; }

        private void LateUpdate()
        {
            if (IsPlaying == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}