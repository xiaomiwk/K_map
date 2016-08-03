using System;
using System.Collections.Generic;
using System.Text;

namespace GMap.NET.MapProviders
{
    public class SogouSateliteMapProvider : SogouMapProviderBase
    {
        public static readonly SogouSateliteMapProvider Instance;

        readonly Guid id = new Guid("7F082330-5635-40c8-82C3-C834FCD4683F");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "SohuMapSatelite";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        static SogouSateliteMapProvider()
        {
            Instance = new SogouSateliteMapProvider();
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


            //http://hbpic1.go2map.com/seamless/0/180/717/3/1/750_258.JPG
            string url = string.Format(UrlFormat, "1", zoomLevel, blos, blas, x, y);
            Console.WriteLine("url:" + url);
            return url;
        }

        static readonly string UrlFormat = "http://hbpic1.go2map.com/seamless/0/180/{1}/{2}/{3}/{4}_{5}.JPG";
    }
}
