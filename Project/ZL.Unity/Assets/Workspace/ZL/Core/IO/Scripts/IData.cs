namespace ZL.Unity
{
    public interface IData<TInstance>

        where TInstance : class
    {
        public void Save(TInstance instance);

        public void Load(TInstance instance);
    }
}