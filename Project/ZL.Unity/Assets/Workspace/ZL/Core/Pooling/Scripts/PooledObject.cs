using System;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Pooling/Pooled Object")]

    public class PooledObject : MonoBehaviour
    {
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

        public virtual void OnAppeared() { }

        public virtual void Disappear()
        {
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