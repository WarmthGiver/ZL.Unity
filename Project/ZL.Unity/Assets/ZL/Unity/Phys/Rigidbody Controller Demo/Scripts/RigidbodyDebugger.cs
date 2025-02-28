#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Rigidbody Debugger")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody))]

    public sealed class RigidbodyDebugger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        

        [Margin]

        [ReadOnly(true)]

#pragma warning disable CS0108

        private Rigidbody rigidbody;

#pragma warning restore CS0108

        

        

        public int callbackOrder => 0;

        private void OnDrawGizmosSelected()
        {
            
        }

        
    }
}

#endif