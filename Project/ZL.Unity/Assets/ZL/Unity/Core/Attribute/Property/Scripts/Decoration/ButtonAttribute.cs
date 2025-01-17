using System;

using Unity.VisualScripting;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    public sealed class ButtonAttribute : UnitedPropertyAttribute
    {
        private readonly string methodName;

        private readonly string text;

        private readonly float height;

        public ButtonAttribute(string methodName, float height) : this(methodName, null, height) { }

        public ButtonAttribute(string methodName, string text = null, float height = singleLineHeight) : base()
        {
            this.methodName = methodName;

            text ??= methodName.SplitWords(' ');

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