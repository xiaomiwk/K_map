using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET.Projections;

namespace GMap.NET.Projections
{
    public class BaiduProjection1 : PureProjection
    {
        public static readonly BaiduProjection1 Instance = new BaiduProjection1();

        static readonly double MinLatitude = -74;
        static readonly double MaxLatitude = 74;
        static readonly double MinLongitude = -180;
        static readonly double MaxLongitude = 180;


        public override RectLatLng Bounds
        {
            get
            {
                return RectLatLng.FromLTRB(MinLongitude, MaxLatitude, MaxLongitude, MinLatitude);
            }
        }

        readonly GSize tileSize = new GSize(256, 256);
        public override GSize TileSize
        {
            get
            {
                return tileSize;
            }
        }

        public override double Axis
        {
            get
            {
                return 6378137;
            }
        }

        public override double Flattening
        {
            get
            {
                return (1.0 / 298.257223563);
            }
        }

        int[] LLBAND = { 75, 60, 45, 30, 15, 0 };
        double[][] LL2MC = new double[6][];

        double[] MCBAND = { 12890594.86, 8362377.87, 5591021, 3481989.83, 1678043.12, 0 };
        double[][] MC2LL = new double[6][];

        public BaiduProjection1()
        {
            LL2MC[0] = new[] { -0.0015702102444, 111320.7020616939, 1704480524535203.0, -10338987376042340.0, 26112667856603880.0, -35149669176653700.0, 26595700718403920.0, -10725012454188240.0, 1800819912950474.0, 82.5 };
            LL2MC[1] = new[] { 0.0008277824516172526, 111320.7020463578, 647795574.6671607, -4082003173.641316, 10774905663.51142, -15171875531.51559, 12053065338.62167, -5124939663.577472, 913311935.9512032, 67.5 };
            LL2MC[2] = new[] { 0.00337398766765, 111320.7020202162, 4481351.045890365, -23393751.19931662, 79682215.47186455, -115964993.2797253, 97236711.15602145, -43661946.33752821, 8477230.501135234, 52.5 };
            LL2MC[3] = new[] { 0.00220636496208, 111320.7020209128, 51751.86112841131, 3796837.749470245, 992013.7397791013, -1221952.21711287, 1340652.697009075, -620943.6990984312, 144416.9293806241, 37.5 };
            LL2MC[4] = new[] { -0.0003441963504368392, 111320.7020576856, 278.2353980772752, 2485758.690035394, 6070.750963243378, 54821.18345352118, 9540.606633304236, -2710.55326746645, 1405.483844121726, 22.5 };
            LL2MC[5] = new[] { -0.0003218135878613132, 111320.7020701615, 0.00369383431289, 823725.6402795718, 0.46104986909093, 2351.343141331292, 1.58060784298199, 8.77738589078284, 0.37238884252424, 7.45 };

            MC2LL[0] = new[] { 1.410526172116255e-8, 0.00000898305509648872, -1.9939833816331, 200.9824383106796, -187.2403703815547, 91.6087516669843, -23.38765649603339, 2.57121317296198, -0.03801003308653, 17337981.2 };
            MC2LL[1] = new[] { -7.435856389565537e-9, 0.000008983055097726239, -0.78625201886289, 96.32687599759846, -1.85204757529826, -59.36935905485877, 47.40033549296737, -16.50741931063887, 2.28786674699375, 10260144.86 };
            MC2LL[2] = new[] { -3.030883460898826e-8, 0.00000898305509983578, 0.30071316287616, 59.74293618442277, 7.357984074871, -25.38371002664745, 13.45380521110908, -3.29883767235584, 0.32710905363475, 6856817.37 };
            MC2LL[3] = new[] { -1.981981304930552e-8, 0.000008983055099779535, 0.03278182852591, 40.31678527705744, 0.65659298677277, -4.44255534477492, 0.85341911805263, 0.12923347998204, -0.04625736007561, 4482777.06 };
            MC2LL[4] = new[] { 3.09191371068437e-9, 0.000008983055096812155, 0.00006995724062, 23.10934304144901, -0.00023663490511, -0.6321817810242, -0.00663494467273, 0.03430082397953, -0.00466043876332, 2555164.4 };
            MC2LL[5] = new[] { 2.890871144776878e-9, 0.000008983055095805407, -3.068298e-8, 7.47137025468032, -0.00000353937994, -0.02145144861037, -0.00001234426596, 0.00010322952773, -0.00000323890364, 826088.5 };
        }

        public override GPoint FromLatLngToPixel(double lat, double lng, int zoom)
        {
            var t = convertLL2MC(lng, lat);
            var __baidu = new[] { (long)(t[0] * Math.Pow(2, zoom - 18)), (long)(t[1] * Math.Pow(2, zoom - 18)) };
            return new GPoint { X = __baidu[0], Y = __baidu[1] };
        }

