using System;
using System.Collections.Generic;
using System.Text;

namespace GMap.NET.MapProviders
{
    public class BaiduSateliteMapProvider : BaiduMapProviderBase
    {
        public static readonly BaiduSateliteMapProvider Instance;

        readonly Guid id = new Guid("89A10DFA-2557-431a-9656-20064E8D1342");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "百度卫星图";
        public override string Name
        {
            get { return name; }
        }


        static BaiduSateliteMapProvider()
        {
            Instance = new BaiduSateliteMapProvider();
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

            //http://online1.map.bdimg.com/tile/?qt=tile&x=805&y=228&z=12&styles=sl&v=040&udt=20141102
            //http://shangetu1.map.bdimg.com/it/u=x=808;y=228;z=12;v=009;type=sate&fm=46&udt=20140929
            string url = string.Format(UrlFormat, num, x, y, zoom);
            Console.WriteLine("url:" + url);
            return url;
        }

        static readonly string UrlFormat = "http://shangetu{0}.map.bdimg.com/it/u=x={1};y={2};z={3};v=009;type=sate&fm=46&udt=20140929";
    }
}
