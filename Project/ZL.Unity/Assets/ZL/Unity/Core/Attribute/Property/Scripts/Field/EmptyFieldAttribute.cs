using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class EmptyFieldAttribute : CustomPropertyAttribute
    {
#if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            /*if (drawer.Property.propertyType != SerializedPropertyType.Generic == true && drawer.Property.hasVisibleChildren == true)
            {
                drawer.DrawErrorBox($"{NameTag} Property type is mismatch.");

                return;
            }*/

            drawer.DrawPropertyField(SerializedPropertyFieldType.Empty);
        }

#endif
    }
}