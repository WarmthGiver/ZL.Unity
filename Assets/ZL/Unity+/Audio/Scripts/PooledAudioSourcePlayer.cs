using UnityEngine;

namespace ZL.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pool/Audio Source Player (Pool)")]

    public sealed class PooledAudioSourcePlayer : MonoBehaviour
	{
		[Space]

		[SerializeField]

		private GameObjectPool<PooledAudioSource> pool;

		public void Play()
		{
            pool.Generate();
        }
	}
}