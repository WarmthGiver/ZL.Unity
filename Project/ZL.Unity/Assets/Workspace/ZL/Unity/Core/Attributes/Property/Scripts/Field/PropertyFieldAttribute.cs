namespace ZL
{
    public sealed class PropertyFieldAttribute : FieldAttribute
    {
        #if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            drawer.DrawPropertyField();
        }

        #endif
    }
}