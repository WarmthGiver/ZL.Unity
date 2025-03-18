using TMPro;

using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Popup Window")]

    [DisallowMultipleComponent]

    public sealed class PopupWindow : WindowUGUI, IPointerDownHandler
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInParent]

        private UIWindowManager playerCanvas;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private CanvasGroupAnimation canvasGroupAnimation;

        [SerializeField]

        private TextMeshProUGUI headerText;

        [SerializeField]

        private Button closeButton;

        [Space]

        [SerializeField]

        private ScrollRect contentArea;

        [SerializeField]

        private Transform content;

        [Space]

        [SerializeField]

        private GridLayoutGroup buttonArea;

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }
    }
}