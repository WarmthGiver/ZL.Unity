using System.Collections.Generic;

using ZL.Unity.Collections;

namespace ZL.Unity.Pooling
{
    public abstract class Pool<TClass>

        where TClass : class
    {
        private readonly LinkedList<TClass> stock = new();

        public virtual TClass Generate()
        {
            if (stock.Count == 0)
            {
                return Replicate();
            }

            return stock.PopLast();
        }

        public abstract TClass Replicate();

        public virtual void Collect(TClass replica)
        {
            stock.AddLast(replica);
        }

        public void Release(TClass replica)
        {
            stock.Remove(replica);
        }
    }
}