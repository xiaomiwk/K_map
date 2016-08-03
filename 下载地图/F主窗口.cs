using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GIS.IView;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsForms;

namespace 下载地图
{
    public partial class F主窗口 : Form
    {
        internal readonly GMapOverlay __已下载图块表示层 = new GMapOverlay("下载");

        private GMapOverlay _边界图层;

        B下载 __B下载;

        private GMapProvider _当前地图;

        public F主窗口()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text += "  -  " + Assembly.GetExecutingAssembly().GetName().Version;

            _边界图层 = new GMapOverlay("边界");
            this.out地图.Overlays.Add(_边界图层);
            this.out地图.Overlays.Add(__已下载图块表示层);

            this.in层级_开始.Text = "9";
            this.in层级_结束.Text = "16";

            var __所有省 = H行政区位置.所有.Select(q => q.省.Trim()).Distinct().ToList();
            //Debug.WriteLine("0XEF,0XBB,0XBF" + System.Text.Encoding.UTF8.GetString(new byte[] { 0XEF, 0XBB, 0XBF }));
            //Debug.WriteLine(__所有省[0] + BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(__所有省[0])));
            //Debug.WriteLine(__所有省[1] + BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(__所有省[1])));
            __所有省 = __所有省.Distinct().ToList();
            this.in省.DataSource = __所有省;

            this.in来源.ValueMember = "Name";
            var __地图源 = new List<GMapProvider>(GMapProviders.List);
            __地图源.Remove(GMapProviders.EmptyProvider);
            __地图源.Remove(GMapProviders.GoogleMap);
            __地图源.Remove(GMapProviders.GoogleHybridMap);
            __地图源.Remove(GMapProviders.GoogleSatelliteMap);
            __地图源.Remove(GMapProviders.GoogleTerrainMap);
            __地图源.Remove(GMapProviders.GoogleChinaSatelliteMap);
            __地图源.Remove(GMapProviders.GoogleChinaTerrainMap);
            __地图源.Remove(GMapProviders.BaiduMap);
            __地图源.Remove(GMapProviders.BaiduSateliteMap);
            __地图源.Remove(GMapProviders.AMap);
            __地图源.Remove(GMapProviders.AMapSatelite);
            __地图源.Remove(GMapProviders.PGISMap);
            this.in来源.DataSource = __地图源;
            this.do开始下载.Click += do开始下载_Click;
            this.do终止下载.Click += do终止下载_Click;
            this.do开始下载.Enabled = true;
            this.do终止下载.Enabled = false;

            this.out地图.MouseDoubleClick += out地图_MouseDoubleClick;
            this.out地图.MouseMove += out地图_MouseMove;
            this.out地图.OnMapZoomChanged += out地图_OnMapZoomChanged;

            this.in省.SelectedIndexChanged += in省_SelectedIndexChanged;
            this.in市.SelectedIndexChanged += in市_SelectedIndexChanged;

            _当前地图 = GMapProviders.GoogleChinaMap;
            this.in来源.SelectedItem = _当前地图;

            this.in来源.SelectedIndexChanged += (sender1, e1) =>
            {
                _当前地图 = (GMapProvider) this.in来源.SelectedItem;
                打开地图();
            }; 

            this.in省.SelectedIndex = __所有省.FindIndex(q => q == "江苏省");

            打开地图();

        }

