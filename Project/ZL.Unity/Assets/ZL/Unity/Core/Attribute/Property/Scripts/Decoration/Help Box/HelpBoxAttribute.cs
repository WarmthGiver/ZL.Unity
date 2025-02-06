using System;

using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public class HelpBoxAttribute : UnitedPropertyAttribute
    {
        private readonly GUIContent label;

        private static readonly MessageType type = MessageType.None;

        public HelpBoxAttribute(string message) : this(message, type, defaultIconSize) { }

        public HelpBoxAttribute(string message, IconSize iconSize) : this(message, type, iconSize) { }
        
        public HelpBoxAttribute(string message, MessageType type) : this(message, type, defaultIconSize) { }

        public HelpBoxAttribute(string message, MessageType type, IconSize iconSize)
        {
            label = new(message, Utility.GetHelpIcon(type, iconSize));
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawHelpBox(label);

            return true;
        }

#endif
    }
}