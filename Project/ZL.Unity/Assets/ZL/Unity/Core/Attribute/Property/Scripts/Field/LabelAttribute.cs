using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class LabelAttribute : CustomPropertyAttribute
    {
        public string Text { get; set; } = null;

        public LabelAttribute(string text)
        {
            Text = text;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (Text != null)
            {
                drawer.Label.text = Text;
            }

            return true;
        }

#endif
    }
}