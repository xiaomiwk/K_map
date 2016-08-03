using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.MapProviders;

namespace 显示地图
{
    /// <summary>
    /// 请将坐标统一类型
    /// </summary>
    public class H地图算法
    {
        public static bool 判断点在多边形内(M经纬度 点, List<M经纬度> 多边形)
        {
            if (多边形.Any(q => q.类型 != 点.类型))
            {
                多边形 = 多边形.Select(HGPS坐标转换.转原始坐标).ToList();
            }
            return 判断点在多边形内(new PointF((float)点.经度, (float)点.纬度), 多边形.Select(q => new PointF((float)q.经度, (float)q.纬度)).ToArray());
        }

        private static float isLeft(PointF P0, PointF P1, PointF P2)
        {
            float abc = ((P1.X - P0.X) * (P2.Y - P0.Y) - (P2.X - P0.X) * (P1.Y - P0.Y));
            return abc;
        }

        public static bool 判断点在多边形内(PointF 点, PointF[] 多边形)
        {
            int wn = 0, j = 0; //wn 计数器 j第二个点指针
            for (int i = 0; i < 多边形.Length; i++)
            {//开始循环
                if (i == 多边形.Length - 1)
                    j = 0;//如果 循环到最后一点 第二个指针指向第一点
                else
                    j = j + 1; //如果不是 ，则找下一点


                if (多边形[i].Y <= 点.Y) // 如果多边形的点 小于等于 选定点的 Y 坐标
                {
                    if (多边形[j].Y > 点.Y) // 如果多边形的下一点 大于于 选定点的 Y 坐标
                    {
                        if (isLeft(多边形[i], 多边形[j], 点) > 0)
                        {
                            wn++;
                        }
                    }
                }
                else
                {
                    if (多边形[j].Y <= 点.Y)
                    {
                        if (isLeft(多边形[i], 多边形[j], 点) < 0)
                        {
                            wn--;
                        }
                    }
                }
            }
            if (wn == 0)
            {
                return false;

            }
            else
            {
                return true;
            }

        }

        /// <param name="半径">单位:米</param>
        public static bool 判断点在圆形内(M经纬度 点, M经纬度 圆心, int 半径)
        {
            if (点.类型 != 圆心.类型)
            {
                点 = HGPS坐标转换.转原始坐标(点);
                圆心 = HGPS坐标转换.转原始坐标(圆心);
            }
            var __间距 = 测量两点间间距(点, 圆心);
            return __间距 <= 半径;
        }

        public static bool 判断点在矩形内(M经纬度 点, List<M经纬度> 多边形)
        {
            if (多边形.Any(q => q.类型 != 点.类型))
            {
                多边形 = 多边形.Select(HGPS坐标转换.转原始坐标).ToList();
            }

            double __最小经度 = 180;
            double __最大经度 = -180;
            double __最小纬度 = 90;
            double __最大纬度 = -90;
            多边形.ForEach(q =>
            {
                __最小经度 = Math.Min(__最小经度, q.经度);
                __最大经度 = Math.Max(__最大经度, q.经度);
                __最小纬度 = Math.Min(__最小纬度, q.纬度);
                __最大纬度 = Math.Max(__最大纬度, q.纬度);
            });
            return 点.经度 >= __最小经度 && 点.经度 <= __最大经度 && 点.纬度 >= __最小纬度 && 点.纬度 <= __最大纬度;
        }

        /// <returns>单位:米</returns>
        public static int 测量两点间间距(M经纬度 点1, M经纬度 点2)
        {
            if (点1.类型 != 点2.类型)
            {
                点1 = HGPS坐标转换.转原始坐标(点1);
                点2 = HGPS坐标转换.转原始坐标(点2);
            }

            return (int)(GMapProviders.EmptyProvider.Projection.GetDistance(new GMap.NET.PointLatLng(点1.纬度, 点1.经度),
                new GMap.NET.PointLatLng(点2.纬度, 点2.经度)) * 1000);

            //var latRadians1 = __纬度1 * (Math.PI / 180);
            //var latRadians2 = __纬度2 * (Math.PI / 180);
            //var latRadians = latRadians1 - latRadians2;
            //var lngRadians = __经度1 * (Math.PI / 180) - __经度2 * (Math.PI / 180);
            //var f = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(latRadians / 2), 2) + Math.Cos(latRadians1) * Math.Cos(latRadians2) * Math.Pow(Math.Sin(lngRadians / 2), 2)));
            //return f * 6378137;


            //double dLat1InRad = p1.Lat * (Math.PI / 180);
            //double dLong1InRad = p1.Lng * (Math.PI / 180);
            //double dLat2InRad = p2.Lat * (Math.PI / 180);
            //double dLong2InRad = p2.Lng * (Math.PI / 180);
            //double dLongitude = dLong2InRad - dLong1InRad;
            //double dLatitude = dLat2InRad - dLat1InRad;
            //double a = Math.Pow(Math.Sin(dLatitude / 2), 2) + Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * Math.Pow(Math.Sin(dLongitude / 2), 2);
            //double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            //double dDistance = (Axis / 1000.0) * c;
            //return dDistance;


        }

        public static int 测量多点间距离(List<M经纬度> 点集合)
        {
            if (点集合.Count > 0 && 点集合.Any(q => q.类型 != 点集合[0].类型))
            {
                点集合 = 点集合.Select(HGPS坐标转换.转原始坐标).ToList();
            }
            double distance = 0.0;
            for (int i = 1; i < 点集合.Count; i++)
            {
                distance += GMapProviders.EmptyProvider.Projection.GetDistance(new PointLatLng(点集合[i - 1].纬度, 点集合[i - 1].经度), new PointLatLng(点集合[i].纬度, 点集合[i].经度));
            }
            return (int)(distance * 1000);
        }


        /// <param name="半径">单位:米</param>
        public static bool 判断圆重叠(M经纬度 圆心1, int 半径1, M经纬度 圆心2, int 半径2)
        {
            if (圆心1.类型 != 圆心2.类型)
            {
                圆心1 = HGPS坐标转换.转原始坐标(圆心1);
                圆心2 = HGPS坐标转换.转原始坐标(圆心2);
            }

            var __间距 = 测量两点间间距(圆心1, 圆心2);
            return __间距 <= (半径1 + 半径2);
        }

    }
}
