using System;

using System.Diagnostics;

using Unity.VisualScripting;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class ButtonAttribute : UnitedPropertyAttribute
    {
        private readonly string methodName;

        public string Text { get; set; } = null;

        public float Height { get; set; } = defaultLabelHeight;

        public ButtonAttribute(string methodName)
        {
            this.methodName = methodName;

            Text ??= methodName.SplitWords(' ');
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawButton(methodName, Text, Height);

            return true;
        }

#endif
    }
}