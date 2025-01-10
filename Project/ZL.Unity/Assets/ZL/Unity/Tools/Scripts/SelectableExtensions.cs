using UnityEngine.UI;

namespace ZL.Unity.Tools
{
    public static partial class SelectableExtensions
    {
        public static void CreateImage(this Selectable instance)
        {
            instance.targetGraphic = Creator.CreateGraphic<Image>();
        }

        public static void CreateText(this Selectable instance, string textString)
        {
            instance.targetGraphic = Creator.CreateText(textString);
        }

        public static void CreateTextMeshPro(this Selectable instance, string textString)
        {
            instance.targetGraphic = Creator.CreateTextMeshPro(textString);
        }
    }
}