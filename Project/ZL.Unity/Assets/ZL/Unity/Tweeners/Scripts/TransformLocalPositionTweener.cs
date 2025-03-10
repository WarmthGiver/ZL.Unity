using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Local Position Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformLocalPositionTweener :
        
        ComponentValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        private void Awake()
        {
            tweener = new()
            {
                Getter = () => transform.localPosition,

                Setter = value => transform.localPosition = value,
            };
        }
    }
}