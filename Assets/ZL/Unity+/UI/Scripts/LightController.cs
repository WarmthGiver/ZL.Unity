using UnityEngine;

namespace ZL.UI
{
    public sealed class LightController : Singleton<LightController>
    {
        [SerializeField]

        private LightControllerContent colorR = null;

        [SerializeField]

        private LightControllerContent colorG = null;

        [SerializeField]

        private LightControllerContent colorB = null;

        [SerializeField]

        private LightControllerContent intensity = null;

        [SerializeField]

        private LightControllerContent rotationX = null;

        [SerializeField]

        private LightControllerContent rotationY = null;

        [SerializeField]

        private LightControllerContent rotationZ = null;

        private LightPlus targetLight = null;

        private Transform targetTransform = null;

        protected override void Awake()
        {
            base.Awake();

            colorR.ValueTextFormat = "{0:F0}";

            colorG.ValueTextFormat = "{0:F0}";

            colorB.ValueTextFormat = "{0:F0}";

            intensity.ValueTextFormat = "{0:F2}";

            rotationX.ValueTextFormat = "{0:F0}";

            rotationY.ValueTextFormat = "{0:F0}";

            rotationZ.ValueTextFormat = "{0:F0}";
        }

        private void Start()
        {
            var byteScale = One.over255;

            colorR.IncreaseValueButton.onClick.AddListener(() =>
            {
                var color = targetLight.Color + new Color(byteScale, 0f, 0f);

                if (color.r > 1f)
                {
                    color.r = 1f;
                }

                colorR.Value = color.r * 255f;

                targetLight.Color = color;
            });

            colorR.DecreaseValueButton.onClick.AddListener(() =>
            {
                var color = targetLight.Color - new Color(byteScale, 0f, 0f);

                if (color.r < 0f)
                {
                    color.r = 0f;
                }

                colorR.Value = color.r * 255f;

                targetLight.Color = color;
            });

            colorG.IncreaseValueButton.onClick.AddListener(() =>
            {
                var color = targetLight.Color + new Color(0f, byteScale, 0f);

                if (color.g > 1f)
                {
                    color.g = 1f;
                }

                colorG.Value = color.g * 255f;

                targetLight.Color = color;
            });

            colorG.DecreaseValueButton.onClick.AddListener(() =>
            {
                var color = targetLight.Color - new Color(0f, byteScale, 0f);

                if (color.g < 0f)
                {
                    color.g = 0f;
                }

                colorG.Value = color.g * 255f;

                targetLight.Color = color;
            });

            colorB.IncreaseValueButton.onClick.AddListener(() =>
            {
                var color = targetLight.Color + new Color(0f, 0f, byteScale);

                if (color.b > 1f)
                {
                    color.b = 1f;
                }

                colorB.Value = color.b * 255f;

                targetLight.Color = color;
            });

            colorB.DecreaseValueButton.onClick.AddListener(() =>
            {
                var color = targetLight.Color - new Color(0f, 0f, byteScale);

                if (color.b < 0f)
                {
                    color.b = 0f;
                }

                colorB.Value = color.b * 255f;

                targetLight.Color = color;
            });

            intensity.IncreaseValueButton.onClick.AddListener(() =>
            {
                intensity.Value  = targetLight.Intensity + 0.01f;

                if (intensity.Value > 1f)
                {
                    intensity.Value = 1f;
                }

                targetLight.Intensity = intensity.Value;
            });

            intensity.DecreaseValueButton.onClick.AddListener(() =>
            {
                intensity.Value = targetLight.Intensity - 0.01f;

                if (intensity.Value < 0f)
                {
                    intensity.Value = 0f;
                }

                targetLight.Intensity = intensity.Value;
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
        }

        public void SetTarget(LightPlus target)
        {
            targetLight = target;

            targetTransform = target.transform;

            Refresh();
        }

        private void Refresh()
        {
            colorR.Value = targetLight.Color.r * 255f;

            colorG.Value = targetLight.Color.g * 255f;

            colorB.Value = targetLight.Color.b * 255f;

            intensity.Value = targetLight.Intensity;

            rotationX.Value = targetTransform.eulerAngles.x;

            rotationY.Value = targetTransform.eulerAngles.y;

            rotationZ.Value = targetTransform.eulerAngles.z;
        }
    }
}