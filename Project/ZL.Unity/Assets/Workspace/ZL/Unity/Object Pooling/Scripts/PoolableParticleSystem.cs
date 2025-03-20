using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Particle System (Poolable)")]

    [RequireComponent(typeof(ParticleSystem))]

    public sealed class PoolableParticleSystem : PoolablePlayable<ParticleSystem>
    {
        public override bool IsPlaying => @base.isPlaying;
    }
}