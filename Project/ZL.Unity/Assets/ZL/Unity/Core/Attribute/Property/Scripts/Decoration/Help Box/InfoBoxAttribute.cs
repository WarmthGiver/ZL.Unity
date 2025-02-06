using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class InfoBoxAttribute : HelpBoxAttribute
    {
        public InfoBoxAttribute(string message, IconSize iconSize = IconSize.Small) : base(message, MessageType.Info, iconSize) { }
    }
}