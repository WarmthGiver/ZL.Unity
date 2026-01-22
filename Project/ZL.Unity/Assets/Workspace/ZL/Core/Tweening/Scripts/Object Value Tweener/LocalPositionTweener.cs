using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Local Position Tweener")]

    public sealed class LocalPositionTweener : ObjectValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
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

        public override Vector3 Value
        {
            get => transform.localPosition;

            set => transform.localPosition = value;
        }
    }
}