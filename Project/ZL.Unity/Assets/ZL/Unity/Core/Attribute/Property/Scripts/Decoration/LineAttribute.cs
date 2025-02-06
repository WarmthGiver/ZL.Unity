using System;

using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class LineAttribute : UnitedPropertyAttribute
    {
        public float Height { get; set; } = defaultLineHeight;

        private Color color = defaultTextColor;

        public float R { get => color.r; set => color.r = value; }

        public float G { get => color.g; set => color.g = value; }

        public float B { get => color.b; set => color.b = value; }

        public float A { get => color.a ; set => color.a = value; }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawLine(Height, color);

            return true;
        }

#endif
    }
}