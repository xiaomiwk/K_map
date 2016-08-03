using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;
using System;
using System.Diagnostics;
using System.Globalization;
using GMap.NET.MapProviders;
using System.Threading;

#if !MONO
using System.Data.SQLite;
#else
   using SQLiteConnection = Mono.Data.SqliteClient.SqliteConnection;
   using SQLiteTransaction = Mono.Data.SqliteClient.SqliteTransaction;
   using SQLiteCommand = Mono.Data.SqliteClient.SqliteCommand;
   using SQLiteDataReader = Mono.Data.SqliteClient.SqliteDataReader;
   using SQLiteParameter = Mono.Data.SqliteClient.SqliteParameter;
#endif

namespace GMap.NET.CacheProviders
{

    /// <summary>
    /// ultra fast cache system for tiles
    /// </summary>
    public class SQLitePureImageCache : PureImageCache
    {
#if !MONO
        static SQLitePureImageCache()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("System.Data.SQLite", StringComparison.OrdinalIgnoreCase))
            {
                string rootDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "GMap.NET" + Path.DirectorySeparatorChar;
                string dllDir = rootDir + "DllCache" + Path.DirectorySeparatorChar;
                string dll = dllDir + "SQLite_v84_NET" + Environment.Version.Major + "_" + (IntPtr.Size == 8 ? "x64" : "x86") + Path.DirectorySeparatorChar + "System.Data.SQLite.DLL";
                if (!File.Exists(dll))
                {
                    string dir = Path.GetDirectoryName(dll);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    Debug.WriteLine("Saving to DllCache: " + dll);

                    if (Environment.Version.Major == 2)
                    {
                        //using(MemoryStream gzipDll = new MemoryStream((IntPtr.Size == 8 ? Properties.Resources.System_Data_SQLite_x64_NET2_dll : Properties.Resources.System_Data_SQLite_x86_NET2_dll)))
                        //{
                        //   using(var gs = new System.IO.Compression.GZipStream(gzipDll, System.IO.Compression.CompressionMode.Decompress))
                        //   {
                        //      using(MemoryStream exctDll = new MemoryStream())
                        //      {
                        //         byte[] tmp = new byte[1024 * 256];
                        //         int r = 0;
                        //         while((r = gs.Read(tmp, 0, tmp.Length)) > 0)
                        //         {
                        //            exctDll.Write(tmp, 0, r);
                        //         }
                        //         File.WriteAllBytes(dll, exctDll.ToArray());
                        //      }
                        //   }
                        //}
                    }
                    else if (Environment.Version.Major == 4)
                    {
                        using (MemoryStream gzipDll = new MemoryStream((IntPtr.Size == 8 ? Properties.Resources.System_Data_SQLite_x64_NET4_dll : Properties.Resources.System_Data_SQLite_x86_NET4_dll)))
                        {
                            using (var gs = new System.IO.Compression.GZipStream(gzipDll, System.IO.Compression.CompressionMode.Decompress))
                            {
                                using (MemoryStream exctDll = new MemoryStream())
                                {
                                    byte[] tmp = new byte[1024 * 256];
                                    int r = 0;
                                    while ((r = gs.Read(tmp, 0, tmp.Length)) > 0)
                                    {
                                        exctDll.Write(tmp, 0, r);
                                    }
                                    File.WriteAllBytes(dll, exctDll.ToArray());
                                }
                            }
                        }
                    }
                }

                Debug.WriteLine("Assembly.LoadFile: " + dll);

                return System.Reflection.Assembly.LoadFile(dll);
            }
            return null;
        }

#endif

        #region -- import / export --


        public static bool 加载地图(string sourceFile)
        {
            if (string.IsNullOrEmpty(sourceFile))
            {
                ConnectionString = null;
                return true;
            }
            ConnectionString = string.Format("Data Source=\"{0}\";Page Size=32768", sourceFile);
            return true;
        }
        #endregion

        static readonly string singleSqlSelect = "SELECT Tile FROM main.Tiles WHERE X={0} AND Y={1} AND Zoom={2}";

        static string ConnectionString;

        string finnalSqlSelect = singleSqlSelect;


        #region PureImageCache Members

        public PureImage GetImageFromCache(int type, GPoint pos, int zoom)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                return null;
            }
            PureImage ret = null;
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection())
                {
                    cn.ConnectionString = ConnectionString;
                    cn.Open();
                    using (DbCommand com = cn.CreateCommand())
                    {
                        com.CommandText = string.Format(finnalSqlSelect, pos.X, pos.Y, zoom);

                        using (DbDataReader rd = com.ExecuteReader(System.Data.CommandBehavior.SequentialAccess))
                        {
                            if (rd.Read())
                            {
                                long length = rd.GetBytes(0, 0, null, 0, 0);
                                byte[] tile = new byte[length];
                                rd.GetBytes(0, 0, tile, 0, tile.Length);
                                {
                                    if (GMapProvider.TileImageProxy != null)
                                    {
                                        ret = GMapProvider.TileImageProxy.FromArray(tile);
                                    }
                                }
                                tile = null;
                            }
                            rd.Close();
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
#if MONO
            Console.WriteLine("GetImageFromCache: " + ex.ToString());
#endif
                Debug.WriteLine("GetImageFromCache: " + ex.ToString());
                ret = null;
            }

            return ret;
        }

        #endregion
    }
}
