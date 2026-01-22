using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Material Controller (Graphic)")]

    public sealed class MaterialController_Graphic : MaterialController
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnlyIfPlayMode(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Graphic graphic = null;

        private Material material = null;

        public override Material Material
        {
            get
            {
                if (material == null)
                {
                    graphic.material = material = new Material(graphic.material);
                }

                return material;
            }
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