using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using GMap.NET.CacheProviders;
using GMap.NET.publics;
using GMap.NET.MapProviders;
using System.Reflection;

namespace GMap.NET
{
    /// <summary>
    /// maps manager
    /// </summary>
    public class GMaps : Singleton<GMaps>
    {
        /// <summary>
        /// tile access mode
        /// </summary>
        public AccessMode Mode = AccessMode.ServerOnly;

        /// <summary>
        /// is map ussing cache for other url
        /// </summary>
        public bool UseUrlCache = true;

        /// <summary>
        /// is map using memory cache for tiles
        /// </summary>
        public bool UseMemoryCache = true;

        /// <summary>
        /// primary cache provider, by default: ultra fast SQLite!
        /// </summary>
        public PureImageCache PrimaryCache
        {
            get
            {
                return Cache.Instance.ImageCache;
            }
            set
            {
                Cache.Instance.ImageCache = value;
            }
        }

        /// <summary>
        /// secondary cache provider, by default: none,
        /// use it if you have server in your local network
        /// </summary>
        public PureImageCache SecondaryCache
        {
            get
            {
                return Cache.Instance.ImageCacheSecond;
            }
            set
            {
                Cache.Instance.ImageCacheSecond = value;
            }
        }

        /// <summary>
        /// MemoryCache provider
        /// </summary>
        public readonly MemoryCache MemoryCache = new MemoryCache();

        /// <summary>
        /// load tiles in random sequence
        /// </summary>
        public bool ShuffleTilesOnLoad = false;

        bool? isRunningOnMono;

        /// <summary>
        /// return true if running on mono
        /// </summary>
        /// <returns></returns>
        public bool IsRunningOnMono
        {
            get
            {
                if (!isRunningOnMono.HasValue)
                {
                    try
                    {
                        isRunningOnMono = (Type.GetType("Mono.Runtime") != null);
                        return isRunningOnMono.Value;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    return isRunningOnMono.Value;
                }
                return false;
            }
        }

        static GMaps()
        {
            if (GMapProvider.TileImageProxy == null)
            {
                try
                {
                    AppDomain d = AppDomain.CurrentDomain;
                    var AssembliesLoaded = d.GetAssemblies();

                    Assembly l = null;

                    foreach (var a in AssembliesLoaded)
                    {
                        if (a.FullName.Contains("GMap.NET.WindowsForms") || a.FullName.Contains("GMap.NET.WindowsPresentation"))
                        {
                            l = a;
                            break;
                        }
                    }

                    if (l == null)
                    {
                        var jj = Assembly.GetExecutingAssembly().Location;
                        var hh = Path.GetDirectoryName(jj);
                        var f1 = hh + Path.DirectorySeparatorChar + "GMap.NET.WindowsForms.dll";
                        var f2 = hh + Path.DirectorySeparatorChar + "GMap.NET.WindowsPresentation.dll";
                        if (File.Exists(f1))
                        {
                            l = Assembly.LoadFile(f1);
                        }
                        else if (File.Exists(f2))
                        {
                            l = Assembly.LoadFile(f2);
                        }
                    }

                    if (l != null)
                    {
                        Type t = null;

                        if (l.FullName.Contains("GMap.NET.WindowsForms"))
                        {
                            t = l.GetType("GMap.NET.WindowsForms.GMapImageProxy");
                        }
                        else if (l.FullName.Contains("GMap.NET.WindowsPresentation"))
                        {
                            t = l.GetType("GMap.NET.WindowsPresentation.GMapImageProxy");
                        }

                        if (t != null)
                        {
                            t.InvokeMember("Enable", BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("GMaps, try set TileImageProxy failed: " + ex.Message);
                }
            }
        }

        public GMaps()
        {
            #region singleton check
            if (Instance != null)
            {
                throw (new Exception("You have tried to create a new singleton class where you should have instanced it. Replace your \"new class()\" with \"class.Instance\""));
            }
            #endregion

            ServicePointManager.DefaultConnectionLimit = 5;
        }

        /// <summary>
        /// imports GMDB file to current map cache
        /// only new records will be added
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool 加载地图(string file)
        {
            var __result = SQLitePureImageCache.加载地图(file);
            return __result;
        }

        /// <summary>
        /// gets image from tile server
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="pos"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        public PureImage GetImageFrom(GMapProvider provider, GPoint pos, int zoom, out Exception result)
        {
            PureImage ret = null;
            result = null;

            try
            {
                var rtile = new RawTile(provider.DbId, pos, zoom);

                // let't check memmory first
                if (UseMemoryCache)
                {
                    var m = MemoryCache.GetTileFromMemoryCache(rtile);
                    if (m != null)
                    {
                        if (GMapProvider.TileImageProxy != null)
                        {
                            ret = GMapProvider.TileImageProxy.FromArray(m);
                            if (ret == null)
                            {
#if DEBUG
                                Debug.WriteLine("Image disposed in MemoryCache o.O, should never happen ;} " + new RawTile(provider.DbId, pos, zoom));
                                if (Debugger.IsAttached)
                                {
                                    Debugger.Break();
                                }
#endif
                                m = null;
                            }
                        }
                    }
                }

                if (ret == null)
                {
                    if (Mode != AccessMode.ServerOnly && !provider.BypassCache)
                    {
                        if (PrimaryCache != null)
                        {
                            ret = PrimaryCache.GetImageFromCache(provider.DbId, pos, zoom);
                            if (ret != null)
                            {
                                if (UseMemoryCache)
                                {
                                    MemoryCache.AddTileToMemoryCache(rtile, ret.Data.GetBuffer());
                                }
                                return ret;
                            }
                        }

                        if (SecondaryCache != null)
                        {
                            ret = SecondaryCache.GetImageFromCache(provider.DbId, pos, zoom);
                            if (ret != null)
                            {
                                if (UseMemoryCache)
                                {
                                    MemoryCache.AddTileToMemoryCache(rtile, ret.Data.GetBuffer());
                                }
                                return ret;
                            }
                        }
                    }

                    if (Mode != AccessMode.CacheOnly)
                    {
                        ret = provider.GetTileImage(pos, zoom);
                        {
                            // Enqueue Cache
                            if (ret != null)
                            {
                                if (UseMemoryCache)
                                {
                                    MemoryCache.AddTileToMemoryCache(rtile, ret.Data.GetBuffer());
                                }
                            }
                        }
                    }
                    else
                    {
                        result = noDataException;
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex;
                ret = null;
                Debug.WriteLine("GetImageFrom: " + ex.ToString());
            }

            return ret;
        }

        readonly Exception noDataException = new Exception("No data in local tile cache...");

    }
}
