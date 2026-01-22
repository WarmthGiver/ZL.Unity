using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Position Tweener")]

    public sealed class PositionTweener : ObjectValueTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
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
            get => transform.position;
            
            set => transform.position = value;
        }
    }
}