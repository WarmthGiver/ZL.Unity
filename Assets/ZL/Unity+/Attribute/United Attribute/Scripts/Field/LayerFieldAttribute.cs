﻿namespace ZL
{
    public sealed class LayerFieldAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsPropertyTypeIn(SerializedPropertyType.Integer))
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Property type is mismatch.");

                return false;
            }

            drawer.PropertyFieldType = SerializedPropertyFieldType.Layer;

            return true;
        }

#endif
    }
}