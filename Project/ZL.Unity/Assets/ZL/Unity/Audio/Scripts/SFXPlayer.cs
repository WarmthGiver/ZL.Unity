using UnityEngine;

using ZL.Unity.ObjectPooling;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/SFX Player")]

    public sealed class SFXPlayer : MonoBehaviour
	{
		[Space]

		[SerializeField]

		private GameObjectPool<PoolableAudioSource> pool;

		public void Play()
		{
            pool.Generate();
        }
	}
}