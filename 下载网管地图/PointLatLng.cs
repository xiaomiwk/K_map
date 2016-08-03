using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 下载网管地图
{
    public class PointLatLng
    {
        public double Lng { get; set; }
        public double Lat { get; set; }

        public PointLatLng(double Lat, double Lng)
        {
            this.Lat = Lat;
            this.Lng = Lng;
        }
    }
}
