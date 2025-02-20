using System;
using System.Diagnostics;
using UnityEditor;

namespace ZL.CS.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ToggleWhenAttribute : CustomPropertyAttribute
    {
        private readonly string fieldName;

        private readonly object targetValue;

        private readonly bool condition;

        public ToggleWhenAttribute(string fieldName, bool targetValue) : this(fieldName, targetValue, true) { }

        public ToggleWhenAttribute(string fieldName, object targetValue, bool condition)
        {
            this.fieldName = fieldName;

            this.targetValue = targetValue;

            this.condition = condition;
        }

#if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            if (drawer.Property.TryFindProperty(fieldName, out var property) == false)
            {
                drawer.DrawErrorBox($"{NameTag} No property found matching \"{fieldName}\".");

                return;
            }

            if (targetValue == null)
            {
                drawer.IsToggled = (property.objectReferenceValue == null) == condition;

                return;
            }

            drawer.IsToggled = property.boxedValue.Equals(targetValue) == condition;
        }

#endif
    }
}