        void in市_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省名称 = (string)this.in省.SelectedValue;
            var __市名称 = (string)this.in市.SelectedValue;
            var __市 = H行政区位置.所有.Find(q => q.省 == __省名称 && q.市 == __市名称);
            显示行政区(__市);
            //var __区 = H行政区位置.所有.Where(q => q.省 == __省名称 && q.市 == __市名称).Select(q => q.区).Distinct();
        }

        void in省_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省名称 = (string)this.in省.SelectedValue;
            var __省 = H行政区位置.所有.Find(q => q.省 == __省名称 && (q.市 == "" || q.省 == q.市));
            var __省内市 = H行政区位置.所有.Where(q => q.省 == __省名称).Select(q => q.市).Distinct();
            this.in市.DataSource = __省内市.ToList();
            显示行政区(__省);
        }

        private void 显示行政区(M行政区位置 __行政区)
        {
            this.out地图.Position = new PointLatLng(__行政区.纬度, __行政区.经度);
            //绘制边界
            _边界图层.Routes.Clear();
            var __位置列表 = new List<PointLatLng>();
            __行政区.边界坐标.ForEach(__点列表 =>
            {
                var __GPS = new List<PointLatLng>();
                __点列表.ForEach(q =>
                {
                    //double __谷歌经度 = q.Lng;
                    //double __谷歌纬度 = q.Lat;
                    //HGPS坐标转换.百度坐标转谷歌坐标(q.Lat, q.Lng, out __谷歌纬度, out __谷歌经度);
                    //__GPS.Add(new PointLatLng(__谷歌纬度, __谷歌经度));

                    if (!Equals(_当前地图, GMapProviders.BaiduMap))
                    {
                        __GPS.Add(H坐标转换.bd09_To_Gcj02(q.Lat, q.Lng));
                    }
                    else
                    {
                        __GPS.Add(q);
                    }
                });
                __位置列表.AddRange(__GPS);
                var __线 = new GMapRoute(__GPS, "")
                {
                    Stroke =
                        new Pen(Color.Blue)
                        {
                            Width = 2,
                        }
                };
                _边界图层.Routes.Add(__线);
            });

            if (__位置列表.Count > 0)
            {
                double __最小经度 = 180;
                double __最大经度 = -180;
                double __最小纬度 = 90;
                double __最大纬度 = -90;
                __位置列表.ForEach(q =>
                {
                    __最小经度 = Math.Min(__最小经度, q.Lng);
                    __最大经度 = Math.Max(__最大经度, q.Lng);
                    __最小纬度 = Math.Min(__最小纬度, q.Lat);
                    __最大纬度 = Math.Max(__最大纬度, q.Lat);
                });
                this.out地图.SetZoomToFitRect(RectLatLng.FromLTRB(__最小经度, __最大纬度, __最大经度, __最小纬度));
            }
        }

        void out地图_OnMapZoomChanged()
        {
            outZOOM.Text = string.Format("当前层级: {0}", this.out地图.Zoom);
        }

        void out地图_MouseMove(object sender, EventArgs e)
        {
            var __鼠标参数 = e as MouseEventArgs;
            if (__鼠标参数 != null)
            {
                var __经纬度 = this.out地图.FromLocalToLatLng(__鼠标参数.X, __鼠标参数.Y);
                GPoint tile = _当前地图.Projection.FromPixelToTileXY(_当前地图.Projection.FromLatLngToPixel(__经纬度, (int)this.out地图.Zoom));
                out经纬度.Text = string.Format("经度:{0:F5};    纬度:{1:F5}    Tile X:{2}    Tile Y:{3}", __经纬度.Lng, __经纬度.Lat, tile.X, tile.Y);
            }
        }

        void out地图_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RectLatLng area = out地图.SelectedArea;
            if (area.IsEmpty)
            {
                var __鼠标参数 = e;
                if (__鼠标参数 != null)
                {
                    var __经纬度 = this.out地图.FromLocalToLatLng(__鼠标参数.X, __鼠标参数.Y);
                    MessageBox.Show(string.Format("经度:{0}; 纬度:{1}", __经纬度.Lng, __经纬度.Lat));
                }
                return;
            }
            MessageBox.Show(string.Format("左上坐标：{0}{3}右下坐标：{1}{3}中心坐标：{2}{3}", 获取描述(area.LocationTopLeft), 获取描述(area.LocationRightBottom), 获取描述(area.LocationMiddle), Environment.NewLine));
        }

        string 获取描述(PointLatLng __latlng)
        {
            return string.Format("(经度){0}, (纬度){1};", __latlng.Lng, __latlng.Lat);
        }

        private void 打开地图()
        {
            var _等待窗口 = new F等待();
            this.out容器.创建局部覆盖控件(_等待窗口, null);
            Application.DoEvents();
            try
            {
                out地图.MapProvider = _当前地图;
                out地图.DragButton = MouseButtons.Left;
                out地图.MinZoom = 4;
                out地图.MaxZoom = 20;
                out地图.Zoom = 6;
                out地图.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
                this.out地图.Manager.Mode = AccessMode.ServerOnly;
                GMaps.Instance.UseMemoryCache = false;

                var __省 = (string)this.in省.SelectedValue;
                var __市 = (string)this.in市.SelectedValue;
                var __匹配 = H行政区位置.所有.Find(q => q.省 == __省 && q.市 == __市);
                if ((int)__匹配.经度 == 0 && (int)__匹配.纬度 == 0)
                {
                    MessageBox.Show("无地图数据");
                }
                显示行政区(__匹配);
            }
            catch (Exception ex)
            {
                MessageBox.Show("地图打开错误" + Environment.NewLine + ex.Message);
            }
            _等待窗口.隐藏();
        }

        void do开始下载_Click(object sender, EventArgs e)
        {
            var __开始层级 = int.Parse(this.in层级_开始.Text.Trim());
            var __结束层级 = int.Parse(this.in层级_结束.Text.Trim());
            var __省 = this.in省.Text;
            var __市 = this.in市.Text;

            var __目录 = Path.Combine(Environment.CurrentDirectory, "离线地图");
            if (!Directory.Exists(__目录))
            {
                Directory.CreateDirectory(__目录);
            }
            var __完整路径 = Path.Combine(__目录, string.Format("{0}_{1}_{2}-{3}.gmdb", string.IsNullOrEmpty(__市) ? __省 : __市, out地图.MapProvider.Name, __开始层级, __结束层级));

            this.out地图.Manager.Mode = AccessMode.ServerOnly;

            RectLatLng area = out地图.SelectedArea;
            if (!area.IsEmpty)
            {
                __B下载 = new B下载(__完整路径, this.out地图.MapProvider);
                __B下载.下载进度变化 += 下载进度变化;
                //限制界面

                //配置任务
                var __任务 = new Task(() =>
                {
                    //执行后台任务
                    __B下载.开始(area, __开始层级, __结束层级, 10);
                });
                __任务.ContinueWith(task =>
                {
                    //成功后提示, 并取消限制 
                    MessageBox.Show("下载成功, 文件保存到程序目录", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(__目录);
                    __B下载.下载进度变化 -= 下载进度变化;
                },
                    CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                     TaskScheduler.FromCurrentSynchronizationContext());
                __任务.ContinueWith(task =>
                {
                    //失败后提示, 并取消限制    
                    if (task.Exception != null)
                    {
                        task.Exception.Handle(q => true);
                        MessageBox.Show("下载出错: " + task.Exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    __B下载.下载进度变化 -= 下载进度变化;
                },
                    CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                     TaskScheduler.FromCurrentSynchronizationContext());

                //开始任务
                __任务.Start();

                this.do开始下载.Enabled = false;
                this.do终止下载.Enabled = true;

            }
            else
            {
                MessageBox.Show("请先按住 ALT 键, 然后鼠标右键框选需要下载的区域", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void do终止下载_Click(object sender, EventArgs e)
        {
            if (__B下载 != null && __B下载.下载中)
            {
                __B下载.结束();
                this.do开始下载.Enabled = true;
                this.do终止下载.Enabled = false;
            }
        }

        void 下载进度变化(float __进度)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<float>(下载进度变化), __进度);
                return;
            }
            this.out进度.Text = string.Format("进度:{0:f2}%; 成功率:{1:f2}%", __进度 * 100, __B下载.成功率 * 100);
        }

    }
}
