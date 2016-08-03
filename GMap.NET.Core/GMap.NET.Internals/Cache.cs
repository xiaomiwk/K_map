using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using GMap.NET.CacheProviders;
using System.Security.Cryptography;

namespace GMap.NET.publics
{

    /// <summary>
    /// cache system for tiles, geocoding, etc...
    /// </summary>
    public class Cache : Singleton<Cache>
    {
        /// <summary>
        /// abstract image cache
        /// </summary>
        public PureImageCache ImageCache;

        /// <summary>
        /// second level abstract image cache
        /// </summary>
        public PureImageCache ImageCacheSecond;

        public Cache()
        {
            #region singleton check
            if (Instance != null)
            {
                throw (new System.Exception("You have tried to create a new singleton class where you should have instanced it. Replace your \"new class()\" with \"class.Instance\""));
            }
            #endregion

            ImageCache = new SQLitePureImageCache();
            //ImageCacheSecond = new HttpPureImageCache("http://127.0.0.1:7777");
        }
    }
}
