using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET.Projections;

namespace GMap.NET.Projections
{
    public class BaiduProjection : PureProjection
    {
        public static readonly BaiduProjection Instance = new BaiduProjection();

        static readonly double MinLatitude = -85.05112878;
        static readonly double MaxLatitude = 85.05112878;
        static readonly double MinLongitude = -180;
        static readonly double MaxLongitude = 180;

        public override RectLatLng Bounds
        {
            get
            {
                return RectLatLng.FromLTRB(MinLongitude, MaxLatitude, MaxLongitude, MinLatitude);
            }
        }

        readonly GSize tileSize = new GSize(256, 256);
        public override GSize TileSize
        {
            get
            {
                return tileSize;
            }
        }

        public override double Axis
        {
            get
            {
                return 6378137;
            }
        }

        public override double Flattening
        {
            get
            {
                return (1.0 / 298.257223563);
            }
        }

        public override GPoint FromLatLngToPixel(double lat, double lng, int zoom)
        {
            lat -= 0.1748;
            lng += 0.0014;

            GPoint ret = GPoint.Empty;
            lat = Clip(lat, MinLatitude, MaxLatitude);
            lng = Clip(lng, MinLongitude, MaxLongitude);
            GSize s = GetTileMatrixSizePixel(zoom);
            long mapSizeX = s.Width;
            long mapSizeY = s.Height;
            double xMercatorTileNum = (Math.Pow(2.0, zoom - 26) * (Math.PI * lng * Axis / 180.0));
            double xAxisPixelLength = xMercatorTileNum * 256;
            ret.X = (long)(mapSizeX * 0.5 + xAxisPixelLength);
            double yMercatorTileNum = (Math.Pow(2.0, zoom - 26) * Axis * Math.Log(Math.Tan(Math.PI * lat / 180.0) + 1.0 / Math.Cos(Math.PI * lat / 180.0)));
            double yAxisPixelLength = yMercatorTileNum * 256; ret.Y = (long)(mapSizeY * 0.5 - yAxisPixelLength);

            return ret;
        }

        public override PointLatLng FromPixelToLatLng(long x, long y, int zoom)
        {
            PointLatLng ret = PointLatLng.Empty;
            GSize s = GetTileMatrixSizePixel(zoom);
            double mapSizeX = s.Width;
            double mapSizeY = s.Height;
            double xMercatorBaidu = x - 0.5 * mapSizeX;
            double yMercatorBaidu = -y + 0.5 * mapSizeY;
            double xTileNum = xMercatorBaidu / 256;
            double yTileNum = yMercatorBaidu / 256;
            int tileXNum = (int)Math.Floor(xTileNum);
            int tileYNum = (int)Math.Floor(yTileNum);
            double xRelativeTileCoord = xMercatorBaidu % 256 / 256; xRelativeTileCoord = xRelativeTileCoord > 0 ? xRelativeTileCoord : 1 + xRelativeTileCoord;
            double yRelativeTileCoord = yMercatorBaidu % 256 / 256; yRelativeTileCoord = yRelativeTileCoord > 0 ? 1 - yRelativeTileCoord : -yRelativeTileCoord;
            long xPixelCoord = (long)(xRelativeTileCoord * 256);
            long yPixelCoord = (long)(yRelativeTileCoord * 256);
            double tileNumX = (tileXNum + (double)xPixelCoord / 256);
            ret.Lng = (Math.Pow(2.0, 26 - zoom) * (tileNumX)) / (Math.PI * Axis) * 180;
            double eIndex = Math.Pow(2.0, 26 - zoom) * (tileYNum + 1 - (double)yPixelCoord / 256) / Axis;
            ret.Lat = 360 * Math.Atan(Math.Pow(Math.E, eIndex)) / Math.PI - 90;

            ret.Lat += 0.1748;
            ret.Lng -= 0.0014;

            return ret;
        }

        public override GSize GetTileMatrixMinXY(int zoom)
        {
            return new GSize(0, 0);
        }

        public override GSize GetTileMatrixMaxXY(int zoom)
        {
            long xy = (1 << zoom);
            return new GSize(xy - 1, xy - 1);
        }
    }
}
