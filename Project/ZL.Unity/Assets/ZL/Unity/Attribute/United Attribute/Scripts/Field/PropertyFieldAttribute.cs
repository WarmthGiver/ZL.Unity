/*namespace ZL
{
    public abstract class PropertyFieldAttribute : UnitedPropertyAttribute
    {
        protected readonly SerializedPropertyStyle propertyStyle;

        protected readonly SerializedPropertyType[] propertyTypes;

        public PropertyFieldAttribute(SerializedPropertyStyle propertyStyle, params SerializedPropertyType[] propertyTypes) : base()
        {
            this.propertyStyle = propertyStyle;

            this.propertyTypes = propertyTypes;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsPropertyTypeIn(propertyTypes) == false)
            {
                drawer.DrawHelpBox(MessageType.Error, $"{nameTag} Property type is mismatch.");

                return false;
            }

            drawer.PropertyStyle = propertyStyle;

            return true;
        }

#endif
    }
}*/