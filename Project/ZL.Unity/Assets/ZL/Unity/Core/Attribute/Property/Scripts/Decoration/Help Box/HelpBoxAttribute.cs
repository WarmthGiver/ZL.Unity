using System;

using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public class HelpBoxAttribute : CustomPropertyAttribute
    {
        private readonly string message;

        private static readonly MessageType type = MessageType.None;

        public HelpBoxAttribute(string message) : this(message, type, defaultIconSize) { }

        public HelpBoxAttribute(string message, IconSize iconSize) : this(message, type, iconSize) { }
        
        public HelpBoxAttribute(string message, MessageType type) : this(message, type, defaultIconSize) { }

        public HelpBoxAttribute(string message, MessageType type, IconSize iconSize)
        {
            this.message = message;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawHelpBox(message, MessageType.None);

            return true;
        }

#endif
    }
}