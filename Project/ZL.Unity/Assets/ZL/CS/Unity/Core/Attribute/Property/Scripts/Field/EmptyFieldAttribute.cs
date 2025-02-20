using System.Diagnostics;

namespace ZL.CS.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class EmptyFieldAttribute : FieldAttribute
    {
#if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            drawer.DrawPropertyField(SerializedPropertyFieldType.Empty);
        }

#endif
    }
}