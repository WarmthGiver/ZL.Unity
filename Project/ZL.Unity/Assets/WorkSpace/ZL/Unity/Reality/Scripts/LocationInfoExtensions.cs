using UnityEngine;

using ZL.Reality;

namespace ZL
{
    public static partial class LocationInfoExtensions
    {
        public static ECEF ToECEF(this LocationInfo instance)
        {
            return ECEF.Get(instance.latitude, instance.longitude, instance.altitude);
        }
    }
}