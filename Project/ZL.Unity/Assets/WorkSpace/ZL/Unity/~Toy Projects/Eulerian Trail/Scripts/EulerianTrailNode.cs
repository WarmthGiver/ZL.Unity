using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

namespace ZL.Unity.EulerianTrail
{
    [AddComponentMenu("ZL/Eulerian Trail/Eulerian Trail Node")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Image))]

    public sealed class EulerianTrailNode : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private RectTransform rectTransform;

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private Image image;

        private EulerianTrailDrawer eulerianTrail;

        [Space]

        [SerializeField]

        private int number;

        public int Number
        {
            get => number;
        }

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

        public void Initialize(EulerianTrailDrawer eulerianTrail, int nodeNumber)
        {
            this.eulerianTrail = eulerianTrail;

            number = nodeNumber;
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