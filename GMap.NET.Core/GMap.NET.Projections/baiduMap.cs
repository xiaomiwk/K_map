using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Drawing;
using System.Linq;
using System.Text;

namespace GMap.NET.Projections
{
    internal class baiduMap
    {
        /// <summary>
        /// 根据经纬度坐标计算该点在屏幕中的坐标
        /// </summary>
        /// <param name="p">要计算的经纬度</param>
        /// <param name="center">屏幕中心经纬度</param>
        /// <param name="zoom">地图当前缩放级别</param>
        /// <param name="screen_size">屏幕大小</param>
        /// <returns></returns>
        public static GPoint GetScreenLocationByLatLng(PointLatLng p, PointLatLng center, int zoom, Size screen_size)
        {
            GPoint dp = GetLocationByLatLng(p, zoom);  //目标点的像素坐标
            GPoint cp = GetLocationByLatLng(center, zoom);  //中心点的像素坐标

            //计算目标点和中心点像素坐标差
            double delta_x = dp.X - cp.X;
            double delta_y = dp.Y - cp.Y;

            //转换成屏幕坐标系统的坐标 并返回
            return new GPoint((int)((float)screen_size.Width / 2 + delta_x), (int)((float)screen_size.Height / 2 + (-1) * delta_y));

        }

        /// <summary>
        /// 根据屏幕坐标计算该点的经纬度坐标
        /// </summary>
        /// <param name="p"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        /// <returns></returns>
        public static PointLatLng GetLatLngByScreenLocation(GPoint p, PointLatLng center, int zoom, Size screen_size)
        {
            GPoint cp = GetLocationByLatLng(center, zoom);  //中心点像素坐标

            //目标点与中心点屏幕坐标差
            long delta_x = p.X - screen_size.Width / 2;
            long delta_y = p.Y - screen_size.Height / 2;

            GPoint dp = new GPoint(cp.X + delta_x, cp.Y + delta_y * (-1));  //目标点像素坐标

            return GetLatLngByLocation(dp, zoom);
        }

        /// <summary>
        /// 根据经纬度坐标计算该点的像素坐标
        /// </summary>
        /// <param name="p">要计算的经纬度</param>
        /// <param name="zoom">地图当前缩放级别</param>
        /// <returns></returns>
        public static GPoint GetLocationByLatLng(PointLatLng p, int zoom)
        {
            double[] mer_p = LatLng2Mercator(p);  //墨卡托坐标
            return new GPoint((long)(mer_p[0] / Math.Pow(2, 18 - zoom)), (long)(mer_p[1] / Math.Pow(2, 18 - zoom)));
        }

        /// <summary>
        /// 根据像素坐标计算该点的经纬度坐标
        /// </summary>
        /// <param name="p">要计算的像素坐标</param>
        /// <param name="zoom">地图缩放级别</param>
        /// <returns></returns>
        public static PointLatLng GetLatLngByLocation(GPoint p, int zoom)
        {
            double[] mer_p = new double[] { (double)(p.X * Math.Pow(2, 18 - zoom)), (double)(p.Y * Math.Pow(2, 18 - zoom)) };  //墨卡托坐标
            return Mercator2LatLng(mer_p);
        }

