using System;

namespace ConvertWGS84UTM
{
    internal class WGS84UTM
    {
        private static readonly double RTOD = 57.29577951308232;
        private static readonly double DTOR = (1.0 / 57.29577951308232);
        private static readonly double RADIANS = 57.2957795;	/* degrees/radian */
        private static readonly double RADIUS = 6378137.0;
        private static readonly double FLATTENING = 0.00335281068;/* GRS80 or WGS84 */
        private static readonly double K_NOT = 0.9996;   /* UTM scale factor */
        private static readonly double DEGREES_TO_RADIANS = 0.01745329252;
        private static readonly double FALSE_EASTING = 500000.0;

        public static void ConvertUtmToGeo(double x_utm, double y_utm, int zone, out double lat, out double lng)
        {
            x_utm -= FALSE_EASTING;

            /* compute the necessary geodetic parameters and constants */
            double e_squared = 2.0 * FLATTENING - FLATTENING * FLATTENING;
            double e_fourth = e_squared * e_squared;
            double e_sixth = e_fourth * e_squared;
            double oneminuse = Math.Sqrt(1.0 - e_squared);

            /* compute the footpoint latitude */
            double M = y_utm / K_NOT;
            double mu = M / (RADIUS * (1.0 - 0.25 * e_squared -
                0.046875 * e_fourth - 0.01953125 * e_sixth));
            double e1 = (1.0 - oneminuse) / (1.0 + oneminuse);
            double e1sq = e1 * e1;
            double footpoint = mu + (1.5 * e1 - 0.84375 * e1sq * e1) * Math.Sin(2.0 * mu) +
            (1.3125 * e1sq - 1.71875 * e1sq * e1sq) * Math.Sin(4.0 * mu) +
            (1.57291666667 * e1sq * e1) * Math.Sin(6.0 * mu) +
            (2.142578125 * e1sq * e1sq) * Math.Sin(8.0 * mu);

            /* compute the other necessary terms */
            double e_prime_sq = e_squared / (1.0 - e_squared);
            double sin_phi = Math.Sin(footpoint);
            double tan_phi = Math.Tan(footpoint);
            double cos_phi = Math.Cos(footpoint);
            double N = RADIUS / Math.Sqrt(1.0 - e_squared * sin_phi * sin_phi);
            double T = tan_phi * tan_phi;
            double Tsquared = T * T;
            double C = e_prime_sq * cos_phi * cos_phi;
            double Csquared = C * C;
            double denom = Math.Sqrt(1.0 - e_squared * sin_phi * sin_phi);
            double R = RADIUS * oneminuse * oneminuse / (denom * denom * denom);
            double D = x_utm / (N * K_NOT);
            double Dsquared = D * D;
            double Dfourth = Dsquared * Dsquared;

            double lambda_not = ((-180.0 + zone * 6.0) - 3.0) * DEGREES_TO_RADIANS;

            /* now, use the footpoint to compute the real latitude and longitude */
            double utm_lat = footpoint - (N * tan_phi / R) * (0.5 * Dsquared - (5.0 + 3.0 * T + 10.0 * C
                  - 4.0 * Csquared - 9.0 * e_prime_sq) * Dfourth / 24.0 + (61.0 + 90.0 * T + 298.0 * C + 45.0 * Tsquared
                  - 252.0 * e_prime_sq - 3.0 * Csquared) * Dfourth * Dsquared / 720.0);
            double utm_lng = lambda_not + (D - (1.0 + 2.0 * T + C) * Dsquared * D / 6.0
                  + (5.0 - 2.0 * C + 28.0 * T - 3.0 * Csquared + 8.0 * e_prime_sq + 24.0 * Tsquared) * Dfourth * D / 120.0) / cos_phi;

            lat = RTOD * utm_lat;
            lng = RTOD * utm_lng;
        }

        /**
         * 십진수 위경도 좌표(decimal degree)를 UTM x,y 좌표로 변환
         * @param  {number} lat     위도 (-90 ~ 90도)
         * @param  {number} lon     경도 (-180 ~ 180도)
         * @param  {number} zone    UTM zone 번호
         * @return {object}         {x: UTM x좌표, y: UTM y좌표}
         */

