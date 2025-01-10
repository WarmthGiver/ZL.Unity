using ZL.Unity.ObjectPooling;

namespace ZL.Unity.UI
{
    public abstract class UIWindowContent<TPoolGameObject> : PooledGameObject<TPoolGameObject>

        where TPoolGameObject : PooledGameObject<TPoolGameObject>
    {
        public abstract void Refresh();
    }
}