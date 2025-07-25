using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Anchored Position Tweener")]

    public sealed class AnchoredPositionTweener : ObjectValueTweener<Vector2Tweener, Vector2, Vector2, VectorOptions>
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private RectTransform rectTransform = null;

        public override Vector2 Value
        {
            get => rectTransform.anchoredPosition;

            set => rectTransform.anchoredPosition = value;
        }
    }
}