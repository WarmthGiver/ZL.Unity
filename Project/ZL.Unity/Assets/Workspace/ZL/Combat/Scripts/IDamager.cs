using UnityEngine;

namespace ZL.Unity
{
    public interface IDamager
    {
        public void GiveDamage(IDamageable damageable, Vector3 contact);
    }
}