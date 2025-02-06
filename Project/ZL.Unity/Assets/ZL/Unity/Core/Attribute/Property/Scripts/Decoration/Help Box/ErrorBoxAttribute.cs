using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ErrorBoxAttribute : HelpBoxAttribute
    {
        public ErrorBoxAttribute(string message) : base(message, MessageType.Error) { }

        public ErrorBoxAttribute(string message, IconSize iconSize) : base(message, MessageType.Error, iconSize) { }
    }
}