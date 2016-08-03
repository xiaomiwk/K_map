using System;
using GMap.NET;

namespace 显示地图
{
    public static class HGPS坐标转换
    {
        public static M经纬度 原始坐标转谷歌坐标(M经纬度 原始坐标)
        {
            var __gcj = H坐标转换.gps84_To_Gcj02(原始坐标.纬度, 原始坐标.经度);
            return new M经纬度(__gcj.Lng, __gcj.Lat) { 类型 = E坐标类型.谷歌 };
        }

        public static M经纬度 谷歌坐标转百度坐标(M经纬度 谷歌坐标)
        {
            var __bd = H坐标转换.gcj02_To_Bd09(谷歌坐标.纬度, 谷歌坐标.经度);
            return new M经纬度(__bd.Lng, __bd.Lat) { 类型 = E坐标类型.百度 };
        }

        public static M经纬度 谷歌坐标转原始坐标(M经纬度 谷歌坐标)
        {
            var __bd = H坐标转换.gcj02_To_Bd09(谷歌坐标.纬度, 谷歌坐标.经度);
            var __gps84 = H坐标转换.bd09_To_Gps84(__bd.Lat, __bd.Lng);
            return new M经纬度(__gps84.Lng, __gps84.Lat) { 类型 = E坐标类型.设备 };
        }

        public static M经纬度 百度坐标转原始坐标(M经纬度 百度坐标)
        {
            var __gps84 = H坐标转换.bd09_To_Gps84(百度坐标.纬度, 百度坐标.经度);
            return new M经纬度(__gps84.Lng, __gps84.Lat) { 类型 = E坐标类型.设备 };
        }

        public static M经纬度 百度坐标转谷歌坐标(M经纬度 百度坐标)
        {
            var __gcj = H坐标转换.bd09_To_Gcj02(百度坐标.纬度, 百度坐标.经度);
            return new M经纬度(__gcj.Lng, __gcj.Lat) { 类型 = E坐标类型.谷歌 };
        }

        public static M经纬度 转原始坐标(M经纬度 __坐标)
        {
            switch (__坐标.类型)
            {
                case E坐标类型.设备:
                    return __坐标;
                case E坐标类型.谷歌:
                    return 谷歌坐标转原始坐标(__坐标);
                case E坐标类型.百度:
                    return 百度坐标转原始坐标(__坐标);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
