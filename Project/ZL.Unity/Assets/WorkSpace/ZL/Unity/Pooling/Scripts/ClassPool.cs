namespace ZL.Unity.Pooling
{
    public static class ClassPool<TClass>

        where TClass : class, new()
    {
        private static readonly Pool pool = new();

        public static TClass Generate()
        {
            return pool.Generate();
        }

        public static TClass Replicate()
        {
            return pool.Replicate();
        }

        public static void Collect(TClass value)
        {
            pool.Collect(value);
        }

        private sealed class Pool : Pool<TClass>
        {
            public override TClass Replicate()
            {
                return new TClass();
            }
        }
    }
}