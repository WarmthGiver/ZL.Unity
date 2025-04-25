using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Digital Clock")]

    [DisallowMultipleComponent]

    public sealed class DigitalClock : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextController textController;

        [SerializeField]

        private float speed = 0f;

        [Space]

        [SerializeField]

        private int hour = 0;

        public int Hour
        {
            get => hour;

            set
            {
                hour = value;

                if (hour > 23)
                {
                    hour = 0;
                }

                else if (hour < 0)
                {
                    hour = 59;
                }
            }
        }

        [SerializeField]

        private int minute = 0;

        public int Minute
        {
            get => minute;

            set
            {
                minute = value;

                if (minute > 59)
                {
                    minute = 0;

                    Hour += 1;
                }

                else if (minute < 0)
                {
                    minute = 59;

                    Hour -= 1;
                }
            }
        }

        [SerializeField]

        private float seconds = 0f;

        public float Seconds
        {
            get => seconds;

            set
            {
                seconds = value;

                if (seconds >= 60f)
                {
                    seconds = Mathf.Repeat(seconds, 60f);

                    Minute += 1;
                }

                else if (seconds < 0f)
                {
                    seconds = Mathf.Repeat(seconds, 60f);

                    Minute -= 1;
                }
            }
        }

        private void OnValidate()
        {
            Seconds = seconds;

            Minute = minute;

            Hour = hour;

            if (textController != null)
            {
                textController.Text = $"{hour:D2}:{minute:D2}";
            }
        }

        private void Update()
        {
            if (seconds % 1 < 0.5f)
            {
                textController.Text = $"{hour:D2}:{minute:D2}";
            }

            else
            {
                textController.Text = $"{hour:D2} {minute:D2}";
            }

            Seconds += Time.deltaTime * speed;
        }
    }
}