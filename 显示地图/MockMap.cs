using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace 显示地图
{
    class MockMap : GMapProvider
    {
        public static readonly MockMap 单实例 = new MockMap();

        GMapProvider[] overlays;

        private static byte[] _默认数据;

        private static string __路径;

        static MockMap()
        {
            __路径 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images\\背景图.png");
            _默认数据 = File.ReadAllBytes(__路径);
        }

        private MockMap()
        {
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            var __PureImage = new GMapImage
            {
                Data = new MemoryStream(_默认数据, 0, _默认数据.Length, false, true) { Position = 0 }
            };
            __PureImage.Img = Image.FromStream(__PureImage.Data);
            return __PureImage;
        }

        public override Guid Id
        {
            get { return new Guid("608748FC-5FDD-4d3a-9027-356F24A755E6"); ; }
        }

        public override string Name
        {
            get { return "NoMap"; }
        }

        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }

        public override PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

    }
}
