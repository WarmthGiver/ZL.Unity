using System;

using System.Diagnostics;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class EmptyAttribute : UnitedPropertyAttribute
    {
        private readonly float height;

        public EmptyAttribute() : this(defaultSpaceHeight) { }

        public EmptyAttribute(float height = 8f)
        {
            this.height = height;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawEmpty(height);

            return true;
        }

#endif
    }
}