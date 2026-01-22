using DG.Tweening;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Rotation Tweener")]

    public sealed class RotationTweener : ObjectValueTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        [GetComponent]

        [Toggle(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Transform _transform;

        public new Transform transform
        {
            get => _transform;
        }

        public override Quaternion Value
        {
            get => transform.rotation;

            set => transform.rotation = value;
        }

        public void SetRotateMode(RotateMode rotateMode)
        {
            ValueTweener.SetRotateMode(rotateMode);
        }
    }
}