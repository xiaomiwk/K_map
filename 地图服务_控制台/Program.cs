using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 地图服务;

namespace 地图服务_控制台
{
    class Program
    {
        static void Main(string[] args)
        {
            //SQLiteTile.获取地图路径 = (__地图源 => @"D:\Temp\地图\E都市.MBLites");
            //SQLiteTile.查询语句 = "SELECT images.tile_data FROM images join map on images.tile_id = map.tile_id WHERE map.tile_column={0} AND map.tile_row={1} AND map.zoom_level={2}";

            var __SQLiteTile = new SQLiteTile();
            __SQLiteTile.获取地图路径 = (__地图源 => @"E:\地图\南京市_谷歌2D图_9-17.gmdb");

            var host = new TileHttpHost();
            host.Start(7777, __SQLiteTile);
            Console.WriteLine("TileHttpHost Started");
            Console.ReadLine();
            host.Stop();
        }
    }
}
