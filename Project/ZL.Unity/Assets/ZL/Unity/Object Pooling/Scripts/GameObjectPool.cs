using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    public class GameObjectPool : GameObjectPool<PooledGameObject> { }

    [Serializable]

    public class GameObjectPool<T> : ObjectPool<T>

        where T : PooledGameObject<T>
    {
        [SerializeField]

        protected T original;

        public T Original => original;

        [SerializeField, ReadOnlyInPlayMode]

        private Transform parent;

        public Transform Parent => parent;

        public T Generate(Transform transform)
        {
            var clone = Generate();

            clone.transform.SetPositionAndRotation(transform);

            return clone;
        }

        public override T Generate()
        {
            var clone = base.Generate();

            clone.gameObject.SetActive(true);

            return clone;
        }

        public override T Clone()
        {
            return PooledGameObject<T>.Clone(this);
        }
    }

    [Serializable]

    public sealed class ManagedGameObjectPool<T> : GameObjectPool<T>

        where T : PooledGameObject<T>
    {
        public readonly HashSet<T> clones = new();

        public override T Generate()
        {
            var clone = base.Generate();

            clones.Add(clone);

            return clone;
        }

        public void Recall()
        {
            foreach (var clone in clones)
            {
                clone.gameObject.SetActive(false);
            }

            clones.Clear();
        }
    }
}