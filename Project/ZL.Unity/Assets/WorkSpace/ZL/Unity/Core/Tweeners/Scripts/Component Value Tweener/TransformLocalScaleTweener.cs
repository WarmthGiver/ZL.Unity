using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Local Scale Tweener")]

    public sealed class TransformLocalScaleTweener : ComponentValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        protected override Vector3 Value
        {
            get => transform.localScale;
            
            set => transform.localScale = value;
        }
    }
}