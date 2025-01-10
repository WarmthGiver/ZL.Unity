//using System;

//using UnityEngine;

namespace ZL.Unity
{
    public sealed class PreviewAttribute : UnitedPropertyAttribute
    {
        //private readonly Type[] validFieldTypes;

        public PreviewAttribute() : base()
        {
            //validFieldTypes = new Type[] { typeof(Texture), typeof(Texture2D), typeof(Sprite) };
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (!drawer.IsFieldTypeIn(typeof(UnityEngine.Object)))
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Field type is invalid.");

                return false;
            }

            drawer.DrawPreview();

            return true;
        }

#endif
    }
}