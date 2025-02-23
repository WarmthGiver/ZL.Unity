using UnityEngine;

using ZL.Unity.Tweeners;

namespace ZL.Unity.UI
{
    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(RectTransformTweener))]

    public sealed class Toolbar : MonoBehaviour
    {
        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RectTransformTweener canvasGroupTweener;

        //[SerializeField, GetComponentInChildren, ReadOnlyAlways]

        //private GridLayoutGroup content = null;

        public void ToggleToolbar()
        {

        }
    }
}