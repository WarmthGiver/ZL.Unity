using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Material Controller (Renderer)")]

    public sealed class MaterialController_Renderer : MaterialController
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnlyIfPlayMode(true)]

        [UsingCustomProperty]

        [SerializeField]

        #pragma warning disable

        private Renderer renderer = null;

        #pragma warning restore

        [Space]

        [SerializeField]

        private int index = 0;

        public override Material Material
        {
            get => Materials[index];
        }

        public Material[] Materials
        {
            get => renderer.materials;
        }

        [Space]

        [SerializeField]

        private string propertyName = string.Empty;

        public override string PropertyName
        {
            get => propertyName;

            set => propertyName = value;
        }
    }
}