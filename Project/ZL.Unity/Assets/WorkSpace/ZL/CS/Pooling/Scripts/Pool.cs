using System.Collections.Generic;

using ZL.CS.Collections;

namespace ZL.CS.Pooling
{
    public abstract class Pool<TClass>

        where TClass : class
    {
        protected readonly LinkedList<TClass> stock = new LinkedList<TClass>();

        public virtual TClass Generate()
        {
            if (stock.Count != 0)
            {
                return stock.PopLast();
            }

            return Replicate();
        }

        public abstract TClass Replicate();

        public virtual void Collect(TClass replica)
        {
            stock.AddLast(replica);
        }
    }
}