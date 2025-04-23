using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Canvas Group Alpha Tweener")]

    [RequireComponent(typeof(CanvasGroup))]

    public class CanvasGroupAlphaTweener : ComponentValueTweener<FloatTweener, float, float, FloatOptions>
    {
        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [EmptyField]

        protected CanvasGroup canvasGroup;

        protected override float Value
        {
            get => canvasGroup.alpha;
            
            set => canvasGroup.alpha = value;
        }
    }
}