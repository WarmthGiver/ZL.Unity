using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Scale Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformScaleTweener :
        
        ComponentValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        private void Awake()
        {
            tweener = new()
            {
                Getter = () => transform.localScale,

                Setter = value => transform.localScale = value,
            };
        }
    }
}