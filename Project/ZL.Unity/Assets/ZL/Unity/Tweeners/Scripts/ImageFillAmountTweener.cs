using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Image Fill Amount Tweener")]

    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(Image))]

    public sealed class ImageFillAmountTweener : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private Image image;

        public FloatTweener FillAmountTweener { get; private set; }

        private void Awake()
        {
            FillAmountTweener = new()
            {
                Getter = () => image.fillAmount,
                
                Setter = value => image.fillAmount = value
            };
        }
    }
}