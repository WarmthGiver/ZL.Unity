using DG.Tweening.Plugins.Options;

using UnityEngine;

using ZL.Unity.GFX;

namespace ZL.Unity.Tweening
{
    public abstract class MaterialValueTweener<TValueTweener, T1, T2, TPlugOptions> : ObjectValueTweener<TValueTweener, T1, T2, TPlugOptions>

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private MaterialController materialController = null;

        [ToggleIf(nameof(materialController), null, false)]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        protected Material material = null;

        public Material Material
        {
            get => material;

            set => material = value;
        }

        protected override void Awake()
        {
            base.Awake();

            if (materialController.Material != null)
            {
                material = materialController.Material;
            }
        }
    }
}