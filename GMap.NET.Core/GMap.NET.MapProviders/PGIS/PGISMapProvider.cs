using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using GMap.NET.publics;
using GMap.NET.Projections;

namespace GMap.NET.MapProviders
{

    public abstract class PGISMapProviderBase : GMapProvider
    {
        public PGISMapProviderBase()
        {
            MaxZoom = null;
            Copyright = string.Format("© PGISMap - Map data ©{0} PGISMap", DateTime.Today.Year);
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
    }

    public class PGISMapProvider : PGISMapProviderBase
    {
        public static readonly PGISMapProvider Instance;

        PGISMapProvider()
        {
        }

        static PGISMapProvider()
        {
            Instance = new PGISMapProvider();
        }

        #region GMapProvider Members

        readonly Guid id = new Guid("0521335C-92EC-47A8-98A5-6FD333DDA9C1");
        public override Guid Id
        {
            get
            {
                return id;
            }
        }

        readonly string name = "PGIS2D图";
        public override string Name
        {
            get
            {
                return name;
            }
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

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, string.Empty);

            return GetTileImageUsingHttp(url);
        }

        #endregion

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            //return string.Format(UrlFormat, "10.73.6.181", zoom, pos.X, pos.Y);


            //PointLatLng p1 = Projection.FromPixelToLatLng(pos, zoom);
            //p1.Lat += 9.57844111;
            //p1.Lng += 33;
            //pos = Projection.FromLatLngToPixel(p1, zoom);

            zoom = zoom - 1;
            var offsetX = Math.Pow(2, zoom);
            var offsetY = offsetX - 1;

            var numX = pos.X - offsetX;
            var numY = -pos.Y + offsetY;

            zoom = zoom + 1;

            switch (zoom)
            {
                case 8:
                    numX += 24;
                    numY += -7;
                    break;
                case 9:
                    numX += 48;
                    numY += -15;
                    break;
                case 10:
                    numX += 97;
                    numY += -30;
                    break;
                case 11:
                    numX += 194;
                    numY += -60;
                    break;
                case 12:
                    numX += 388;
                    numY += -120;
                    break;
                case 13:
                    numX += 776;
                    numY += -240;
                    break;
                case 14:
                    numX += 1552;
                    numY += -480;
                    break;
                case 15:
                    numX += 3104;
                    numY += -960;
                    break;
                case 16:
                    numX += 6208;
                    numY += -1920;
                    break;
                case 17:
                    numX += 12416;
                    numY += -3840;
                    break;
                case 18:
                    numX += 24832;
                    numY += -7680;
                    break;
            }

            var x = numX.ToString().Replace("-", "M");
            var y = numY.ToString().Replace("-", "M");
            //var x = numX.ToString();
            //var y = numY.ToString();

            //Console.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}", zoom, pos.X, pos.Y, x, y));
            var __keys = new List<string>(System.Configuration.ConfigurationManager.AppSettings.AllKeys);
            if (__keys.Contains("PGIS_HTTPADDRESS"))
            {
                var __url = System.Configuration.ConfigurationManager.AppSettings["PGIS_HTTPADDRESS"];
                __url = __url.Replace('|', '&');
                return string.Format(__url, zoom, x, y);
            }
            return string.Format(UrlFormat, "10.73.6.181", zoom, x, y);
        }

        /// <summary>
        /// 0: 站点; 1: 端口; 2: 服务名称; 3: 地图名称; 4: 缩放等级偏移量; 5: 图片列号; 6: 图片行号; 7: 图片缩放等级;
        /// </summary>
        static readonly string UrlFormat = "http://{0}/PGIS_S_TileMapServer/Maps/Sate/EzMap?Service=getImage&Type=RGB&Zoom={1}&Col={2}&Row={3}&V=0.3";

        /*
update tiles set x = x + 97  where zoom = 10;
update tiles set y = y - 30 where zoom = 10;

update tiles set x = x + 194  where zoom = 11;
update tiles set y = y - 60 where zoom = 11;

update tiles set x = x + 388  where zoom = 12;
update tiles set y = y - 120 where zoom = 12;

update tiles set x = x + 776  where zoom = 13;
update tiles set y = y - 240 where zoom = 13;

update tiles set x = x + 1552  where zoom = 14;
update tiles set y = y - 480 where zoom = 14;

update tiles set x = x + 3104  where zoom = 15;
update tiles set y = y - 960 where zoom = 15;         
         */

    }
}
