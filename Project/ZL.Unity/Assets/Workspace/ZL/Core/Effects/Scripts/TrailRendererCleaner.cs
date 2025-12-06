using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Effects/Trail Renderer Cleaner")]

    public sealed class TrailRendererCleaner : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private TrailRenderer trailRenderer = null;

        private void OnDisable()
        {
            trailRenderer.Clear();
        }
    }
}