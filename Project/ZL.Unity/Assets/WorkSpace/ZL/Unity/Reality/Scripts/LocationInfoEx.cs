using UnityEngine;

using ZL.CS.Reality;

namespace ZL.Unity.Reality
{
    public static partial class LocationInfoEx
    {
        public static ECEF ToECEF(this LocationInfo instance)
        {
            return ECEF.Get(instance.latitude, instance.longitude, instance.altitude);
        }
    }
}