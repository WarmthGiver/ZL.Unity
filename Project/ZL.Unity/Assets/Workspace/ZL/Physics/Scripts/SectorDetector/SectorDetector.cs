using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Physics/Sector Detector")]

    public class SectorDetector : MonoBehaviour
    {
        [GetComponent]

        [Toggle(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Transform _transform;

        public new Transform transform
        {
            get => _transform;
        }

        [Space]

        [SerializeField]

        private float _radius = 1f;

        public float Radius
        {
            get => _radius;

            set
            {
                _radius = value;

                #if UNITY_EDITOR
                
                if (sectorGizmoDrawer != null)
                {
                    sectorGizmoDrawer.Radius = _radius;
                }

                #endif
            }
        }

        private float _oldRadius = 1f;

        private float _scale = 1f;

        public float Scale
        {
            set
            {
                _scale = value;

                #if UNITY_EDITOR
                
                if (sectorGizmoDrawer != null)
                {
                    sectorGizmoDrawer.Scale = _scale;
                }

                #endif
            }
        }

        private float _oldScale = 1f;

        private float _scaledRadius = 1f;

        protected float ScaledRadius
        {
            get
            {
                if (_oldRadius != _radius ||

                    _oldScale != _scale)
                {
                    _oldRadius = _radius;

                    _oldScale = _scale;

                    _scaledRadius = _radius * _scale;
                }

                return _scaledRadius;
            }
        }

        [Range(0f, 360f)]

        [SerializeField]

        protected float _angle = 60f;

        public virtual float Angle
        {
            get => _angle;

            set
            {
                _angle = value;

                cosHalfAngle = MathfEx.CosHalfAngle(_angle);

                #if UNITY_EDITOR

                if (sectorGizmoDrawer != null)
                {
                    sectorGizmoDrawer.Angle = _angle;
                }

                #endif
            }
        }

        private float cosHalfAngle;

        [Space]

        [SerializeField]

        protected LayerMask obstacleLayerMask = 0;

        [ToggleIf(nameof(obstacleLayerMask), 0, true)]

        [UsingCustomProperty]

        [SerializeField]

        private float rayHeight = 1f;

        public float RayHeight
        {
            set => rayHeight = value;
        }

        [ToggleIf(nameof(obstacleLayerMask), 0, true)]

        [UsingCustomProperty]

        [SerializeField]

        private bool drawObstacleRay = true;

        [ToggleIf(nameof(obstacleLayerMask), 0, true)]

        [UsingCustomProperty]

        [SerializeField]

        private Color obstacleRayColor = Color.red;

        protected static Ray ray = new Ray();

        #if UNITY_EDITOR

        [Space]

        [Require]

        [UsingCustomProperty]

        [SerializeField]

        protected SectorGizmoDrawer sectorGizmoDrawer = null;

        private void OnValidate()
        {
            if (sectorGizmoDrawer != null)
            {
                sectorGizmoDrawer.Radius = Radius;

                sectorGizmoDrawer.Angle = Angle;
            }
        }

        #endif

        protected virtual void Start()
        {
            Radius = Radius;

            Angle = Angle;
        }

        public bool DetectClosest<TComponent>(IList<TComponent> targets, int targetsCount, out TComponent closestTarget)

            where TComponent : Component
        {
            return DetectClosest(targets.GetEnumerator(targetsCount), out closestTarget);
        }

        public bool DetectClosest<TComponent>(IEnumerable<TComponent> targets, out TComponent closestTarget)

            where TComponent : Component
        {
            return DetectClosest(targets.GetEnumerator(), out closestTarget);
        }

        public bool DetectClosest<TComponent>(IEnumerator<TComponent> targets, out TComponent closestTarget)

            where TComponent : Component
        {
            closestTarget = null;

            if (enabled == false || targets == null)
            {
                return false;
            }

            float minDistance = float.MaxValue;

            while (targets.MoveNext())
            {
                var target = targets.Current;

                if (target == null)
                {
                    continue;
                }

                if (Detect(target, out var distance))
                {
                    if (minDistance > distance)
                    {
                        minDistance = distance;

                        closestTarget = target;
                    }
                }
            }

            if (closestTarget == null)
            {
                return false;
            }

            return true;
        }

        public bool Detect<TComponent>(TComponent target, out float distance)

            where TComponent : Component
        {
            if (enabled == false || target == null || !target.gameObject.activeSelf)
            {
                distance = 0f;

                return false;
            }

            var direction = Vector3Ex.Direction(transform.position, target.transform.position, Axis.Y);

            if (!Vector3Ex.CheckSector(transform.forward, direction, cosHalfAngle, ScaledRadius, out distance))
            {
                return false;
            }

            if (obstacleLayerMask != 0)
            {
                var rayOrigin = transform.position;

                rayOrigin.y += rayHeight;

                ray.origin = rayOrigin;

                ray.direction = direction;

                if (drawObstacleRay)
                {
                    FixedDebug.DrawRay(rayOrigin, direction, obstacleRayColor);
                }

                if (Physics.Raycast(ray, Mathf.Sqrt(distance), obstacleLayerMask))
                {
                    return false;
                }
            }

            return true;
        }
    }
}