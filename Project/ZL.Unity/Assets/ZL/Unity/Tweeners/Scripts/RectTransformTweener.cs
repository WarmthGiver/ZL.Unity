using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Rect Transform Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(RectTransform))]

    public sealed class RectTransformTweener : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RectTransform rectTransform;

        public Vector2Tweener AnchorPositionTweener { get; private set; }

        private void Awake()
        {
            AnchorPositionTweener = new()
            {
                Getter = () => rectTransform.anchoredPosition,
                
                Setter = value => rectTransform.anchoredPosition = value
            };
        }
    }
}