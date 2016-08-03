using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using GMap.NET;

namespace 显示地图
{
    public static class H行政区位置
    {
        private static readonly List<M行政区位置> _缓存 = new List<M行政区位置>();

        static H行政区位置()
        {
            读取数据();
        }

        static void 读取数据()
        {
            var _程序目录 = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
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
                                k => HGPS坐标转换.百度坐标转谷歌坐标(new M经纬度(double.Parse(k.Split(',')[0]), double.Parse(k.Split(',')[1])) { 类型 = E坐标类型.百度 }))
                            .ToList()));
                }
            }
        }

        static byte[] 解压(string __源文件名)
        {
            var __源文件 = new FileInfo(__源文件名);
            using (FileStream __源文件流 = __源文件.OpenRead())
            {
                using (MemoryStream __目标文件流 = new MemoryStream())
                {
                    using (GZipStream __解压流 = new GZipStream(__源文件流, CompressionMode.Decompress))
                    {
                        __解压流.CopyTo(__目标文件流);
                        var __字节流 = __目标文件流.ToArray();
                        return __字节流;
                    }
                }
            }
        }

        public static List<M行政区位置> 所有
        {
            get { return _缓存; }
        }

        public static M经纬度 查询城市经纬度(string __城市名称)
        {
            var __行政区位置 = 所有.Find(q => q.市 == (__城市名称.EndsWith("市") ? __城市名称 : __城市名称 + "市"));
            return new M经纬度(__行政区位置.经度, __行政区位置.纬度);
        }
    }
}
