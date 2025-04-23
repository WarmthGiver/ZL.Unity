using System;

namespace ZL.Reality
{
    /// <summary>
    /// Earth-Centered Earth-Fixed coordinate system.
    /// A Cartesian spatial reference system that describes locations around the Earth as X, Y, and Z measurements from the center of mass.
    /// </summary>
    public struct ECEF
    {
        public double x;

        public double y;

        public double z;

        public ECEF(double x, double y, double z)
        {
            this.x = x;

            this.y = y;

            this.z = z;
        }

        public static ECEF Get(double lat, double lon, double alt)
        {
            double radLat = MathEx.Deg2Rad * lat;

            double cosLat = Math.Cos(radLat);

            double sinLat = Math.Sin(radLat);

            double radLon = MathEx.Deg2Rad * lon;

            double cosLon = Math.Cos(radLon);

            double sinLon = Math.Sin(radLon);

            double dfc = Earth.AVGRadius + alt;

            double x = cosLat * cosLon * dfc;

            double y = cosLat * sinLon * dfc;

            double z = sinLat * dfc;

            return new(x, y, z);
        }

        public static double Distance(ECEF a, ECEF b)
        {
            return Math.Sqrt
            (
                Math.Pow(a.x - b.x, 2) +

                Math.Pow(a.y - b.y, 2) +

                Math.Pow(a.z - b.z, 2)
            );
        }
    }
}