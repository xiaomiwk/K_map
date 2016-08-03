using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using GMap.NET;

namespace 下载地图
{
    class DSQLITE
    {
        private static readonly string __创建SQL = "CREATE TABLE IF NOT EXISTS Tiles (X INTEGER NOT NULL, Y INTEGER NOT NULL, Zoom INTEGER NOT NULL, Tile BLOB NULL);CREATE INDEX IF NOT EXISTS IndexOfTiles ON Tiles (X, Y, Zoom);";
        static readonly string __添加SQL = "INSERT INTO main.Tiles(X, Y, Zoom, Tile) VALUES(@p1, @p2, @p3, @p4)";

        private string _连接字符串;

        private SQLiteConnection _连接;

        public DSQLITE(string __路径)
        {
            _连接字符串 = string.Format("Data Source=\"{0}\";FailIfMissing=False;Page Size=32768", __路径);
            if (!File.Exists(__路径))
            {
                创建数据库(__路径);
            }
        }

        void 创建数据库(string __路径)
        {
            try
            {
                string __目录 = Path.GetDirectoryName(__路径);
                if (__目录 != null && !Directory.Exists(__目录))
                {
                    Directory.CreateDirectory(__目录);
                }

                using (var __连接 = new SQLiteConnection())
                {
                    __连接.ConnectionString = _连接字符串;
                    __连接.Open();
                    using (DbTransaction __事务 = __连接.BeginTransaction())
                    {
                        try
                        {
                            using (DbCommand __命令 = __连接.CreateCommand())
                            {
                                __命令.Transaction = __事务;
                                __命令.CommandText = __创建SQL;
                                __命令.ExecuteNonQuery();
                            }
                            __事务.Commit();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("创建数据库 出错: " + ex);
                            __事务.Rollback();
                        }
                    }
                    __连接.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("创建数据库 出错: " + ex);
            }
        }

        public void 打开数据库()
        {
            _连接 = new SQLiteConnection { ConnectionString = _连接字符串 };
            _连接.Open();
        }

        public void 关闭数据库()
        {
            if (_连接 == null || _连接.State == System.Data.ConnectionState.Closed)
            {
                return;
            }
            _连接.Close();
        }

        public bool 保存(byte[] __图片数据, GPoint __位置, int __层级)
        {
            try
            {
                using (DbCommand __命令 = _连接.CreateCommand())
                {
                    __命令.CommandText = __添加SQL;

                    __命令.Parameters.Add(new SQLiteParameter("@p1", __位置.X));
                    __命令.Parameters.Add(new SQLiteParameter("@p2", __位置.Y));
                    __命令.Parameters.Add(new SQLiteParameter("@p3", __层级));
                    __命令.Parameters.Add(new SQLiteParameter("@p4", __图片数据));

                    __命令.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("保存出错: " + ex);
                return false;
            }
        }

    }
}
