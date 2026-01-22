using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Transform Billboarder")]

    public sealed class TransformBillboarder : MonoBehaviour
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

        [ToggleIf(nameof(target), null, false)]

        [WarningBox("If the target is null, set the main camera as the target.")]

        [Toggle(false)]

        [UsingCustomProperty]

        [SerializeField]

        private Transform target = null;

        public Transform Target
        {
            set => target = value;
        }

        private void Reset()
        {
            target = Camera.main.transform;
        }

        private void LateUpdate()
        {
            if (target == null)
            {
                //target = MainCamera.Instance.transform;

                target = Camera.main.transform;
            }

            transform.LookAt(transform.position + target.rotation * Vector3.forward, target.rotation * Vector3.up);
        }
    }
}
