using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

namespace ZL.EulerianTrail
{
    using ZL.ObjectPooling;

    [RequireComponent(typeof(Image))]

    public sealed class EulerianTrailNode : PooledGameObject<EulerianTrailNode>, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        [SerializeField, GetComponent, ReadOnly]

        private Image image;

        private EulerianTrail eulerianTrail;

        [Space]

        [SerializeField]

        private int number;

        public int Number => number;

        public Vector2 Point
        {
            get => transform.localPosition;

            set => transform.localPosition = value;
        }

        public float Thickness
        {
            set => rectTransform.sizeDelta = new(value, value);
        }

        public Color Color
        {
            set => image.color = value;
        }

        protected override void OnDisable()
        {
            Pool.Collect(this);
        }

        public void Initialize(EulerianTrail eulerianTrail, int nodeNumber)
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