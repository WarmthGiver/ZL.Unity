using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ToggleWhenAttribute : CustomPropertyAttribute
    {
        private readonly string fieldName;

        private readonly bool targetValue;

        public ToggleWhenAttribute(string fieldName, bool targetValue)
        {
            this.fieldName = fieldName;

            this.targetValue = targetValue;
        }

#if UNITY_EDITOR

        protected override void Preset(Drawer drawer)
        {
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

            drawer.IsToggled = property.boolValue == targetValue;
        }

#endif
    }
}