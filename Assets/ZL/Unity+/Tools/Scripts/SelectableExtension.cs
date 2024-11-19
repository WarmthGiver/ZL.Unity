using UnityEngine.UI;

namespace ZL.Tools
{
    public static partial class SelectableExtension
    {
        public static void CreateImage(this Selectable instance)
        {
            instance.targetGraphic = CreateTool.CreateGraphic<Image>();
        }

        public static void CreateText(this Selectable instance, string textString)
        {
            instance.targetGraphic = CreateTool.CreateText(textString);
        }

        public static void CreateTextMeshPro(this Selectable instance, string textString)
        {
            instance.targetGraphic = CreateTool.CreateTextMeshPro(textString);
        }
    }
}