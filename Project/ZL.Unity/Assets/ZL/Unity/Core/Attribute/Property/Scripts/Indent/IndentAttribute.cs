using System;

using System.Diagnostics;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class IndentAttribute : CustomPropertyAttribute
    {
        private readonly float width;

        public IndentAttribute(int level) : this(level * defaultIndentWidth) { }

        public IndentAttribute(float width)
        {
            this.width = width;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Indent(width);

            return true;
        }

#endif
    }
}