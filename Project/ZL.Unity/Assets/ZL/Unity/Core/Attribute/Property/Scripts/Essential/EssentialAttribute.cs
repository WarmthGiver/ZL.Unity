using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class EssentialAttribute : CustomPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsFieldTypeIn(typeof(Object)) == false)
            {
                drawer.DrawHelpBox($"{NameTag} Field type is invalid.", MessageType.Error);

                return false;
            }

            if (drawer.IsPropertyNull() == true)
            {
                drawer.DrawHelpBox($"{NameTag} This field must be assigned.", MessageType.Warning);

                return false;
            }

            return true;
        }

#endif
    }
}