using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class PreviewAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsFieldTypeIn(typeof(Object)) == false)
            {
                drawer.DrawHelpBox($"{NameTag} Field type is invalid.", MessageType.Error);

                return false;
            }

            drawer.DrawPreview();

            return true;
        }

#endif
    }
}