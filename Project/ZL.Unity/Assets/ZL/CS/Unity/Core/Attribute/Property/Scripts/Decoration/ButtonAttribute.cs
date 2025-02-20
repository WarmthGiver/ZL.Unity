using System;

using System.Diagnostics;

using System.Reflection;

using Unity.VisualScripting;

namespace ZL.CS.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ButtonAttribute : CustomPropertyAttribute
    {
        private readonly string methodName;

        private readonly string text;

        private MethodInfo method = null;

        public float Height { get; set; } = defaultLabelHeight;

        public ButtonAttribute(string methodName, string text = null)
        {
            this.methodName = methodName;

            text ??= methodName?.SplitWords(' ');

            this.text = text;
        }

#if UNITY_EDITOR

        protected override void Initialize(Drawer drawer)
        {
            var type = drawer.TargetComponent.GetType();

            method = type.GetMethod(methodName);
        }

        protected override void Draw(Drawer drawer)
        {
            drawer.DrawButton(method, text, Height);
        }

#endif
    }
}