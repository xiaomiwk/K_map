using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using GMap.NET;

namespace 下载地图
{
    public static class H行政区位置
    {
        private static readonly List<M行政区位置> _缓存 = new List<M行政区位置>();

        static H行政区位置()
        {
            读取数据();
        }

        public static List<M行政区位置> 所有
        {
            get { return _缓存; }
        }

        private static void 读取数据()
        {
            var _程序目录 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var __压缩文件路径 = Path.Combine(_程序目录, "行政区.gz");
            var __字节流 = 解压(__压缩文件路径);
            int _起始位置 = 0;
            //检测文件是否有bom头
            if (__字节流[0] == 0xef && __字节流[1] == 0xbb && __字节流[2] == 0xbf)
            {
                _起始位置 = 3;
            }
            var __所有行 = Encoding.UTF8.GetString(__字节流, _起始位置, __字节流.Length - _起始位置).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < __所有行.Length; i++)
            {
                var __属性 = __所有行[i].Split(new char[] { ',' }, 6);
                if (__属性.Length < 5)
                {
                    continue;
                }
                var __行政区 = new M行政区位置
                {
                    省 = __属性[0],
                    市 = __属性[1],
                    区 = __属性[2],
                    经度 = double.Parse(__属性[3]),
                    纬度 = double.Parse(__属性[4])
                };
                _缓存.Add(__行政区);
                if (__属性.Length == 6)
                {
                    var __边界坐标描述 = __属性[5];
                    __边界坐标描述.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(q => __行政区.边界坐标.Add(q.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(
                                k => new PointLatLng(double.Parse(k.Split(',')[1]), double.Parse(k.Split(',')[0])))
                            .ToList()));
                }
            }
        }

        private static byte[] 解压(string __源文件名)
        {
            var __源文件 = new FileInfo(__源文件名);
            using (FileStream __源文件流 = __源文件.OpenRead())
            {
                using (var __目标文件流 = new MemoryStream())
                {
                    using (var __解压流 = new GZipStream(__源文件流, CompressionMode.Decompress))
                    {
                        __解压流.CopyTo(__目标文件流);
                        var __字节流 = __目标文件流.ToArray();
                        return __字节流;
                    }
                }
            }
        }

        public static void 保存数据(List<M行政区位置> __位置列表, string __文件路径)
        {
            var __描述 = new StringBuilder();
            __位置列表.ForEach(q => __描述.Append(q.序列化()).AppendLine());
            File.WriteAllText(__文件路径, __描述.ToString(), Encoding.UTF8);
            压缩(__文件路径);
        }

        private static void 压缩(string __文件名)
        {
            var __文件 = new FileInfo(__文件名);
            using (FileStream ___源文件流 = __文件.OpenRead())
            {
                if ((File.GetAttributes(__文件.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & __文件.Extension != ".gz")
                {
                    using (FileStream __目的文件流 = File.Create(__文件.FullName + ".gz"))
                    {
                        using (var __压缩流 = new GZipStream(__目的文件流, CompressionMode.Compress))
                        {
                            ___源文件流.CopyTo(__压缩流);
                            Console.WriteLine("文件 {0} 从 {1} 压缩到 {2} bytes.", __文件.Name, __文件.Length, __目的文件流.Length);
                        }
                    }
                }
            }
        }

        public static void 保存省市()
        {
            var __文件名 = "省市";
            var __文件路径 = Path.Combine(Environment.CurrentDirectory, __文件名);
            var __位置列表 = 所有.Where(q => q.市 == q.区 || string.IsNullOrEmpty(q.区)).ToList();
            保存数据(__位置列表, __文件路径);
        }
    }
}
