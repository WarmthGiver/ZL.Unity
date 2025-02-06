using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Position Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformPositionTweener : ComponentValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        private void Awake()
        {
            tweener = new(() => transform.position, value => transform.position = value);
        }
    }
}