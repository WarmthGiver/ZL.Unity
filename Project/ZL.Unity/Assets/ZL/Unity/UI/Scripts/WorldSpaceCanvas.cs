using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/World Space Canvas")]

    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(Canvas))]

    public sealed class WorldSpaceCanvas : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private Canvas canvas;

        private void Awake()
        {
            canvas.worldCamera = Camera.main;
        }
    }
}