namespace ZL.Unity
{
    public sealed class ManagedData<TInstance, TData> : IManagedData
        
        where TInstance : class
        
        where TData : class, IData<TInstance>, new()
    {
        private readonly TInstance instance;

        private readonly TData data = new TData();

        public ManagedData(TInstance instance)
        {
            this.instance = instance;
        }

        public void Save()
        {
            data.Save(instance);
        }

        public void Load()
        {
            data.Load(instance);
        }
    }
}