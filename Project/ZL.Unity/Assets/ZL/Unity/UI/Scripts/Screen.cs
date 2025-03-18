using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Screen Window")]

    [DisallowMultipleComponent]

    public sealed class Screen : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInParent]

        private UIWindowManager playerCanvas;
    }
}