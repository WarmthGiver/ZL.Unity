namespace ZL.Unity
{
    public abstract class Immortal<T> : Singleton<T>
        
        where T : Immortal<T>
    {
        protected override bool TrySetInstance()
        {
            if (base.TrySetInstance() == false)
            {
                Destroy(gameObject);

                return false;
            }

            DontDestroyOnLoad(gameObject);

            return true;
        }
    }
}