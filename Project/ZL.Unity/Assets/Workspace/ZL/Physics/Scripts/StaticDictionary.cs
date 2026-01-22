using System.Collections.Generic;

namespace ZL.Unity
{
    public static class StaticDictionary<TKey, TValue>
    {
        private static readonly Dictionary<TKey, TValue> table = new Dictionary<TKey, TValue>();

        public static void Add(TKey key, TValue value)
        {
            table[key] = value;
        }

        public static void Remove(TKey key)
        {
            table.Remove(key);
        }

        public static bool Get(TKey key, out TValue value)
        {
            return table.TryGetValue(key, out value);
        }
    }
}