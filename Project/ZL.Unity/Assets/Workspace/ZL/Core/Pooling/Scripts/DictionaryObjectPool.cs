using System;

using System.Collections.Generic;

using System.Linq;

namespace ZL.Unity.Pooling
{
    [Serializable]

    public sealed class DictionaryObjectPool<TKey> : DictionaryObjectPool<TKey, PooledObject> { }

    [Serializable]

    public class DictionaryObjectPool<TKey, TPooledObject> : ObjectPool<TPooledObject>

        where TPooledObject : PooledObject
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

            clone = base.Clone();

            clones.Add(key, clone);

            return true;
        }

        public override void Collect(TPooledObject clone)
        {
            base.Collect(clone);

            foreach (var pair in clones)
            {
                if (pair.Value.Equals(clone) == true)
                {
                    clones.Remove(pair.Key);

                    break;
                }
            }
        }

        public void Collect(TKey key)
        {
            base.Collect(clones[key]);

            clones.Remove(key);
        }

        public void CollectAll()
        {
            foreach (var clone in clones.Values.ToArray())
            {
                clone.Disappear();
            }
        }

        public bool ContainsKey(TKey key)
        {
            return clones.ContainsKey(key);
        }
    }
}