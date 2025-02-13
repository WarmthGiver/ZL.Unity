using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ToggleAttribute : CustomPropertyAttribute
    {
        private readonly string fieldName = null;

        private readonly bool targetValue;

        public ToggleAttribute(bool value)
        {
            targetValue = value;
        }

        public ToggleAttribute(string fieldName, bool targetValue)
        {
            this.fieldName = fieldName;

            this.targetValue = targetValue;
        }

#if UNITY_EDITOR

        protected override void Preset(Drawer drawer)
        {
            if (fieldName == null)
            {
                drawer.IsHided = targetValue;

                return;
            }

            if (drawer.Property.TryFindProperty(fieldName, out var property) == false)
            {
                drawer.DrawErrorBox($"{NameTag} No property found matching \"{fieldName}\".");

                return;
            }

            if (property.propertyType != SerializedPropertyType.Boolean)
            {
                drawer.DrawErrorBox($"{NameTag} Property type is mismatch.");

                return;
            }

            drawer.IsHided = property.boolValue == targetValue;
        }

#endif
    }
}