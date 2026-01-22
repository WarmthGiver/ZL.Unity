using System;

using System.Collections.Generic;

using System.Linq;

namespace ZL.Unity
{
    [Serializable]

    public sealed class HashSetObjectPool : HashSetObjectPool<PooledObject> { }
    
    [Serializable]

    public class HashSetObjectPool<TPooledObject> : ObjectPool<TPooledObject>

        where TPooledObject : PooledObject
    {
        private readonly HashSet<TPooledObject> clones = new();

        public HashSet<TPooledObject> Clones
        {
            get => clones;
        }

        public override TPooledObject Clone()
        {
            var clone = base.Clone();

            clones.Add(clone);

            return clone;
        }

        public override void Collect(TPooledObject clone)
        {
            clones.Remove(clone);

            base.Collect(clone);
        }

        public void CollectAll()
        {
            foreach (var clone in clones.ToArray())
            {
                clone.Disappear();
            }
        }
    }
}