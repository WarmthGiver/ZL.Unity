using System;

using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class LineAttribute : CustomPropertyAttribute
    {
        private readonly float height;

        private readonly Color color = defaultTextColor;

        public LineAttribute(float height, string hexColor = null)
        {
            this.height = height;

            if (ColorUtility.TryParseHtmlString(hexColor, out Color color) == true)
            {
                this.color = color;
            }
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawLine(height, color);

            return true;
        }

#endif
    }
}