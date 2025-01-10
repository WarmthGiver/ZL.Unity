using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pool/Audio Source Player (Pooled)")]

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