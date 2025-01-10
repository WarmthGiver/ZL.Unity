using System.Collections.Generic;

namespace ZL.Unity.ObjectPooling
{
    public abstract class ObjectPool<T>

        where T : class
    {
        private readonly LinkedList<T> stock = new();

        public void PreGenerate(int count)
        {
            while (count-- > 0)
            {
                stock.AddLast(Clone());
            }
        }

        public virtual T Generate()
        {
            if (stock.Count == 0)
            {
                return Clone();
            }

            return stock.PopLast();
        }

        public abstract T Clone();

        public virtual void Collect(T value)
        {
            stock.AddLast(value);
        }

        public void Remove(T value)
        {
            stock.Remove(value);
        }
    }

    public static class LinkedListExtentions
    {
        public static T PopFirst<T>(this LinkedList<T> instance)
        {
            T value = instance.First.Value;

            instance.RemoveFirst();

            return value;
        }

        public static T PopLast<T>(this LinkedList<T> instance)
        {
            T value = instance.Last.Value;

            instance.RemoveLast();

            return value;
        }
    }
}