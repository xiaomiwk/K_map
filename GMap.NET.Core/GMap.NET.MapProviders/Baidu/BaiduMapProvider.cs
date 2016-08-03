using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using GMap.NET.publics;
using GMap.NET.MapProviders;
using GMap.NET.Projections;

namespace GMap.NET.MapProviders
{

    public class BaiduMapProvider : BaiduMapProviderBase
    {
        public static readonly BaiduMapProvider Instance;

        readonly Guid id = new Guid("608748FC-5FDD-4d3a-9027-356F24A755E5");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "百度2D图";

        private string _地址 = "http://online{3}.map.bdimg.com/tile/?qt=tile&x={0}&y={1}&z={2}&styles=pl&udt=20150713&scaler=1";
        
        //private static string _road_url = "http://online{0}.map.bdimg.com/onlinelabel/";  //地图切片URL
        //private static string _sate_url = "http://shangetu{0}.map.bdimg.com/it/";  //卫星图切片URL

        public override string Name
        {
            get
            {
                return name;
            }
        }

        static BaiduMapProvider()
        {
            Instance = new BaiduMapProvider();
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);

            return GetTileImageUsingHttp(url);
        }

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            zoom = zoom - 1;
            var offsetX = Math.Pow(2, zoom);
            var offsetY = offsetX - 1;
            var numX = pos.X - offsetX;
            var numY = -pos.Y + offsetY;
            zoom = zoom + 1;
            var num = (pos.X + pos.Y) % 8 + 1;
            var x = numX.ToString().Replace("-", "M");
            var y = numY.ToString().Replace("-", "M");
            string url = string.Format(_地址, x, y, zoom, num);            
            Console.WriteLine("url:" + url);
            return url;
        }

    }
}
