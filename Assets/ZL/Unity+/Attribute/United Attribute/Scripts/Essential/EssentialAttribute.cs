using UnityEngine;

namespace ZL
{
    public sealed class EssentialAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (!drawer.IsFieldTypeIn(typeof(Object)))
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Field type is invalid.");

                return false;
            }

            if (drawer.IsPropertyNull())
            {
                drawer.DrawHelpBox(MessageType.Warning, $"{NameTag} This field must be assigned.");

                return false;
            }

            return true;
        }

#endif
    }
}