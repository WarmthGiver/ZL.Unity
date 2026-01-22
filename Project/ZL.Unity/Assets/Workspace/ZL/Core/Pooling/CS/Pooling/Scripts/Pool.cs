using System.Collections.Generic;

namespace ZL.CS
{
    public interface IPool<TClass>

        where TClass : class
    {
        public Stack<TClass> Stack { get; }

        protected static TClass Pop(IPool<TClass> instance)
        {
            return instance.Pop();
        }

        TClass Pop()
        {
            if (Stack.Count != 0)
            {
                return Stack.Pop();
            }

            return Instantiate();
        }

        public TClass Instantiate();
    }

    public abstract class Pool<TClass> : IPool<TClass>

        where TClass : class
    {
        private readonly Stack<TClass> _stack = new();

        public Stack<TClass> Stack
        {
            get => _stack;
        }

        public virtual TClass Clone()
        {
            return IPool<TClass>.Pop(this);
        }

        public abstract TClass Instantiate();

        public virtual void Collect(TClass clone)
        {
            Stack.Push(clone);
        }
    }
}