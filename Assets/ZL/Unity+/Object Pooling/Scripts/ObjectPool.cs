using System.Collections.Generic;

namespace ZL.ObjectPooling
{
    public abstract class ObjectPool<T>

        where T : class
    {
        private readonly Stack<T> stock = new();

        public void PreGenerate(int count)
        {
            while (count-- > 0)
            {
                stock.Push(Clone());
            }
        }

        public virtual T Generate()
        {
            if (stock.Count == 0)
            {
                return Clone();
            }

            return stock.Pop();
        }

        public abstract T Clone();

        public virtual void Collect(T clone)
        {
            stock.Push(clone);
        }
    }
}