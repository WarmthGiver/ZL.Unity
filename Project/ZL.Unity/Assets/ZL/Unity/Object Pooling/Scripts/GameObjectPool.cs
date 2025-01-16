using System;

using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [Serializable]

    public class GameObjectPool<T> : ObjectPool<T>

        where T : Component
    {
        [SerializeField]

        protected T original;

        public T Original => original;

        [SerializeField, ReadOnlyInPlayMode]

        private Transform parent;

        public Transform Parent => parent;

        public override T Generate()
        {
            var clone = base.Generate();

            clone.gameObject.SetActive(true);

            return clone;
        }

        public override T Clone()
        {
            return Pooler.Clone(this);
        }
    }
}