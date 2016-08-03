using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Demo
{
    public static class H行政区位置
    {
        private static readonly List<M行政区位置> _缓存 = new List<M行政区位置>();

        static H行政区位置()
        {
            重新初始化();
        }

        public static List<M行政区位置> 所有
        {
            get { return _缓存; }
        }

        public static void 重新初始化()
        {
            _缓存.Clear();
            var __当前省 = "";
            var __当前市 = "";
            var __所有行 = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "行政区划代码.txt"), Encoding.UTF8);
            for (int i = 0; i < __所有行.Length; i++)
            {
                var __行 = __所有行[i];
                if (string.IsNullOrEmpty(__行.Trim()))
                {
                    continue;
                }
                var __属性列表 = __行.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (__属性列表.Length != 2)
                {
                    continue;
                }
                var __代码 = int.Parse(__属性列表[0]);
                var __地区 = __属性列表[1];
                if (__代码 % 10000 == 0)
                {
                    __当前省 = __地区;
                    if (M行政区位置.直辖市.Contains(__地区))
                    {
                        __当前市 = __地区;
                        _缓存.Add(new M行政区位置 { 省 = __地区, 市 = __地区, 区 = "" });
                    }
                    else
                    {
                        _缓存.Add(new M行政区位置 { 省 = __地区, 市 = "", 区 = "" });
                    }
                    continue;
                }
                if (__地区.Trim() == "市辖区" || __地区.Trim() == "县")
                {
                    continue;
                }
                if (__代码 % 100 == 0)
                {
                    __当前市 = __地区;
                    _缓存.Add(new M行政区位置 { 省 = __当前省, 市 = __地区, 区 = "" });
                    continue;
                }
                _缓存.Add(new M行政区位置 { 省 = __当前省, 市 = __当前市, 区 = __地区 });
            }
        }
    }
}
