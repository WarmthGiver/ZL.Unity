using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.Collections;

namespace ZL.EulerianTrail
{
    [Serializable]

    public sealed class EulerianTrailInfo
    {
        [SerializeField]

        private float nodeThickness = 90f;

        public float NodeThickness
        {
            get => nodeThickness;
        }

        [SerializeField]

        private float edgeThickness = 30f;

        public float EdgeThickness
        {
            get => edgeThickness;
        }

        [SerializeField]

        private float drawnEdgeThickness = 10f;

        public float DrawnEdgeThickness
        {
            get => drawnEdgeThickness;
        }

        [SerializeField]

        private Vector2[] nodePositions;

        public Vector2[] NodePositions
        {
            get => nodePositions;
        }

        [SerializeField]

        private int[][] edgeMap;

        public Segment<int>[] EdgeSegments { get; private set; }

        public EulerianTrailInfo(float nodeThickness, float edgeThickness, float drawnEdgeThickness, Vector2[] nodePositions, int[][] edgeMap) :
            
            this(nodePositions, edgeMap)
        {
            this.nodeThickness = nodeThickness;

            this.edgeThickness = edgeThickness;

            this.drawnEdgeThickness = drawnEdgeThickness;
        }

        public EulerianTrailInfo(Vector2[] nodePositions, int[][] edgeMap)
        {
            this.nodePositions = nodePositions;

            this.edgeMap = edgeMap;

            float column = edgeMap.Length;

            List<Segment<int>> edgeSegments = new();

            for (int j = 0; j < column; ++j)
            {
                float row = edgeMap[j].Length;

                for (int i = 0; i < row; ++i)
                {
                    edgeSegments.Add(new(j, edgeMap[j][i]));
                }
            }

            EdgeSegments = edgeSegments.ToArray();
        }
    }
}