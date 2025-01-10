using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity
{
    public static partial class ColorExtensions
    {
        public static Color ToneDown(this Color instance, in float tone)
        {
            instance.r *= tone;

            instance.g *= tone;

            instance.b *= tone;

            return instance;
        }
    }

    public struct Linear
    {
        public float value;

        public float length;

        public IntervalMode mode;

        public Linear(float value, float length, IntervalMode mode)
        {
            this.value = value;

            this.length = length;

            this.mode = mode;
        }

        public float Interval(float delta, IntervalMode mode)
        {
            value += delta;

            switch (mode)
            {
                case IntervalMode.Clamp:

                    value = Mathf.Clamp(value, 0f, length);

                    break;

                case IntervalMode.Repeat:

                    value = Mathf.Repeat(value, length);

                    break;

                case IntervalMode.PingPong:

                    value = Mathf.PingPong(value, length);

                    break;

                case IntervalMode.Sin:

                    value = Mathf.Repeat(value, MathEx.PI2);

                    return (Mathf.Sin(value) + 1) * 0.5f * length;
            }

            return value;
        }
    }

    public enum IntervalMode
    {
        Clamp,

        Repeat,

        PingPong,

        Sin,
    }

    public sealed class Discolorator
    {
        private Color color = Color.red;

        public Color Color => color;

        private float deltaH;

        private float deltaS;

        private float deltaV;

        public Discolorator(ColorPalette color) : this(color.ToColor()) { }

        public Discolorator(Color color)
        {
            this.color = color;

            Reset();
        }

        public void Reset()
        {
            moveHSVRoutile = MoveHSVRoutile(color);
        }

        public Color MoveHSV(float deltaH, float deltaS, float deltaV)
        {
            this.deltaH = deltaH;

            this.deltaS = deltaS;

            this.deltaV = deltaV;

            moveHSVRoutile.MoveNext();

            return moveHSVRoutile.Current;
        }

        private IEnumerator<Color> moveHSVRoutile;

        private IEnumerator<Color> MoveHSVRoutile(Color color)
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);

            Linear linearH = new(h, 1f, IntervalMode.Repeat);

            Linear linearS = new(s, 1f, IntervalMode.PingPong);

            Linear linearV = new(v, 1f, IntervalMode.PingPong);

            while (true)
            {
                yield return Color.HSVToRGB(h, s, v);

                h = linearH.Interval(deltaH, IntervalMode.Repeat);

                s = linearS.Interval(deltaS, IntervalMode.PingPong);

                v = linearV.Interval(deltaV, IntervalMode.Repeat);
            }
        }
    }
}