using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class WarningBoxAttribute : HelpBoxAttribute
    {
        public WarningBoxAttribute(string message) : base(message, MessageType.Warning) { }

        public WarningBoxAttribute(string message, IconSize iconSize) : base(message, MessageType.Warning, iconSize) { }
    }
}