using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS;

namespace ZL.Unity
{
    [Serializable]

    public sealed class LoopList<T> : IList<T>
    {
        [SerializeField]

        private int index = 0;

        public int Index
        {
            get => index;

            set => index = value;
        }

        [SerializeField]

        private LoopPattern loopPattern = LoopPattern.Repeat;

        [SerializeField]

        private List<T> items = new List<T>();

        public int Count
        {
            get => items.Count;
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public T this[int index]
        {
            get => items[index];

            set => items[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public bool TryGetCurrent(out T current)
        {
            if (Count == 0)
            {
                current = default;

                return false;
            }

            current = items[index.Loop(0, Count - 1, loopPattern)];

            return true;
        }
    }
}