using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace 下载网管地图
{
    class B下载百度地图
    {
        private string _偶数地址 = "http://shangetu4.map.bdimg.com/it/u=x={0};y={1};z={2};v=018;type=web&fm=44&udt=20131115";
        private string _奇数地址 = "http://shangetu3.map.bdimg.com/it/u=x={0};y={1};z={2};v=018;type=web&fm=44&udt=20131115";

        int[] LLBAND = { 75, 60, 45, 30, 15, 0 };
        double[][] LL2MC = new double[6][];

        public B下载百度地图()
        {
            LL2MC[0] = new[] { -0.0015702102444, 111320.7020616939, 1704480524535203.0, -10338987376042340.0, 26112667856603880.0, -35149669176653700.0, 26595700718403920.0, -10725012454188240.0, 1800819912950474.0, 82.5 };
            LL2MC[1] = new[] { 0.0008277824516172526, 111320.7020463578, 647795574.6671607, -4082003173.641316, 10774905663.51142, -15171875531.51559, 12053065338.62167, -5124939663.577472, 913311935.9512032, 67.5 };
            LL2MC[2] = new[] { 0.00337398766765, 111320.7020202162, 4481351.045890365, -23393751.19931662, 79682215.47186455, -115964993.2797253, 97236711.15602145, -43661946.33752821, 8477230.501135234, 52.5 };
            LL2MC[3] = new[] { 0.00220636496208, 111320.7020209128, 51751.86112841131, 3796837.749470245, 992013.7397791013, -1221952.21711287, 1340652.697009075, -620943.6990984312, 144416.9293806241, 37.5 };
            LL2MC[4] = new[] { -0.0003441963504368392, 111320.7020576856, 278.2353980772752, 2485758.690035394, 6070.750963243378, 54821.18345352118, 9540.606633304236, -2710.55326746645, 1405.483844121726, 22.5 };
            LL2MC[5] = new[] { -0.0003218135878613132, 111320.7020701615, 0.00369383431289, 823725.6402795718, 0.46104986909093, 2351.343141331292, 1.58060784298199, 8.77738589078284, 0.37238884252424, 7.45 };
        }

        public void 异步下载(int __最小级别, int __最大级别, double __左上经度, double __左上纬度, double __右下经度, double __右下纬度, String __路径)
        {

        }

        public event Action<int> 下载进度变化;

        public void 停止异步下载()
        {

        }

        public void 下载(int __最小级别, int __最大级别, double __左上经度, double __左上纬度, double __右下经度, double __右下纬度, String __路径)
        {
            int[] __左上角 = convertLL2BlockXy(__最小级别, __左上经度, __左上纬度);
            int __最大Y坐标 = __左上角[1];
            int __最小X坐标 = __左上角[0];

            int[] __右下角 = convertLL2BlockXy(__最小级别, __右下经度, __右下纬度);
            int __最小Y坐标 = __右下角[1];
            int __最大X坐标 = __右下角[0];


            for (int __层级 = __最小级别; __层级 <= __最大级别; __层级++) // 级别设置
            {
                var __层目录 = Path.Combine(__路径, __层级.ToString());
                if (!Directory.Exists(__层目录))
                {
                    Directory.CreateDirectory(__层目录);
                }
                var __层内最小Y坐标 = (int)(Math.Pow(2, __层级 - __最小级别) * __最小Y坐标);
                var __层内最大Y坐标 = (int)(Math.Pow(2, __层级 - __最小级别) * __最大Y坐标);

                for (int __Y坐标 = __层内最小Y坐标; __Y坐标 <= __层内最大Y坐标; __Y坐标++)
                {
                    var __纬度目录 = Path.Combine(__层目录, __Y坐标.ToString());
                    if (!Directory.Exists(__纬度目录))
                    {
                        Directory.CreateDirectory(__纬度目录);
                    }
                    var __层内最小X坐标 = (int)(Math.Pow(2, __层级 - __最小级别) * __最小X坐标);
                    var __层内最小大坐标 = (int)(Math.Pow(2, __层级 - __最小级别) * __最大X坐标);
                    for (int __X坐标 = __层内最小X坐标; __X坐标 <= __层内最小大坐标; __X坐标++)
                    {
                        var __图片路径 = Path.Combine(__纬度目录, __X坐标 + ".png");
                        var __下载文件 = new FileInfo(__图片路径);
                        if (__下载文件.Exists) continue;
                        FileStream __文件流;
                        try
                        {
                            __文件流 = __下载文件.Create();
                        }
                        catch (IOException e)
                        {
                            System.Diagnostics.Debug.WriteLine(e.Message);
                            throw new ApplicationException("创建失败: " + __图片路径);
                        }
                        var __图片地址 = string.Format((__X坐标 & 1) == 0 ? _偶数地址 : _奇数地址, __X坐标, __Y坐标, __层级);
                        try
                        {
                            var __请求 = (HttpWebRequest)WebRequest.Create(__图片地址);
                            var __响应 = (HttpWebResponse)__请求.GetResponse();
                            var __接收流 = __响应.GetResponseStream();
                            var __接收缓冲 = new byte[1000];
                            if (__接收流 != null)
                            {
                                int __接收长度 = __接收流.Read(__接收缓冲, 0, 1000);
                                while (__接收长度 > 0)
                                {
                                    __文件流.Write(__接收缓冲, 0, __接收长度);
                                    __接收长度 = __接收流.Read(__接收缓冲, 0, 1000);
                                }
                                __接收流.Close();
                            }
                            __响应.Close();
                            __文件流.Close();
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e.Message);
                            throw new ApplicationException("下载失败: " + __图片路径);
                        }
                    }
                }
            }
        }

        /**
         * 通过经纬度转化为块坐标
         * @param x
         * @param y
         */
        int[] convertLL2BlockXy(int __层级, double __经度, double __纬度)
        {
            var t = convertLL2MC(__经度, __纬度);
            var x1 = (int)(t[0] * Math.Pow(2, __层级 - 18) / 256);
            var y1 = (int)(t[1] * Math.Pow(2, __层级 - 18) / 256);
            return new[] { x1, y1 };
        }

        /**
         * 将经纬度转化为墨卡多
         * @param x
         * @param y
         * @returns {b3}
         */
        double[] convertLL2MC(double x, double y)
        {
            var array = new double[9];
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
    }
}
