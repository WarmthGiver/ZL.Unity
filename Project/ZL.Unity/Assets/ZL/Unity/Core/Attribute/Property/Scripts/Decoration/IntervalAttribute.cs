using System;

using System.Diagnostics;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class IntervalAttribute : CustomPropertyAttribute
    {
        private readonly float height;

        public IntervalAttribute() : this(defaultIntervalHeight) { }

        public IntervalAttribute(float height)
        {
            this.height = height;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Interval(height);

            return true;
        }

#endif
    }
}