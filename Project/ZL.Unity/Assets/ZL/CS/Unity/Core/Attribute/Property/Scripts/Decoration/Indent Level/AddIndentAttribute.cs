using System;

using System.Diagnostics;

namespace ZL.CS.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class AddIndentAttribute : CustomPropertyAttribute
    {
        private readonly int level;

        public AddIndentAttribute(int level)
        {
            this.level = level;
        }

#if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            drawer.IndentLevel += level;
        }

#endif
    }
}