using UnityEngine;

namespace ZL.Unity
{
    public static partial class MathEx
    {
        /// <summary>
        /// = PI * 2
        /// </summary>
        public const float PI2 = 6.2831855f;

        /// <summary>
        /// = PI / 2
        /// </summary>
        public const float PIHalf = 1.57079632679f;

        /// <summary>
        /// = SQRT(3)
        /// </summary>
        public const float root3 = 1.7320508f;

        /// <summary>
        /// = 1 / 255
        /// </summary>
        public const float normal255 = 0.003921569f;

        public static float DecibelToLinear(float value)
        {
            if (value <= -80f)
            {
                return 0f;
            }

            return Mathf.Pow(10f, value * 0.05f);
        }

        public static float LinearToDecibel(float value)
        {
            if (value <= 0f)
            {
                return -80f;
            }

            return Mathf.Log10(value) * 20f;
        }
    }
}