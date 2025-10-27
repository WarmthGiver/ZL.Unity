namespace ZL.CS.Collections
{
    public interface IKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }
    }
}