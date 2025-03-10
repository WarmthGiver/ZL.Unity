namespace ZL.Unity
{
    public interface ISingleton<T>

        where T : class, ISingleton<T>
    {
        public static T Instance { get; private set; } = null;

        protected static bool TrySetInstance(T instance)
        {
            if (instance.IsDuplicated() == true)
            {
                return false;
            }

            Instance = instance;

            return true;
        }

        protected static void OnDestroy(T instance)
        {
            if (Instance == instance)
            {
                Instance = null;
            }
        }

        bool IsDuplicated()
        {
            if (Instance == null)
            {
                return false;
            }

            FixedDebug.LogWarning($"{typeof(T)} instance is duplicated.");

            return true;
        }
    }
}