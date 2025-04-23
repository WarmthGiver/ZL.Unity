namespace ZL
{
    public interface ISingleton<TClass>

        where TClass : class, ISingleton<TClass>
    {
        public static TClass Instance { get; protected set; } = null;

        protected static bool TrySetInstance(TClass instance)
        {
            return instance.TrySetInstance();
        }

        bool TrySetInstance()
        {
            if (IsDuplicated() == true)
            {
                return false;
            }

            Instance = (TClass)this;

            return true;
        }

        bool IsDuplicated()
        {
            if (Instance == null)
            {
                return false;
            }

            FixedDebug.LogWarning($"{typeof(TClass)} instance is duplicated.");

            return true;
        }

        protected static void Release(TClass instance)
        {
            if (Instance == instance)
            {
                Instance = null;
            }
        }
    }
}