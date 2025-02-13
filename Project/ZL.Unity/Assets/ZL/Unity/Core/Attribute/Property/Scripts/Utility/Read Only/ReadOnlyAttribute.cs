using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ReadOnlyAttribute : CustomPropertyAttribute
    {
#if UNITY_EDITOR

        protected override void Preset(Drawer drawer)
        {
            drawer.IsEnabled = false;
        }

#endif
    }
}