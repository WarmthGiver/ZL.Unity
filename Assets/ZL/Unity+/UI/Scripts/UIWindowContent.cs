namespace ZL.UI
{
    using ZL.ObjectPooling;

    public abstract class UIWindowContent<TPoolGameObject> : PooledGameObject<TPoolGameObject>

        where TPoolGameObject : PooledGameObject<TPoolGameObject>
    {
        public abstract void Refresh();
    }
}