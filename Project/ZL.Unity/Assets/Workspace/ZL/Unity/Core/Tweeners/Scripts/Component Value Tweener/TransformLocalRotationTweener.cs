using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Local Rotation Tweener")]

    public sealed class TransformLocalRotationTweener : ComponentValueTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        protected override Quaternion Value
        {
            get => transform.localRotation;

            set => transform.localRotation = value;
        }
    }
}