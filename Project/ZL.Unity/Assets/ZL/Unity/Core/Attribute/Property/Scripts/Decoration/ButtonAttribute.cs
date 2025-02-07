using System;

using System.Diagnostics;

using Unity.VisualScripting;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class ButtonAttribute : CustomPropertyAttribute
    {
        private readonly string methodName;

        private readonly string text;

        private readonly float height;

        public ButtonAttribute(string methodName) : this(methodName, null, defaultLabelHeight) { }

        public ButtonAttribute(string methodName, float height) : this(methodName, null, height) { }

        public ButtonAttribute(string methodName, string text) : this(methodName, text, defaultLabelHeight) { }

        public ButtonAttribute(string methodName, string text, float height)
        {
            this.methodName = methodName;

            text ??= methodName?.SplitWords(' ');

            this.text = text;

            this.height = height;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawButton(methodName, text, height);

            return true;
        }

#endif
    }
}