namespace ZL.Unity.ObjectPooling
{
    public abstract class PooledPlayable<T> : PooledGameObject<T>

        where T : PooledPlayable<T>
    {
        public abstract bool IsPlaying { get; }

        private void LateUpdate()
        {
            if (IsPlaying == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}