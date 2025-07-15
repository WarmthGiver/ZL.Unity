using System.Collections.Generic;

namespace ZL.CS.Pooling
{
    public abstract class Pool<TClass>

        where TClass : class
    {
        protected readonly Stack<TClass> collection = new();

        public virtual TClass Clone()
        {
            if (collection.Count != 0)
            {
                return collection.Pop();
            }

            return Instantiate();
        }

        public abstract TClass Instantiate();

        public virtual void Collect(TClass clone)
        {
            collection.Push(clone);
        }
    }
}