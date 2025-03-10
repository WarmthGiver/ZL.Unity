using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Rotation Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformRotationTweener :
        
        ComponentValueTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        private void Awake()
        {
            tweener = new()
            {
                Getter = () => transform.rotation,

                Setter = value =>transform.rotation = value
            };
        }
    }
}