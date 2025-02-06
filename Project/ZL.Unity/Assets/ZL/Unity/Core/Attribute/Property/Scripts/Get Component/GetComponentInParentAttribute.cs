using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class GetComponentInParentAttribute : GetComponentAttribute
    {
#if UNITY_EDITOR

        protected override void GetComponent(Drawer drawer)
        {
            drawer.TargetComponent.TryGetComponentInParent(drawer.fieldInfo.FieldType, out var component);

            drawer.Property.objectReferenceValue = component;
        }

#endif
    }
}