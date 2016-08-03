using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 显示地图;

namespace 显示地图_示例
{
    class B轨迹
    {
        public Dictionary<string, List<M经纬度>> 轨迹缓存 { get; set; }

        public bool 订阅中 { get; set; }

        public B轨迹()
        {
            轨迹缓存 = new Dictionary<string, List<M经纬度>>();
        }

        /// <param name="__更新频率">毫秒</param>
        public void 订阅(int __数量, int __更新频率, M经纬度 __参考位置)
        {
            轨迹缓存.Clear();
            订阅中 = true;
            var __随机数 = new Random();
            Task.Factory.StartNew(() =>
            {
                while (订阅中)
                {
                    var __监视器 = new Stopwatch();
                    __监视器.Start();
                    for (int i = 0; i < __数量; i++)
                    {
                        var __号码 = i.ToString();
                        if (!轨迹缓存.ContainsKey(__号码))
                        {
                            var __初始经度偏移量 = __随机数.NextDouble() * 0.0002 * __数量 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                            var __初始纬度偏移量 = __随机数.NextDouble() * 0.0002 * __数量 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                            轨迹缓存[__号码] = new List<M经纬度> { __参考位置.偏移(__初始经度偏移量, __初始纬度偏移量) };
                        }
                        var __缓存 = 轨迹缓存[__号码];
                        var __上次位置 = __缓存.Last();
                        var __经度偏移量 = __随机数.NextDouble() * 0.0005 * (__随机数.NextDouble() > 0.2 ? -1 : 1);
                        var __纬度偏移量 = __随机数.NextDouble() * 0.0005 * (__随机数.NextDouble() > 0.2 ? -1 : 1);
                        var __新位置 = __上次位置.偏移(__经度偏移量, __纬度偏移量);
                        __缓存.Add(__新位置);
                        if (__缓存.Count > 10)
                        {
                            __缓存.RemoveAt(0);
                        }
                        if (!订阅中)
                        {
                            break;
                        }
                        On位置更新(__号码, __新位置, new List<M经纬度>(__缓存));
                        Thread.Sleep(__随机数.Next(0, __更新频率 / __数量));
                    }
                    __监视器.Stop();
                    var __耗时 = (int)__监视器.ElapsedMilliseconds;
                    if (__耗时 < __更新频率 && 订阅中)
                    {
                        Thread.Sleep(__更新频率 - __耗时);
                    }
                }
                On取消完毕();
            });
        }

        public void 取消订阅()
        {
            订阅中 = false;
        }

        public event Action<string, M经纬度, List<M经纬度>> 位置更新;

        protected virtual void On位置更新(string __号码, M经纬度 __最新位置, List<M经纬度> __轨迹缓存)
        {
            var handler = 位置更新;
            if (handler != null) handler(__号码, __最新位置, __轨迹缓存);
        }

        public event Action 取消完毕;

        protected virtual void On取消完毕()
        {
            Action handler = 取消完毕;
            if (handler != null) handler();
        }
    }
}
