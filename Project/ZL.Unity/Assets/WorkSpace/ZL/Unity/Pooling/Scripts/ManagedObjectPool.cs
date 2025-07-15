using System;

using System.Collections.Generic;

using System.Linq;

namespace ZL.Unity.Pooling
{
    [Serializable]

    public sealed class ManagedObjectPool<TKey> : ManagedObjectPool<TKey, ManagedPooledObject<TKey>> { }

    [Serializable]

    public class ManagedObjectPool<TKey, TPooledObject> : ObjectPool<TPooledObject>

        where TPooledObject : ManagedPooledObject<TKey>
    {
        private readonly Dictionary<TKey, TPooledObject> clones = new();

        public TPooledObject this[TKey key]
        {
            get => clones[key];
        }

        public bool TryClone(TKey key, out TPooledObject clone)
        {
            if (clones.ContainsKey(key) == true)
            {
                clone = clones[key];

                return false;
            }

            clone = Clone();

            clone.Key = key;

            clones.Add(key, clone);

            return true;
        }

        public override void Collect(TPooledObject clone)
        {
            base.Collect(clone);

            clones.Remove(clone.Key);
        }

        public void CollectAll()
        {
            foreach (var clone in clones.Values.ToArray())
            {
                clone.Disappear();
            }
        }
    }
}