using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace 下载地图
{
    class B下载
    {
        GMapProvider _地图提供者;

        private DSQLITE _存储;

        public bool 下载中 { get; set; }

        public float 成功率 { get; private set; }

        public B下载(string __完整路径, GMapProvider __地图提供者)
        {
            this._存储 = new DSQLITE(__完整路径);
            this._地图提供者 = __地图提供者;
        }

        public void 开始(RectLatLng __下载区域, int __最小层级, int __最大层级, int __线程数 = 8)
        {
            int __最大重试次数 = 3;
            if (!下载中)
            {
                下载中 = true;

                GMaps.Instance.UseMemoryCache = false;

                var __总数 = 0;
                int __成功下载数 = 0;
                int __失败下载数 = 0;
                for (int i = __最小层级; i <= __最大层级; i++)
                {
                    __总数 += _地图提供者.Projection.GetAreaTileList(__下载区域, i, 0).Count;
                }

                _存储.打开数据库();
                for (int k = __最小层级; k <= __最大层级; k++)
                {
                    if (!下载中)
                    {
                        break;
                    }
                    var __当前层级 = k;
                    var __下载列表 = _地图提供者.Projection.GetAreaTileList(__下载区域, __当前层级, 0);
                    var __当前层级总数 = __下载列表.Count;
                    var __maxTile = _地图提供者.Projection.GetTileMatrixMaxXY(__当前层级);

                    var __任务列表 = new List<Task>();
                    for (int j = 0; j < __线程数; j++)
                    {
                        var __线程标识 = j;
                        __任务列表.Add(Task.Factory.StartNew(() =>
                        {
                            int __已重试次数 = 0;

                            for (int i = __线程标识; i < __当前层级总数; i = i + __线程数)
                            {
                                if (!下载中)
                                {
                                    break;
                                }
                                GPoint __位置 = __下载列表[i];
                                try
                                {
                                    if (_地图提供者.Overlays != null && _地图提供者.Overlays.Length > 1)
                                    {
                                        var __图片列表 = new List<Bitmap>();
                                        foreach (var __提供者 in _地图提供者.Overlays)
                                        {
                                            var __图片 = __提供者.GetTileImage(__提供者.InvertedAxisY ? new GPoint(__位置.X, __maxTile.Height - __位置.Y) : __位置, __当前层级);
                                            __图片列表.Add(new Bitmap(__图片.Data));
                                        }
                                        var __合成图片 = 混合(__图片列表);
                                        MemoryStream __数据 = new MemoryStream();
                                        __合成图片.Save(__数据, System.Drawing.Imaging.ImageFormat.Png);
                                        this._存储.保存(__数据.GetBuffer(), __位置, __当前层级);
                                        __合成图片.Dispose();
                                    }
                                    else
                                    {
                                        var __图片 = _地图提供者.GetTileImage(_地图提供者.InvertedAxisY ? new GPoint(__位置.X, __maxTile.Height - __位置.Y) : __位置, __当前层级);
                                        this._存储.保存(__图片.Data.GetBuffer(), __位置, __当前层级);
                                        __图片.Dispose();
                                    }

                                    __成功下载数++;
                                    __已重试次数 = 0;
                                }
                                catch (Exception ex)
                                {
                                    if (++__已重试次数 <= __最大重试次数)
                                    {
                                        i = i - __线程数;
                                        Thread.Sleep(1000);
                                        continue;
                                    }
                                    __失败下载数++;
                                    __已重试次数 = 0;
                                    Debug.WriteLine(string.Format("CacheTiles Err:{0}", ex.Message));
                                }
                                On下载进度变化((float)((__成功下载数 + __失败下载数) * 1.0 / __总数));
                                成功率 = (float)(__成功下载数 * 1.0 / (__成功下载数 + __失败下载数));
                            }
                        }));
                    }
                    Task.WaitAll(__任务列表.ToArray());
                }
                结束();
            }
        }

        public void 结束()
        {
            if (!下载中)
            {
                return;
            }
            下载中 = false;

            GMaps.Instance.UseMemoryCache = true;

            _存储.关闭数据库();
        }

        public event Action<float> 下载进度变化;

        protected virtual void On下载进度变化(float __进度)
        {
            var handler = 下载进度变化;
            if (handler != null) handler(__进度);
        }

        private Bitmap 混合(List<Bitmap> __图片列表)
        {
            if (__图片列表.Count == 0)
            {
                return null;
            }
            if (__图片列表.Count == 1)
            {
                return __图片列表[0];
            }
            var __结果 = __图片列表[0];
            Graphics gr = Graphics.FromImage(__结果);
            for (int i = 1; i < __图片列表.Count; i++)
            {
                gr.DrawImage(__图片列表[i], 0, 0);
            }
            gr.Dispose();
            return __结果;
        }
    }
}
