using UnityEngine;

namespace ZL.CS.Unity
{
    public static class LayerExtensions
    {
        public static bool IsIncludedIn(this int instance, LayerMask layerMask)
        {
            return ((1 << instance) & layerMask.value) != 0;
        }
    }
}