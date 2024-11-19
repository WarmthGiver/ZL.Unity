using TMPro;

using UnityEngine;

namespace ZL.UI
{
    public sealed class LightControllerContent : UIWindowContent<LightControllerContent>
    {
        [Space]

        [SerializeField]

        private TMP_Text valueText = null;

        [SerializeField]

        private AutoButton increaseValueButton = null;

        public AutoButton IncreaseValueButton => increaseValueButton;

        [SerializeField]

        private AutoButton decreaseValueButton = null;

        public AutoButton DecreaseValueButton => decreaseValueButton;

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

        public string ValueTextFormat { get; set; }

        protected override void OnDisable()
        {
            Pool.Collect(this);
        }

        public override void Refresh()
        {
            valueText.text = string.Format(ValueTextFormat, value);
        }
    }
}