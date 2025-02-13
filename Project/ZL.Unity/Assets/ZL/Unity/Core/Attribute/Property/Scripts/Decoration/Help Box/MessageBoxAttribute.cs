using System;

using System.Diagnostics;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public class MessageBoxAttribute : CustomPropertyAttribute
    {
        protected readonly string message;

        public MessageBoxAttribute(string message)
        {
            this.message = message;
        }

#if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            drawer.DrawMessageBox(message);
        }

#endif
    }
}