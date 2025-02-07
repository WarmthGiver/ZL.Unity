using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ToggleAttribute : CustomPropertyAttribute
    {
        private readonly string fieldName;

        private readonly bool targetValue;

        public ToggleAttribute(string fieldName, bool targetValue = true)
        {
            this.fieldName = fieldName;

            this.targetValue = targetValue;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.TryFindProperty(fieldName, out var property) == false)
            {
                drawer.DrawHelpBox($"{NameTag} No property found matching \"{fieldName}\".", MessageType.Error);

                return false;
            }

            if (property.propertyType != SerializedPropertyType.Boolean)
            {
                drawer.DrawHelpBox($"{NameTag} Property type is mismatch.", MessageType.Error);

                return false;
            }

            drawer.IsHided = property.boolValue == targetValue;

            return true;
        }

#endif
    }
}