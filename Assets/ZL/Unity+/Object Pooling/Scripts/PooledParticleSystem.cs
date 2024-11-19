using UnityEngine;

namespace ZL.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pool/Particle System (Pooled)")]

    [RequireComponent(typeof(ParticleSystem))]

    public sealed class PooledParticleSystem : PooledPlayable<PooledParticleSystem>
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private ParticleSystem @base;

        public override bool IsPlaying => @base.isPlaying;
    }
}