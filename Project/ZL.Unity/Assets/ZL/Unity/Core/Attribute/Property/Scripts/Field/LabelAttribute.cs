using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class LabelAttribute : UnitedPropertyAttribute
    {
        public string Text { get; set; } = null;

        public string Tooltip { get; set; } = null;

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.Label.text = Text;

            drawer.Current.Label.text = Tooltip;

            return true;
        }

#endif
    }
}