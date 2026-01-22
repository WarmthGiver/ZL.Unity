#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UIElements;

namespace ZL.Unity
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 오직 디버깅 목적으로 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Sector Gizmo Drawer")]

    public sealed class SectorGizmoDrawer : HandleDrawer
    {
        [Range(0f, 360f)]

        [SerializeField]

        private float _angle = 60f;

        public float Angle
        {
            get => _angle;

            set => _angle = value;
        }

        [SerializeField]

        private float _radius = 1f;

        public float Radius
        {
            set => _radius = value;
        }

        private float _oldRadius = 1f;

        private float _scale = 1f;

        public float Scale
        {
            set => _scale = value;
        }

        private float _oldScale = 1f;

        private float _scaledRadius = 1f;

        private float ScaledRadius
        {
            get
            {
                if (_oldRadius != _radius || _oldScale != _scale)
                {
                    _oldRadius = _radius;

                    _oldScale = _scale;

                    _scaledRadius = _radius * _scale;
                }

                return _scaledRadius;
            }
        }

        protected override Matrix4x4 Matrix
        {
            get => Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        }

        protected override void DrawWireGizmos()
        {
            HandlesEx.DrawWireSector(Center, Angle, ScaledRadius);
        }

        protected override void DrawGizmos()
        {
            HandlesEx.DrawSector(Center, Angle, ScaledRadius);
        }
    }
}

#endif