using System;

using TMPro;

using UnityEngine;

namespace ZL.Unity.UI
{
    public sealed class TransformController : MonoBehaviour
    {
        public static TransformController Instance { get; private set; }

        [Serializable]

        private class Contect
        {
            [SerializeField]

            private TMP_Text valueText = null;

            [SerializeField]

            private AutoButton increaseValueButton = null;

            public AutoButton IncreaseValueButton => increaseValueButton;

            [SerializeField]

            private AutoButton decreaseValueButton = null;

            public AutoButton DecreaseValueButton => decreaseValueButton;

            public string ValueTextFormat { get; set; }

            private float value;

            public float Value
            {
                get => value;

                set
                {
                    this.value = value;

                    Refresh();
                }
            }

            public void Refresh()
            {
                valueText.text = string.Format(ValueTextFormat, value);
            }
        }

        [SerializeField]

        private Contect positionX = null;

        [SerializeField]

        private Contect positionY = null;

        [SerializeField]

        private Contect positionZ = null;

        [SerializeField]

        private Contect rotationX = null;

        [SerializeField]

        private Contect rotationY = null;

        [SerializeField]

        private Contect rotationZ = null;

        [SerializeField]

        private Contect scale = null;

        private Transform targetTransform = null;

        private void Awake()
        {
            Instance = this;

            positionX.ValueTextFormat = "{0:F2}";

            positionY.ValueTextFormat = "{0:F2}";

            positionZ.ValueTextFormat = "{0:F2}";

            rotationX.ValueTextFormat = "{0:F0}";

            rotationY.ValueTextFormat = "{0:F0}";

            rotationZ.ValueTextFormat = "{0:F0}";

            scale.ValueTextFormat = "{0:F2}";
        }

        private void Start()
        {
            positionX.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.position += new Vector3(0.01f, 0f, 0f);

                positionX.Value = targetTransform.position.x;
            });

            positionX.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.position -= new Vector3(0.01f, 0f, 0f);

                positionX.Value = targetTransform.position.x;
            });

            positionY.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.position += new Vector3(0f, 0.01f, 0f);

                positionY.Value = targetTransform.position.y;
            });

            positionY.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.position -= new Vector3(0f, 0.01f, 0f);

                positionY.Value = targetTransform.position.y;
            });

            positionZ.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.position += new Vector3(0f, 0f, 0.01f);

                positionZ.Value = targetTransform.position.z;
            });

            positionZ.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.position -= new Vector3(0f, 0f, 0.01f);

                positionZ.Value = targetTransform.position.z;
            });

            rotationX.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.Rotate(1f, 0f, 0f);

                rotationX.Value = targetTransform.eulerAngles.x;
            });

            rotationX.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.Rotate(-1f, 0f, 0f);

                rotationX.Value = targetTransform.eulerAngles.x;
            });

            rotationY.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.Rotate(0f, 1f, 0f);

                rotationY.Value = targetTransform.eulerAngles.y;
            });

            rotationY.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.Rotate(0f, -1f, 0f);

                rotationY.Value = targetTransform.eulerAngles.y;
            });

            rotationZ.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.Rotate(0f, 0f, 1f);

                rotationZ.Value = targetTransform.eulerAngles.z;
            });

            rotationZ.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.Rotate(0f, 0f, -1f);

                rotationZ.Value = targetTransform.eulerAngles.z;
            });

            scale.IncreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

                scale.Value = targetTransform.localScale.x;
            });

            scale.DecreaseValueButton.onClick.AddListener(() =>
            {
                targetTransform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);

                scale.Value = targetTransform.localScale.x;
            });
        }

        public void Initialize(Transform transform)
        {
            targetTransform = transform;

            Refresh();
        }

        private void Refresh()
        {
            positionX.Value = targetTransform.position.x;

            positionY.Value = targetTransform.position.y;

            positionZ.Value = targetTransform.position.z;

            rotationX.Value = targetTransform.eulerAngles.x;

            rotationY.Value = targetTransform.eulerAngles.y;

            rotationZ.Value = targetTransform.eulerAngles.z;

            scale.Value = targetTransform.localScale.x;
        }
    }
}