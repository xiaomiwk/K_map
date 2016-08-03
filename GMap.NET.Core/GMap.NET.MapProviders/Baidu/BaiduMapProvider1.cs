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

    public class BaiduMapProvider1 : BaiduMapProviderBase
    {
        public static readonly BaiduMapProvider1 Instance;

        readonly Guid id = new Guid("608748FC-5FDD-4d3a-9027-356F24A755E9");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "百度2D图测试";

        private string _地址 = "http://online{3}.map.bdimg.com/tile/?qt=tile&x={0}&y={1}&z={2}&styles=pl&udt=20150713&scaler=1";

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override PureProjection Projection
        {
            get { return BaiduProjection1.Instance; }
            //get { return MercatorProjection.Instance; }
        }

        static BaiduMapProvider1()
        {
            Instance = new BaiduMapProvider1();
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            return GetTileImageUsingHttp(string.Format(_地址, pos.X, pos.Y, zoom, (pos.X & 1) == 0 ? "1" : "2"));
        }

    }
}
