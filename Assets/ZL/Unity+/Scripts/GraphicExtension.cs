using UnityEngine.UI;

namespace ZL
{
    public static partial class GraphicExtension
    {
        public static void SetAnchorStrech<TGraphic>(this TGraphic instance)

            where TGraphic : Graphic
        {
            instance.rectTransform.SetAnchorStrech();
        }
    }
}