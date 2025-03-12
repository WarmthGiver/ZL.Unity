using UnityEngine;

using ZL.Unity.Tweeners;

namespace ZL.Unity.UI
{
    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(RectTransformAnchoredPositionTweener))]

    public sealed class Toolbar : MonoBehaviour
    {
        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RectTransformAnchoredPositionTweener canvasGroupTweener;

        //[SerializeField, GetComponentInChildren, ReadOnlyAlways]

        //private GridLayoutGroup content = null;

        public void ToggleToolbar()
        {

        }
    }
}