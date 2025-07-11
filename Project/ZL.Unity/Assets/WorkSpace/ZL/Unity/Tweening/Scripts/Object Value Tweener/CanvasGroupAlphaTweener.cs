using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Canvas Group Alpha Tweener")]

    public sealed class CanvasGroupAlphaTweener : ObjectValueTweener<FloatTweener, float, float, FloatOptions>
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private CanvasGroup canvasGroup = null;

        public override float Value
        {
            get => canvasGroup.alpha;
            
            set => canvasGroup.alpha = value;
        }
    }
}