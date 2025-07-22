using System;

using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Pooled Object")]

    public class PooledObject : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private float lifeTime = -1f;

        public float LifeTime
        {
            set => lifeTime = value;
        }

        private event Action OnDisableAction = null;

        public event Action OnDisappearedAction = null;

        public static TPooledObject Instantiate<TPooledObject>(ObjectPool<TPooledObject> objectPool)

            where TPooledObject : PooledObject
        {
            var clone = Instantiate(objectPool.Prefab, objectPool.Parent);

            clone.OnDisableAction += () => objectPool.Collect(clone);

            return clone;
        }

        public virtual void Appear()
        {
            gameObject.SetActive(true);

            OnAppeared();
        }

        public virtual void OnAppeared()
        {
            if (lifeTime != -1f)
            {
                Invoke(nameof(Disappear), lifeTime);
            }
        }

        public virtual void Disappear()
        {
            CancelInvoke(nameof(Disappear));

            OnDisappeared();
        }

        public virtual void OnDisappeared()
        {
            if (OnDisappearedAction != null)
            {
                OnDisappearedAction.Invoke();

                OnDisappearedAction = null;
            }

            gameObject.SetActive(false);

            OnDisableAction?.Invoke();
        }
    }
}