        //以下是根据百度地图JavaScript API破解得到 百度坐标<->墨卡托坐标 转换算法
        private static double[] array1 = { 75, 60, 45, 30, 15, 0 };
        private static double[] array3 = { 12890594.86, 8362377.87, 5591021, 3481989.83, 1678043.12, 0 };
        private static double[][] array2 = {new double[]{-0.0015702102444, 111320.7020616939, 1704480524535203, -10338987376042340, 26112667856603880, -35149669176653700, 26595700718403920, -10725012454188240, 1800819912950474, 82.5}
                                               ,new double[]{0.0008277824516172526, 111320.7020463578, 647795574.6671607, -4082003173.641316, 10774905663.51142, -15171875531.51559, 12053065338.62167, -5124939663.577472, 913311935.9512032, 67.5}
                                               ,new double[]{0.00337398766765, 111320.7020202162, 4481351.045890365, -23393751.19931662, 79682215.47186455, -115964993.2797253, 97236711.15602145, -43661946.33752821, 8477230.501135234, 52.5}
                                               ,new double[]{0.00220636496208, 111320.7020209128, 51751.86112841131, 3796837.749470245, 992013.7397791013, -1221952.21711287, 1340652.697009075, -620943.6990984312, 144416.9293806241, 37.5}
                                               ,new double[]{-0.0003441963504368392, 111320.7020576856, 278.2353980772752, 2485758.690035394, 6070.750963243378, 54821.18345352118, 9540.606633304236, -2710.55326746645, 1405.483844121726, 22.5}
                                               ,new double[]{-0.0003218135878613132, 111320.7020701615, 0.00369383431289, 823725.6402795718, 0.46104986909093, 2351.343141331292, 1.58060784298199, 8.77738589078284, 0.37238884252424, 7.45}};
        private static double[][] array4 = {new double[]{1.410526172116255e-8, 0.00000898305509648872, -1.9939833816331, 200.9824383106796, -187.2403703815547, 91.6087516669843, -23.38765649603339, 2.57121317296198, -0.03801003308653, 17337981.2}
                                               ,new double[]{-7.435856389565537e-9, 0.000008983055097726239, -0.78625201886289, 96.32687599759846, -1.85204757529826, -59.36935905485877, 47.40033549296737, -16.50741931063887, 2.28786674699375, 10260144.86}
                                               ,new double[]{-3.030883460898826e-8, 0.00000898305509983578, 0.30071316287616, 59.74293618442277, 7.357984074871, -25.38371002664745, 13.45380521110908, -3.29883767235584, 0.32710905363475, 6856817.37}
                                               ,new double[]{-1.981981304930552e-8, 0.000008983055099779535, 0.03278182852591, 40.31678527705744, 0.65659298677277, -4.44255534477492, 0.85341911805263, 0.12923347998204, -0.04625736007561, 4482777.06}
                                               ,new double[]{3.09191371068437e-9, 0.000008983055096812155, 0.00006995724062, 23.10934304144901, -0.00023663490511, -0.6321817810242, -0.00663494467273, 0.03430082397953, -0.00466043876332, 2555164.4}
                                               ,new double[]{2.890871144776878e-9, 0.000008983055095805407, -3.068298e-8, 7.47137025468032, -0.00000353937994, -0.02145144861037, -0.00001234426596, 0.00010322952773, -0.00000323890364, 826088.5}};

        private static double[] LatLng2Mercator(PointLatLng p)
        {
            double[] arr = null;
            //double n_lat = p.Lat > 74 ? 74 : p.Lat;
            //n_lat = n_lat < -74 ? -74 : n_lat;

            for (var i = 0; i < array1.Length; i++)
            {
                if (p.Lat >= array1[i])
                {
                    arr = array2[i];
                    break;
                }
            }
            if (arr == null)
            {
                for (var i = array1.Length - 1; i >= 0; i--)
                {
                    if (p.Lat <= -array1[i])
                    {
                        arr = array2[i];
                        break;
                    }
                }
            }
            return Convertor(p.Lng, p.Lat, arr);
        }

        private static PointLatLng Mercator2LatLng(double[] p)
        {
            double[] arr = null;
            for (var i = 0; i < array3.Length; i++)
            {
                if (p[1] >= array3[i])
                {
                    arr = array4[i];
                    break;
                }
            }
            double[] res = Convertor(p[0], p[1], arr);
            return new PointLatLng(res[1], res[0]);
        }

        private static double[] Convertor(double x, double y, double[] param)
        {
            var T = param[0] + param[1] * Math.Abs(x);
            var cC = Math.Abs(y) / param[9];
            var cF = param[2] + param[3] * cC + param[4] * cC * cC + param[5] * cC * cC * cC + param[6] * cC * cC * cC * cC + param[7] * cC * cC * cC * cC * cC + param[8] * cC * cC * cC * cC * cC * cC;
            T *= (x < 0 ? -1 : 1);
            cF *= (y < 0 ? -1 : 1);
            return new double[] { T, cF };
        }
    }
}
