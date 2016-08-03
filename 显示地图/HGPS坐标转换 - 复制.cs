using System;

namespace 显示地图
{
    public static class HGPS坐标转换
    {
        #region 原始坐标转谷歌坐标
        const double pi = 3.14159265358979324;

        const double a = 6378245.0;

        const double ee = 0.00669342162296594323;

        // World Geodetic System ==> Mars Geodetic System
        public static void 原始坐标转谷歌坐标(double wgLat, double wgLon, out double mgLat, out double mgLon)
        {
            if (outOfChina(wgLat, wgLon))
            {
                mgLat = wgLat;
                mgLon = wgLon;
                return;
            }
            double dLat = transformLat(wgLon - 105.0, wgLat - 35.0);
            double dLon = transformLon(wgLon - 105.0, wgLat - 35.0);
            double radLat = wgLat / 180.0 * pi;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            mgLat = wgLat + dLat;
            mgLon = wgLon + dLon;
        }

        public static M经纬度 原始坐标转谷歌坐标(M经纬度 原始坐标)
        {
            double __谷歌经度;
            double __谷歌纬度;
            原始坐标转谷歌坐标(原始坐标.纬度, 原始坐标.经度, out __谷歌纬度, out __谷歌经度);
            return new M经纬度(__谷歌经度, __谷歌纬度) { 类型 = E坐标类型.谷歌 };
        }

        static bool outOfChina(double lat, double lon)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }

        static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0 * pi)) * 2.0 / 3.0;
            return ret;
        }

        #endregion

        #region 百度坐标与谷歌坐标互转

        const double x_pi = 3.14159265358979324 * 3000.0 / 180.0;

        public static void 谷歌坐标转百度坐标(double gg_lat, double gg_lon, out double bd_lat, out double bd_lon)
        {
            double x = gg_lon, y = gg_lat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            bd_lon = z * Math.Cos(theta) + 0.0065;
            bd_lat = z * Math.Sin(theta) + 0.006;
        }

        public static M经纬度 谷歌坐标转百度坐标(M经纬度 谷歌坐标)
        {
            double __百度经度;
            double __百度纬度;
            谷歌坐标转百度坐标(谷歌坐标.纬度, 谷歌坐标.经度, out __百度纬度, out __百度经度);
            return new M经纬度(__百度经度, __百度纬度) { 类型 = E坐标类型.百度 };
        }

        public static void 百度坐标转谷歌坐标(double bd_lat, double bd_lon, out double gg_lat, out double gg_lon)
        {
            double x = bd_lon - 0.0065, y = bd_lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            gg_lon = z * Math.Cos(theta);
            gg_lat = z * Math.Sin(theta);
        }

        public static M经纬度 百度坐标转谷歌坐标(M经纬度 百度坐标)
        {
            double __谷歌经度;
            double __谷歌纬度;
            百度坐标转谷歌坐标(百度坐标.纬度, 百度坐标.经度, out __谷歌纬度, out __谷歌经度);
            return new M经纬度(__谷歌经度, __谷歌纬度) { 类型 = E坐标类型.谷歌 };
        }

        #endregion
    }
}
