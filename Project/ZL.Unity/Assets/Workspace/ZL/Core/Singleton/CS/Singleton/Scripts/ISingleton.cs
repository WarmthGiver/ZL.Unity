namespace ZL.CS
{
    public interface ISingleton<TClass>

        where TClass : class, ISingleton<TClass>
    {
        static TClass Instance { get; protected set; } = null;

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

            return true;
        }

        public static void Release(TClass instance)
        {
            instance.Release();
        }

        void Release()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}