using UnityEngine;

namespace ZL.Unity
{
    public abstract class GizmoDrawer : MonoBehaviour
    {
        #if UNITY_EDITOR

        [GetComponent]

        [Toggle(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Transform _transform;

        public new Transform transform
        {
            private set => _transform = value;

            get => _transform;
        }

        [Space]

        [SerializeField]

        private bool disableOnAwake = false;

        [SerializeField]

        private bool drawOnSelected = false;

        [SerializeField]

        private bool isWire = true;

        [Space]

        [SerializeField]

        private Color _color = new Color(1f, 1f, 1f, 1f);

        public Color Color
        {
            get => _color;

            set => _color = value;
        }

        private Vector3 _center = Vector3.zero;

        public Vector3 Center
        {
            get => _center;

            set => _center = value;
        }

        protected virtual Matrix4x4 Matrix
        {
            get => Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        }

        private void Reset()
        {
            transform = base.transform;
        }

        private void OnDrawGizmos()
        {
            if (!drawOnSelected)
            {
                Draw();
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (drawOnSelected)
            {
                Draw();
            }
        }

        private void Awake()
        {
            if (disableOnAwake)
            {
                enabled = false;
            }
        }

        private void Draw()
        {
            SetupGizmos();

            if (isWire)
            {
                DrawWireGizmos();
            }

            else
            {
                DrawGizmos();
            }
        }

        protected virtual void SetupGizmos()
        {
            Gizmos.color = Color;

            Gizmos.matrix = Matrix;
        }

        protected abstract void DrawWireGizmos();

        protected abstract void DrawGizmos();

        #endif
    }
}