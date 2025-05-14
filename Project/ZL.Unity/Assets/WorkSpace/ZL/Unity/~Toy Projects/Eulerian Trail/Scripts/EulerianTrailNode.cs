using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

namespace ZL.Unity.EulerianTrail
{
    [AddComponentMenu("ZL/Eulerian Trail/Eulerian Trail Node")]

    public sealed class EulerianTrailNode : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private RectTransform rectTransform = null;

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        private Image image = null;

        public int Number { get; private set; } = 0;

        public Vector2 Point
        {
            get => transform.localPosition;

            set => transform.localPosition = value;
        }

        public float Thickness
        {
            set => rectTransform.sizeDelta = new Vector2(value, value);
        }

        public Color Color
        {
            set => image.color = value;
        }

        private EulerianTrailDrawer eulerianTrail = null;

        public void Initialize(EulerianTrailDrawer eulerianTrail, int nodeNumber)
        {
            this.eulerianTrail = eulerianTrail;

            Number = nodeNumber;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            eulerianTrail.VisitNode(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            eulerianTrail.StartDrawing(this, eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            eulerianTrail.StopDrawing();
        }

        public void OnDrag(PointerEventData eventData)
        {
            eulerianTrail.DragEdge(eventData);
        }
    }
}