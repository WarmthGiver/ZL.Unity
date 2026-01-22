using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Physics/Meshed Sector Detector")]

    public sealed class MeshedSectorDetector : SectorDetector
    {
        public override float Angle
        {
            set
            {
                base.Angle = value;

                startAngle = -_angle * 0.5f;

                angleStep = _angle / rayCount;
            }
        }

        private float startAngle;

        private float angleStep;

        [Line]

        [Require]

        [UsingCustomProperty]

        [SerializeField]

        private MeshFilter meshFilter = null;

        [Require]

        [UsingCustomProperty]

        [SerializeField]

        private MeshRenderer meshRenderer = null;

        public MeshRenderer MeshRenderer
        {
            get => meshRenderer;
        }

        [Space]

        [Min(1)]

        [SerializeField]

        private int rayCount = 128;

        private Mesh mesh;

        private static readonly List<Vector3> vertices = new List<Vector3>();

        private static readonly List<int> triangles = new List<int>();

        protected override void Start()
        {
            base.Start();

            mesh = new Mesh()
            {
                name = "Sector",

                hideFlags = HideFlags.DontSave,
            };
        }

        private void LateUpdate()
        {
            vertices.Clear();

            vertices.Add(Vector3.zero);

            triangles.Clear();

            ray.origin = transform.position;

            var radius = ScaledRadius;

            for (int i = 0; i <= rayCount; ++i)
            {
                float angle = (startAngle + angleStep * i) * Mathf.Deg2Rad;

                var direction = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle));

                direction = transform.TransformDirection(direction);

                ray.direction = direction;

                if (Physics.Raycast(ray, out var hit, radius, obstacleLayerMask))
                {
                    vertices.Add(transform.InverseTransformPoint(hit.point));
                }

                else
                {
                    vertices.Add(transform.InverseTransformPoint(transform.position + direction * radius));
                }

                if (i > 0)
                {
                    triangles.Add(0);

                    triangles.Add(i);

                    triangles.Add(i + 1);
                }
            }

            mesh.Clear();

            mesh.vertices = vertices.ToArray();

            mesh.triangles = triangles.ToArray();

            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;
        }
    }
}