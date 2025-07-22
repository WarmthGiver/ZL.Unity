using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.GFX
{
    [AddComponentMenu("ZL/GFX/Material Controller (Graphic)")]

    public sealed class MaterialController_Graphic : MaterialController
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnlyIfPlayMode(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Graphic targetGraphic = null;

        [Space]

        [ReadOnlyIfPlayMode(true)]

        [UsingCustomProperty]

        [SerializeField]

        private bool isShared = false;

        private Material material = null;

        public override Material Material
        {
            get
            {
                if (material == null)
                {
                    material = targetGraphic.material;

                    if (isShared == false)
                    {
                        material = new(material);
                    }

                    targetGraphic.material = material;
                }

                return material;
            }
        }
    }
}