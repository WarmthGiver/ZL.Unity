namespace ZL.Unity
{
    public sealed class HiddenFieldAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsPropertyTypeIn(SerializedPropertyType.Generic) && drawer.Property.hasVisibleChildren)
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Property type is mismatch.");

                return false;
            }

            drawer.PropertyFieldType = SerializedPropertyFieldType.Empty;

            return true;
        }

#endif
    }
}