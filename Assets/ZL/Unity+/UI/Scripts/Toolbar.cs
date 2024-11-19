using UnityEngine;

using UnityEngine.UI;

namespace ZL.UI
{
    using ZL.Tweeners;

    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(RectTransformTweener))]

    public sealed class Toolbar : MonoBehaviour
    {
        [SerializeField, GetComponent, ReadOnly]

        private RectTransformTweener canvasGroupTweener;

        //[SerializeField, GetComponentInChildren, ReadOnlyAlways]

        //private GridLayoutGroup content = null;

        public void ToggleToolbar()
        {

        }
    }
}