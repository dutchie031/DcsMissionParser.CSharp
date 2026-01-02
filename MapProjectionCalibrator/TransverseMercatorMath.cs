using System;

namespace MapProjectionCalibrator
{
    internal static class TransverseMercatorMath
    {
        // WGS84 ellipsoid parameters
        private const double A = 6378137.0;              // semi-major axis
        private const double F = 1.0 / 298.257223563;    // flattening
        private const double K0_DEFAULT = 1.0;           // default scale factor

        private static readonly double E2 = F * (2 - F);           // first eccentricity squared
        private static readonly double E4 = E2 * E2;
        private static readonly double E6 = E4 * E2;

        // Forward Transverse Mercator on WGS84. Returns unscaled (k0 already applied) Easting/Northing
        public static (double E, double N) Forward(
            double latDeg,
            double lonDeg,
            double centralMeridianDeg,
            double scaleFactor = K0_DEFAULT)
        {
            var lat = DegToRad(latDeg);
            var lon = DegToRad(lonDeg);
            var lon0 = DegToRad(centralMeridianDeg);

            var dLon = lon - lon0;

            var sinLat = Math.Sin(lat);
            var cosLat = Math.Cos(lat);
            var tanLat = Math.Tan(lat);

            var N = A / Math.Sqrt(1.0 - E2 * sinLat * sinLat); // radius of curvature in the prime vertical
            var T = tanLat * tanLat;
            var C = E2 / (1.0 - E2) * cosLat * cosLat;
            var A_l = dLon * cosLat;

            var M = MeridionalArc(lat);

            var A_l2 = A_l * A_l;
            var A_l3 = A_l2 * A_l;
            var A_l4 = A_l2 * A_l2;
            var A_l5 = A_l4 * A_l;
            var A_l6 = A_l4 * A_l2;

            var easting = scaleFactor * N * (
                A_l
                + (1.0 - T + C) * A_l3 / 6.0
                + (5.0 - 18.0 * T + T * T + 72.0 * C - 58.0 * E2) * A_l5 / 120.0
            );

            var northing = scaleFactor * (
                M
                + N * tanLat * (
                    A_l2 / 2.0
                    + (5.0 - T + 9.0 * C + 4.0 * C * C) * A_l4 / 24.0
                    + (61.0 - 58.0 * T + T * T + 600.0 * C - 330.0 * E2) * A_l6 / 720.0
                )
            );

            return (easting, northing);
        }

        private static double MeridionalArc(double lat)
        {
            // Meridional arc from equator to latitude lat on WGS84
            var n = F / (2.0 - F);
            var a0 = 1.0 + (n * n) / 4.0 + (n * n * n * n) / 64.0;
            var a2 = -(3.0 / 2.0) * (n - (n * n * n) / 8.0);
            var a4 = (15.0 / 16.0) * (n * n - (n * n * n * n) / 4.0);
            var a6 = -(35.0 / 48.0) * (n * n * n);

            return A * (a0 * lat + a2 * Math.Sin(2.0 * lat) + a4 * Math.Sin(4.0 * lat) + a6 * Math.Sin(6.0 * lat));
        }

        private static double DegToRad(double deg) => deg * Math.PI / 180.0;
    }
}
