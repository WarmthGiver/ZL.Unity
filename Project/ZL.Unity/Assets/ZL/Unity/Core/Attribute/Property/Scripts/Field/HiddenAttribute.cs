using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class HiddenAttribute : CustomPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsPropertyTypeIn(SerializedPropertyType.Generic) == true && drawer.Property.hasVisibleChildren == true)
            {
                drawer.DrawHelpBox($"{NameTag} Property type is mismatch.", MessageType.Error);

                return false;
            }

            drawer.style = SerializedPropertyFieldStyle.Empty;

            return true;
        }

#endif
    }
}