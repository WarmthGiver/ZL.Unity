using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Canvas Group Alpha Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroup))]

    public sealed class CanvasGroupAlphaTweener :
        
        ComponentValueTweener<FloatTweener, float, float, FloatOptions>
    {
        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [Toggle(true)]

        private CanvasGroup canvasGroup;

        private void Awake()
        {
            tweener = new()
            {
                Getter = () => canvasGroup.alpha,
                
                Setter = value => canvasGroup.alpha = value
            };
        }
    }
}