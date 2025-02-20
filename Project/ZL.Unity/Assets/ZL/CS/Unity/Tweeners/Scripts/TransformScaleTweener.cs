using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.CS.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Scale Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformScaleTweener : ComponentValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        private void Awake()
        {
            tweener = new(() => transform.localScale, value => transform.localScale = value);
        }
    }
}