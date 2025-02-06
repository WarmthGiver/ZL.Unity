using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ToggleAttribute : UnitedPropertyAttribute
    {
        private readonly string fieldName;

        private readonly bool targetValue;

        public ToggleAttribute(string fieldName, bool targetValue = true) : base()
        {
            this.fieldName = fieldName;

            this.targetValue = targetValue;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.TryFindProperty(fieldName, SerializedPropertyType.Boolean, out var property) == false)
            {
                return false;
            }

            drawer.Current.IsToggled = property.boolValue == targetValue;

            return true;
        }

#endif
    }
}