﻿using System;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.EulerianTrail
{
    using ZL.Collections;

    using ZL.ObjectPooling;

    using ZL.UI;

    [DisallowMultipleComponent]

    public sealed class EulerianTrail : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        [Space]

        [SerializeField]

        private ManagedGameObjectPool<Line2D> edgePool;

        [SerializeField]

        private ManagedGameObjectPool<EulerianTrailNode> nodePool;

        [SerializeField]

        private ManagedGameObjectPool<Line2D> drawnEdgePool;

        private readonly Dictionary<Segment<int>, bool> edgeVisiteds = new(new Segment<int>.EqualityComparer());

        private int visitedEdgeCount;

        private static EulerianTrailNode lastVisitedNode;

        private static Line2D drawingEdge;

        public EulerianTrailInfo Info { get; private set; }

        private Action actionOnEnd;

        public void Initialize(EulerianTrailInfo info, Action actionOnEnd = null)
        {
            Info = info;

            this.actionOnEnd = actionOnEnd;

            edgePool.Recall();

            nodePool.Recall();

            drawnEdgePool.Recall();

            edgeVisiteds.Clear();

            visitedEdgeCount = 0;

            foreach (var edgeSegment in Info.EdgeSegments)
            {
                var edge = edgePool.Generate();

                edge.StartPoint = Info.NodePositions[edgeSegment.Start];

                edge.EndPoint = Info.NodePositions[edgeSegment.End];

                edge.Thickness = Info.EdgeThickness;

                edgeVisiteds.Add(edgeSegment, false);
            }

            for (int nodeNumber = Info.NodePositions.Length - 1; nodeNumber >= 0; --nodeNumber)
            {
                var node = nodePool.Generate();

                node.Initialize(this, nodeNumber);

                node.Point = Info.NodePositions[nodeNumber];

                node.Thickness = Info.NodeThickness;
            }
        }

        public void StartDrawing(EulerianTrailNode node, PointerEventData eventData)
        {
            ClearDrawing();

            lastVisitedNode = node;

            drawingEdge = drawnEdgePool.Generate();

            drawingEdge.StartPoint = node.transform.localPosition;

            drawingEdge.EndPoint = eventData.LocalPosition(rectTransform);

            drawingEdge.Thickness = Info.DrawnEdgeThickness;
        }

        public void StopDrawing()
        {
            lastVisitedNode = null;

            drawingEdge.ReturnToPool();

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
            drawnEdgePool.Recall();

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
                Segment<int> edgeSegment = new(lastVisitedNode.Number, node.Number);

                if (edgeVisiteds.ContainsKey(edgeSegment) && !edgeVisiteds[edgeSegment])
                {
                    edgeVisiteds[edgeSegment] = true;

                    ++visitedEdgeCount;

                    lastVisitedNode = node;

                    drawingEdge.EndPoint = node.transform.localPosition;

                    drawingEdge = drawnEdgePool.Generate();

                    drawingEdge.StartPoint = node.transform.localPosition;

                    drawingEdge.Thickness = Info.DrawnEdgeThickness;
                }
            }
        }

        public void DragEdge(PointerEventData eventData)
        {
            if (drawingEdge != null)
            {
                drawingEdge.EndPoint = eventData.LocalPosition(rectTransform);
            }
        }
    }
}