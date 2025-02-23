using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Local Rotation Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformLocalRotationTweener : ComponentValueTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        private void Awake()
        {
            tweener = new(() => transform.localRotation, value => transform.localRotation = value);
        }
    }
}