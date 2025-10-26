using System;

namespace ZL.CS
{
    /// <summary>
    /// Extenstions of MathF
    /// </summary>
    public static partial class MathFEx
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
        public const float Root3 = 1.7320508f;

        /// <summary>
        /// = 1 / 60
        /// </summary>
        public const float OneOver60 = 0.016666667f;

        /// <summary>
        /// = 1 / 255
        /// </summary>
        public const float OneOver255 = 0.003921569f;

        /// <summary>
        /// Convert percentage value (0 to 100) to decibel.
        /// </summary>
        public static float PercentToDecibel(float value)
        {
            return LinearToDecibel(value * 0.01f);
        }

        /// <summary>
        /// Convert decibel value to percentage (0 to 100).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float DecibelToPercent(float value)
        {
            return DecibelToLinear(value) * 100f;
        }

        /// <summary>
        /// Convert linear value (0.0 to 1.0) to decibel.
        /// </summary>
        public static float LinearToDecibel(float value)
        {
            if (value <= 0f)
            {
                return -80f;
            }

            return MathF.Log10(value) * 20f;
        }

        /// <summary>
        /// Convert decibel value to linear (0.0 to 1.0).
        /// </summary>
        public static float DecibelToLinear(float value)
        {
            if (value <= -80f)
            {
                return 0f;
            }

            return MathF.Pow(10f, value * 0.05f);
        }
    }
}