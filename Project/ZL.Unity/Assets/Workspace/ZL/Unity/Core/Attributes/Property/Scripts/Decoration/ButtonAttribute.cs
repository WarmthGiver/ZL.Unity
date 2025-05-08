using System.Reflection;

using Unity.VisualScripting;
using UnityEngine;

namespace ZL.Unity
{
    public sealed class ButtonAttribute : CustomPropertyAttribute
    {
        private readonly string methodName;

        private readonly string text;

        public float Height { get; set; } = defaultLabelHeight;

        public ButtonAttribute(string methodName, string text = null)
        {
            this.methodName = methodName;

            text ??= methodName?.SplitWords(' ');

            this.text = text;
        }

        #if UNITY_EDITOR

        private MethodInfo method = null;

        protected override void Initialize(Drawer drawer)
        {
            Debug.Log(drawer.TargetObject);

            var type = drawer.TargetObject.GetType();

            Debug.Log(type);

            Debug.Log(methodName);

            method = type.GetMethod(methodName);

            Debug.Log(method);
        }

        protected override void Draw(Drawer drawer)
        {
            drawer.DrawButton(method, text, Height);
        }

        #endif
    }
}