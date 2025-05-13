using System;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.EventSystems;

using ZL.Unity.Collections;

using ZL.Unity.Pooling;

using ZL.Unity.UI;

namespace ZL.Unity.EulerianTrail
{
    [AddComponentMenu("ZL/Eulerian Trail/Eulerian Trail Drawer")]

    public sealed class EulerianTrailDrawer : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private RectTransform rectTransform;

        [Space]

        [SerializeField]

        private ManagedObjectPool<Line2D> edgePool;

        [SerializeField]

        private ManagedObjectPool<EulerianTrailNode> nodePool;

        [SerializeField]

        private ManagedObjectPool<Line2D> drawnEdgePool;

        private readonly Dictionary<Segment<int>, bool> edgeVisiteds = new Dictionary<Segment<int>, bool>(new Segment<int>.EqualityComparer());

        private int visitedEdgeCount;

        private static EulerianTrailNode lastVisitedNode;

        private static Line2D drawingEdge;

        public EulerianTrailInfo Info { get; private set; }

        private Action actionOnEnd;

        public void Initialize(EulerianTrailInfo info, Action actionOnEnd = null)
        {
            Info = info;

            this.actionOnEnd = actionOnEnd;

            edgePool.CollectAll();

            nodePool.CollectAll();

            drawnEdgePool.CollectAll();

            edgeVisiteds.Clear();

            visitedEdgeCount = 0;

            foreach (var edgeSegment in Info.EdgeSegments)
            {
                var edge = edgePool.Generate();

                edge.StartPoint = Info.NodePositions[edgeSegment.Start];

                edge.EndPoint = Info.NodePositions[edgeSegment.End];

                edge.Thickness = Info.EdgeThickness;

                edge.gameObject.SetActive(true);

                edgeVisiteds.Add(edgeSegment, false);
            }

            for (int nodeNumber = Info.NodePositions.Length - 1; nodeNumber >= 0; --nodeNumber)
            {
                var node = nodePool.Generate();

                node.Initialize(this, nodeNumber);

                node.Point = Info.NodePositions[nodeNumber];

                node.Thickness = Info.NodeThickness;

                node.gameObject.SetActive(true);
            }
        }

        public void StartDrawing(EulerianTrailNode node, PointerEventData eventData)
        {
            ClearDrawing();

            lastVisitedNode = node;

            drawingEdge = drawnEdgePool.Generate();

            drawingEdge.StartPoint = node.transform.localPosition;

            if (eventData.TryGetLocalPoint(rectTransform, out var localPoint) == true)
            {
                drawingEdge.EndPoint = localPoint;
            }

            else
            {
                drawingEdge.EndPoint = drawingEdge.StartPoint;
            }
            
            drawingEdge.Thickness = Info.DrawnEdgeThickness;

            drawingEdge.gameObject.SetActive(true);
        }

        public void StopDrawing()
        {
            lastVisitedNode = null;

            drawingEdge.SetActive(false);

            drawingEdge = null;

            if (visitedEdgeCount == Info.EdgeSegments.Length)
            {
                actionOnEnd?.Invoke();
            }

            else
            {
                ClearDrawing();
            }
        }

        public void ClearDrawing()
        {
            drawnEdgePool.CollectAll();

            foreach (var edgeSegment in Info.EdgeSegments)
            {
                edgeVisiteds[edgeSegment] = false;
            }

            visitedEdgeCount = 0;
        }

        public void VisitNode(EulerianTrailNode node)
        {
            if (lastVisitedNode != null)
            {
                var edgeSegment = new Segment<int>(lastVisitedNode.Number, node.Number);

                if (edgeVisiteds.ContainsKey(edgeSegment) == true && edgeVisiteds[edgeSegment] == false)
                {
                    edgeVisiteds[edgeSegment] = true;

                    ++visitedEdgeCount;

                    lastVisitedNode = node;

                    drawingEdge.EndPoint = node.transform.localPosition;

                    drawingEdge = drawnEdgePool.Generate();

                    drawingEdge.StartPoint = node.transform.localPosition;

                    drawingEdge.Thickness = Info.DrawnEdgeThickness;

                    drawingEdge.gameObject.SetActive(true);
                }
            }
        }

        public void DragEdge(PointerEventData eventData)
        {
            if (drawingEdge == null)
            {
                return;
            }

            if (eventData.TryGetLocalPoint(rectTransform, out var localPoint) == true)
            {
                drawingEdge.EndPoint = localPoint;
            }
        }
    }
}