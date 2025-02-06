using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class TagFieldAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsPropertyTypeIn(SerializedPropertyType.String) == false)
            {
                drawer.DrawHelpBox($"{NameTag} Property type is mismatch.", MessageType.Error);

                return false;
            }

            drawer.Current.PropertyFieldType = SerializedPropertyFieldType.Tag;

            return true;
        }

#endif
    }
}