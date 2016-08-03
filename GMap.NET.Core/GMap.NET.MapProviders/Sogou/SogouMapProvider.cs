using System;
using System.Net;
using GMap.NET.MapProviders;
using GMap.NET.Projections;

namespace GMap.NET.MapProviders
{
    public abstract class SogouMapProviderBase : GMapProvider
    {
        public SogouMapProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://map.sougou.com";
            Copyright = string.Format("©{0} Sogou Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);
        }

        public override PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

        GMapProvider[] overlays;
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

        protected override bool CheckTileImageHttpResponse(WebResponse response)
        {
            var pass = base.CheckTileImageHttpResponse(response);
            if (!pass)
            {
                return response.ResponseUri.AbsoluteUri.EndsWith(".png") || response.ResponseUri.AbsoluteUri.EndsWith(".JPG");
            }

            return true;
        }
    }

    public class SogouMapProvider : SogouMapProviderBase
    {
        public static readonly SogouMapProvider Instance;

        readonly Guid id = new Guid("7E2A0100-7A75-4c49-A2C9-EE1C73947E10");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "SohuMap";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        static SogouMapProvider()
        {
            Instance = new SogouMapProvider();
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

            var zoomLevel = 729 - zoom;
            if (zoomLevel == 710)
            {
                zoomLevel = 792;
            }

            var blo = Math.Floor(numX / 200);
            var bla = Math.Floor(numY / 200);
            string blos, blas;
            if (blo < 0)
            {
                blos = "M" + (-blo);
            }
            else
            {
                blos = blo.ToString();
            }

            if (bla < 0)
            {
                blas = "M" + (-bla);
            }
            else
            {
                blas = bla.ToString();
            }

            var x = numX.ToString().Replace("-", "M");
            var y = numY.ToString().Replace("-", "M");


            //http://p1.go2map.com/seamless1/0/174/720/0/0/95_25.png
            string url = string.Format(UrlFormat, "1", zoomLevel, blos, blas, x, y);
            Console.WriteLine("url:" + url);
            return url;
        }

        static readonly string UrlFormat = "http://p{0}.go2map.com/seamless1/0/174/{1}/{2}/{3}/{4}_{5}.png";
    }
}
