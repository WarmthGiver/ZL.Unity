using UnityEngine;

using ZL.CS.Unity.IO;

namespace ZL.CS.Unity
{
    public static partial class Texture2DExtensions
    {
        public static byte[] ToBytes(this Texture2D instance, ImageFileNameExtension fileExtension)
        {
            return fileExtension switch
            {
                ImageFileNameExtension.tga => instance.EncodeToTGA(),

                ImageFileNameExtension.png => instance.EncodeToPNG(),

                ImageFileNameExtension.jpg => instance.EncodeToJPG(),

                ImageFileNameExtension.exr => instance.EncodeToEXR(),

                _ => null
            };
        }
    }
}