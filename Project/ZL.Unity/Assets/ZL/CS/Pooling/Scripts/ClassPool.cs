namespace ZL.CS.Pooling
{
    public static partial class ClassPool<TClass>

        where TClass : class, new()
    {
        private static readonly Pool pool = new();

        public static TClass Clone()
        {
            return pool.Clone();
        }

        public static TClass Replicate()
        {
            return pool.Instantiate();
        }

        public static void Collect(TClass value)
        {
            pool.Collect(value);
        }

        private sealed class Pool : Pool<TClass>
        {
            public override TClass Instantiate()
            {
                return new TClass();
            }
        }
    }
}