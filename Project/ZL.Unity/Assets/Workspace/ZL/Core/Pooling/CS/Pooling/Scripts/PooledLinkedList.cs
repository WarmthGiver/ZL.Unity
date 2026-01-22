using System.Collections;

using System.Collections.Generic;

using ZL.CS;

namespace ZL.Unity
{
    public sealed class PooledLinkedList<T> : LinkedList<T>, IPool<LinkedListNode<T>>
    {
        private readonly Stack<LinkedListNode<T>> _stack = new Stack<LinkedListNode<T>>();

        public Stack<LinkedListNode<T>> Stack
        {
            get => _stack;
        }

        public new void AddFirst(T value)
        {
            var node = IPool<LinkedListNode<T>>.Pop(this);

            node.Value = value;

            AddFirst(node);
        }

        public new void AddLast(T value)
        {
            var node = IPool<LinkedListNode<T>>.Pop(this);

            node.Value = value;

            AddLast(node);
        }

        public LinkedListNode<T> Instantiate()
        {
            return new LinkedListNode<T>(default);
        }

        public new void Clear()
        {
            var node = First;

            while (node != null)
            {
                var next = node.Next;

                Stack.Push(node);

                node = next;
            }

            base.Clear();
        }

        public new void RemoveFirst()
        {
            Remove(First);
        }

        public new void RemoveLast()
        {
            Remove(Last);
        }

        public new void Remove(T value)
        {
            var node = Find(value);

            Remove(node);
        }

        public new void Remove(LinkedListNode<T> node)
        {
            Stack.Push(node);

            base.Remove(node);
        }
    }
}