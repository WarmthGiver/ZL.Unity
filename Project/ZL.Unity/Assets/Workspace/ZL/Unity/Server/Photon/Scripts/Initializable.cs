namespace ZL.Unity
{
    public interface Initializable<T>

        where T : Initializable<T>
    {
        public abstract void Initialize<TInfo>(TInfo info) where TInfo : Info;

        public abstract class Info { }
    }
}