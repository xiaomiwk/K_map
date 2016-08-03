using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using GMap.NET.MapProviders;
using GMap.NET.publics;

namespace GMap.NET.CacheProviders
{
    public class HttpPureImageCache : PureImageCache
    {
        private Dictionary<int, GMapProvider> _地图字典 = new Dictionary<int, GMapProvider>();

        private string _host;

        public static string UserAgent = string.Format("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:{0}.0) Gecko/{2}{3:00}{4:00} Firefox/{0}.0.{1}", Stuff.random.Next(3, 14), Stuff.random.Next(1, 10), Stuff.random.Next(DateTime.Today.Year - 4, DateTime.Today.Year), Stuff.random.Next(12), Stuff.random.Next(30));

        public static int TimeoutMs = 5 * 1000;
        /// <summary>
        /// Gets or sets the value of the Referer HTTP header.
        /// </summary>
        public string RefererUrl = string.Empty;

        public string Copyright = string.Empty;

        static readonly string requestAccept = "*/*";


        public HttpPureImageCache(string __host)
        {
            _host = __host;
        }

        public PureImage GetImageFromCache(int type, GPoint pos, int zoom)
        {
            if (!_地图字典.ContainsKey(type))
            {
                _地图字典[type] = GMapProviders.TryGetProvider(type);
            }
            var __地图 = _地图字典[type];
            var url = string.Format("{0}/{1}/{2}/{3}/{4}", _host, __地图.Name, zoom, pos.X, pos.Y);
            return GetTileImageUsingHttp(url);
        }

        private PureImage GetTileImageUsingHttp(string url)
        {
            PureImage ret = null;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = UserAgent;
            request.ReadWriteTimeout = TimeoutMs * 6;
            request.Accept = requestAccept;
            request.Referer = RefererUrl;
            request.Timeout = TimeoutMs;

            try
            {
                using (var response = request.GetResponse())
                {
                    if (response.ContentType.Contains("image"))
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            MemoryStream data = Stuff.CopyStream(responseStream, false);

                            Debug.WriteLine("Response[" + data.Length + " bytes]: " + url);

                            if (data.Length > 0)
                            {
                                ret = GMapProvider.TileImageProxy.FromArray(data.GetBuffer());

                                if (ret != null)
                                {
                                    ret.Data = data;
                                    ret.Data.Position = 0;
                                }
                                else
                                {
                                    data.Dispose();
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("CheckTileImageHttpResponse[false]: " + url);
                    }
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetTileImageUsingHttp: {0}, {1}", url, ex);
            }
            return ret;
        }

    }
}