        private static void ConvertGeoToUtm(double lat, double lon, int zone, out double utm_x, out double utm_y)
        {
            /* first compute the necessary geodetic parameters and constants */
            double lambda_not = ((-180.0 + zone * 6.0) - 3.0) / RADIANS;
            double e_squared = 2.0 * FLATTENING - FLATTENING * FLATTENING;
            double e_fourth = e_squared * e_squared;
            double e_sixth = e_fourth * e_squared;
            double e_prime_sq = e_squared / (1.0 - e_squared);
            double sin_phi = Math.Sin(lat);
            double tan_phi = Math.Tan(lat);
            double cos_phi = Math.Cos(lat);
            double N = RADIUS / Math.Sqrt(1.0 - e_squared * sin_phi * sin_phi);
            double T = tan_phi * tan_phi;
            double C = e_prime_sq * cos_phi * cos_phi;
            double M = RADIUS * ((1.0 - e_squared * 0.25 - 0.046875 * e_fourth - 0.01953125 * e_sixth) * lat
                - (0.375 * e_squared + 0.09375 * e_fourth + 0.043945313 * e_sixth) * Math.Sin(2.0 * lat)
                + (0.05859375 * e_fourth + 0.043945313 * e_sixth) * Math.Sin(4.0 * lat) - (0.011393229 * e_sixth) * Math.Sin(6.0 * lat));
            double A = (lon - lambda_not) * cos_phi;
            double A_sq = A * A;
            double A_fourth = A_sq * A_sq;

            /* now go ahead and compute X and Y */

            double x_utm = K_NOT * N * (A + (1.0 - T + C) * A_sq * A / 6.0 + (5.0 - 18.0 * T + T * T + 72.0 * C - 58.0 * e_prime_sq) * A_fourth * A / 120.0);

            /* note:  specific to UTM, vice general trasverse mercator.
               since the origin is at the equator, M0, the M at phi_0,
               always equals zero, and I won't compute it   */

            double y_utm = K_NOT * (M + N * tan_phi * (A_sq / 2.0 + (5.0 - T + 9.0 * C + 4.0 * C * C) * A_fourth / 24.0
                         + (61.0 - 58.0 * T + T * T + 600.0 * C - 330.0 * e_prime_sq) * A_fourth * A_sq / 720.0));

            /* now correct for false easting and northing */

            if (lat < 0)
            {
                y_utm += 10000000.0;
            }
            x_utm += 500000;

            /* adds Java function returns */
            utm_x = x_utm;
            utm_y = y_utm;
        }

        /**
         * 위경도 좌표를 통해 UTM zone 반환
         * @param  {Number} slat  위도
         * @param  {Number} slon  경도
         * @return {Number}       UTM zone 번호
         */

        public static int GetUtmZone(double slat, double slon)
        {
            /* determine the zone for the given longitude
               with 6 deg wide longitudinal strips */
            double zlon = slon + 180; /* set the lon from 0-360 */
            int zone = 0;
            for (int i = 1; i <= 60; i++)
            {
                if (zlon >= (i - 1) * 6 & zlon < i * 6)
                {
                    zone = i;
                    break;
                }
            }

            /*  modify the zone number for special areas */
            if (slat >= 72 & (slon >= 0 & slon <= 36))
            {
                if (slon < 9.0)
                {
                    zone = 31;
                }
                else if (slon >= 9.0 & slon < 21)
                {
                    zone = 33;
                }
                else if (slon >= 21.0 & slon < 33)
                {
                    zone = 35;
                }
                else if (slon >= 33.0 & slon < 42)
                {
                    zone = 37;
                }
            }
            if ((slat >= 56 & slat < 64) & (slon >= 3 & slon < 12))
            {
                zone = 32;  /* extent to west ward for 3deg more */
            }
            return zone;
        }

        /**
         *  위경도 좌표 입력값이 적정한지 여부를 판단하여 반환
         * @param  {Number} lat   위도
         * @param  {Number} lng   경도
         * @return {boolean}      입력값이 적정한지 여부(true/false)
         */

        private static bool ValidateLatLng(double lat, double lng)
        {
            if (lat < -90 || lat > 90)
            {
                return false;
            }
            if (lng < -180 || lng > 180)
            {
                return false;
            }
            return true;
        }

        /**
         * 십진수 위경도 좌표(decimal degree)를 UTM x,y 좌표로 변환
         * @param  {Number} lat   위도
         * @param  {Number} lng   경도
         * @return {object}       {x: UTM x좌표, y: UTM y좌표, zone: UTM zone 번호 }
         */

        public static bool LatLngToUtm(double lat, double lng, out double x_utm, out double y_utm, out int outzone)
        {
            bool rslt = true;
            bool isInputValid = ValidateLatLng(lat, lng);
            if (!isInputValid)
            {
                rslt = false;
            }

            int zone = GetUtmZone(lat, lng);
            double latRad = DTOR * lat;
            double lngRad = DTOR * lng;

            ConvertGeoToUtm(latRad, lngRad, zone, out double utm_x, out double utm_y);

            if (lat >= 84.0 | lat < -80.0)
            {
                rslt = false;
            }

            x_utm = utm_x;
            y_utm = utm_y;
            outzone = zone;

            return rslt;
        }
    }
}