        public override PointLatLng FromPixelToLatLng(long x, long y, int zoom)
        {
            var mx = x / Math.Pow(2, zoom - 18);
            var my = y / Math.Pow(2, zoom - 18);
            var temp = convertMC2LL(mx, my);
            return new PointLatLng { Lng=temp[0], Lat = temp[1] };
        }

        public override GSize GetTileMatrixMinXY(int zoom)
        {
            return new GSize(0, 0);
        }

        public override GSize GetTileMatrixMaxXY(int zoom)
        {
            long xy = (1 << zoom);
            return new GSize(xy - 1, xy - 1);
        }

        /// <summary>
        /// 通过经纬度转化为块坐标
        /// </summary>
        /// <param name="__经度"></param>
        /// <param name="__纬度"></param>
        /// <param name="__层级"></param>
        /// <returns></returns>
        double[] convertLL2BlockXy(double __经度, double __纬度, int __层级)
        {
            var t = convertLL2MC(__经度, __纬度);
            var x1 = (double)(t[0] * Math.Pow(2, __层级 - 18) / 256);
            var y1 = (double)(t[1] * Math.Pow(2, __层级 - 18) / 256);
            return new[] { x1, y1 };
        }

        /// <summary>
        /// 将行列块坐标转换成经纬度
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="__层级"></param>
        /// <returns></returns>
        double[] convertBlockXy2LL(double x, double y, int __层级)
        {
            var mx = (x * 256 + 0.0) / Math.Pow(2, __层级 - 18);
            var my = (y * 256 + 0.0) / Math.Pow(2, __层级 - 18);
            return convertMC2LL(mx, my);
        }

        /// <summary>
        /// 将墨卡多转为经纬度
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        double[] convertMC2LL(double x, double y)
        {
            double[] tempArray = new double[10];
            for (var i = 0; i < MCBAND.Length; i++)
            {
                if (y >= MCBAND[i])
                {
                    tempArray = MC2LL[i];
                    break;
                }
            }
            return convertor(x, y, tempArray);
        }

        /// <summary>
        /// 将经纬度转化为墨卡多
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        double[] convertLL2MC(double x, double y)
        {
            var array = new double[10];
            for (int i = 0; i < LLBAND.Length; i++)
            {
                if (y >= LLBAND[i])
                {
                    array = LL2MC[i];
                    break;
                }
            }
            return convertor(x, y, array);
        }

        double[] convertor(double x, double y, double[] array)
        {
            double x1 = array[0] + array[1] * Math.Abs(x);
            double cB = y / array[9];
            double cE = array[2] + array[3] * cB + array[4] * cB * cB + array[5] * cB
                    * cB * cB + array[6] * cB * cB * cB * cB + array[7] * cB
                    * cB * cB * cB * cB + array[8] * cB * cB * cB * cB
                    * cB * cB;
            return new double[] { x1, cE };
        }

        /// <summary>
        /// 获得指定经度在归属列上的偏移值(单位像素)，返回值范围0-255像素。
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="column">即longitude所在的列。如果column>0时有效(此函数将不用计算longitude所在的列)</param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        int getOffsetX(double longitude, double latitude, long column, int zoom)
        {
            var temp = convertLL2BlockXy(longitude, latitude, zoom);
            if (column <= 0)
            {
                column = (long)temp[0];
            }
            var maxLongitude = convertBlockXy2LL(column + 1, temp[1], zoom)[0];
            var minLongitude = convertBlockXy2LL(column, temp[1], zoom)[0];

            if (maxLongitude == minLongitude)
            {
                return 0;
            }
            return (int)((longitude - minLongitude) * 256 / (maxLongitude - minLongitude));
        }

        /// <summary>
        /// 获得指定纬度在归属行上的偏移值(单位像素)，返回值范围0-255像素。
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="row">此行是通过latitude算出来的,即latitude所在的行。如果row>0时有效(此函数将不用计算latitude所在的行)</param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        int getOffsetY(double longitude, double latitude, long row, int zoom)
        {
            var temp = convertLL2BlockXy(longitude, latitude, zoom);
            if (row <= 0)
            {
                row = (long)temp[1];
            }

            var maxLatitude = convertBlockXy2LL(temp[0], row + 1, zoom)[1];
            var minLatitude = convertBlockXy2LL(temp[0], row, zoom)[1];

            if (maxLatitude == minLatitude)
            {
                return 0;
            }
            return (int)((maxLatitude - latitude) * 256 / (maxLatitude - minLatitude));
        }

    }
}
