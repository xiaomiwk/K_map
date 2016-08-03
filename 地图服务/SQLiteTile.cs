using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace 地图服务
{
    public class SQLiteTile : I瓦片查询
    {
        private Dictionary<string, string> _连接字符串缓存 = new Dictionary<string, string>();

        public Func<string, string> 获取地图路径 { get; set; }

        public string 查询语句 { get; set; }

        public SQLiteTile()
        {
            查询语句 = "SELECT Tile FROM main.Tiles WHERE X={0} AND Y={1} AND Zoom={2}";
            获取地图路径 = __地图源 =>
            {
                var __地图列表 = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "离线地图"), string.Format("*{0}*.gmdb", __地图源));
                if (__地图列表 == null || __地图列表.Length == 0)
                {
                    return null;
                }
                return __地图列表[0];
            };
        }

        public byte[] 查询瓦片(string __地图源, int x, int y, int zoom)
        {
            __地图源 = HttpUtility.UrlDecode(__地图源);
            var ConnectionString = 生成字符串(__地图源);
            if (string.IsNullOrEmpty(ConnectionString))
            {
                return null;
            }
            //PureImage ret = null;
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection())
                {
                    cn.ConnectionString = ConnectionString;
                    cn.Open();
                    using (DbCommand com = cn.CreateCommand())
                    {
                        com.CommandText = string.Format(查询语句, x, y, zoom);

                        using (DbDataReader rd = com.ExecuteReader(System.Data.CommandBehavior.SequentialAccess))
                        {
                            if (rd.Read())
                            {
                                long length = rd.GetBytes(0, 0, null, 0, 0);
                                byte[] tile = new byte[length];
                                rd.GetBytes(0, 0, tile, 0, tile.Length);
                                return tile;
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("GetImageFromCache: {0}/{3}/{1}/{2},{4}", __地图源, x, y, zoom, ex));
                return null;
            }
            return null;
        }

        private string 生成字符串(string __地图源)
        {
            if (_连接字符串缓存.ContainsKey(__地图源))
            {
                return _连接字符串缓存[__地图源];
            }
            var __文件路径 = 获取地图路径(__地图源);
            if (string.IsNullOrEmpty(__文件路径))
            {
                return null;
            }
            _连接字符串缓存[__地图源] = string.Format("Data Source=\"{0}\";Page Size=32768", __文件路径);
            return _连接字符串缓存[__地图源];
        }

    }
}
