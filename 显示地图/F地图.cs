using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.CacheProviders;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace 显示地图
{
    /// <summary>
    /// 不指定图层(图层=null), 表示默认图层管理
    /// </summary>
    public partial class F地图 : UserControl, IF地图
    {
        private readonly Dictionary<string, GMapOverlay> _所有图层 = new Dictionary<string, GMapOverlay>();

        private readonly Dictionary<GMapOverlay, M覆盖物> _所有覆盖物 = new Dictionary<GMapOverlay, M覆盖物>();

        private E地图源 _当前地图源;

        private class M覆盖物
        {
            public UInt64 标识 = 1;

            public readonly Dictionary<UInt64, GMapMarker> 点集 = new Dictionary<UInt64, GMapMarker>();

            public readonly Dictionary<UInt64, GMapRoute> 线集 = new Dictionary<UInt64, GMapRoute>();

            public readonly Dictionary<UInt64, GMapPolygon> 多边形集 = new Dictionary<UInt64, GMapPolygon>();

            public readonly Dictionary<UInt64, List<UInt64>> 麻点图集 = new Dictionary<UInt64, List<UInt64>>();
        }

        public Point 缩放控件位置
        {
            get { return this.do缩放.Location; }
            set { this.do缩放.Location = value; }
        }

        public Color 按钮背景颜色
        {
            get
            {
                return this.do缩放.按钮背景颜色;
            }
            set
            {
                this.do缩放.按钮背景颜色 = value;
            }
        }

        public Color 按钮文字颜色
        {
            get
            {
                return this.do缩放.按钮文字颜色;
            }
            set
            {
                this.do缩放.按钮文字颜色 = value;
            }
        }

        public bool 启用默认缩放控件
        {
            get
            {
                return this.do缩放.Visible;
            }
            set
            {
                this.do缩放.Visible = value;
            }
        }

        public int 最小层级
        {
            get { return this.out地图控件.MinZoom; }
            private set { this.out地图控件.MinZoom = value; }
        }

        public int 最大层级
        {
            get { return this.out地图控件.MaxZoom; }
            private set { this.out地图控件.MaxZoom = value; }
        }

        public int 当前层级
        {
            get { return (int)this.out地图控件.Zoom; }
            set { this.out地图控件.Zoom = value; }
        }

        public F地图()
        {
            InitializeComponent();
        }

        public bool 显示图片调试信息
        {
            get { return this.out地图控件.ShowTileGridLines; }
            set { this.out地图控件.ShowTileGridLines = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.添加默认图层();
            GMapProvider.Language = LanguageType.ChineseSimplified;
            this.out地图控件.DragButton = MouseButtons.Left;
            this.out地图控件.ShowCenter = false;
            this.out地图控件.EmptyTileColor = Color.White;
            this.out地图控件.EmptyTileText = "";
            this.显示图片调试信息 = false;

            this.out地图控件.OnMapZoomChanged += out地图控件_OnMapZoomChanged;
            this.out地图控件.OnMarkerClick += out地图控件_OnMarkerClick;
            this.out地图控件.OnMarkerEnter += out地图控件_OnMarkerEnter;
            this.out地图控件.OnMarkerLeave += out地图控件_OnMarkerLeave;
            this.out地图控件.OnRouteClick += out地图控件_OnRouteClick;
            this.out地图控件.OnRouteEnter += out地图控件_OnRouteEnter;
            this.out地图控件.OnRouteLeave += out地图控件_OnRouteLeave;
            this.out地图控件.OnPolygonClick += out地图控件_OnPolygonClick;
            this.out地图控件.OnPolygonEnter += out地图控件_OnPolygonEnter;
            this.out地图控件.OnPolygonLeave += out地图控件_OnPolygonLeave;

            this.out地图控件.OnMapZoomChanged += () => this.do缩放.设置当前级别(this.当前层级);
            this.do缩放.缩放级别改变 += 层级 => this.当前层级 = 层级;

            this.out地图控件.Click += (sender1, e1) => this.OnClick(e1);
            this.out地图控件.DoubleClick += (sender1, e1) => this.OnDoubleClick(e1);
            this.out地图控件.MouseMove += (sender1, e1) => this.OnMouseMove(e1);
            this.out地图控件.MouseUp += (sender1, e1) => this.OnMouseUp(e1);
            this.out地图控件.MouseDown += (sender1, e1) => this.OnMouseDown(e1);
            this.out地图控件.MouseEnter += (sender1, e1) => this.OnMouseEnter(e1);
            this.out地图控件.MouseLeave += (sender1, e1) => this.OnMouseLeave(e1);
            this.out地图控件.MouseHover += (sender1, e1) => this.OnMouseHover(e1);
            this.out地图控件.MouseClick += (sender1, e1) => this.OnMouseClick(e1);
            this.out地图控件.MouseDoubleClick += (sender1, e1) => this.OnMouseDoubleClick(e1);

        }

        /// <param name="__地图路径或服务器地址">文件名必须符合"城市"_"地图源"_"最小层级"-"最大层级".gmdb, 或者"http://xxx:xx"</param>
        public void 加载地图(string __地图路径或服务器地址)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(加载地图), __地图路径或服务器地址);
                return;
            }

            GMaps.Instance.MemoryCache.Clear();
            GMaps.Instance.PrimaryCache = null;

            if (!string.IsNullOrEmpty(__地图路径或服务器地址))
            {
                if (__地图路径或服务器地址.Contains("http://"))
                {
                    GMaps.Instance.SecondaryCache = new HttpPureImageCache(__地图路径或服务器地址);
                }
                else
                {
                    GMaps.Instance.PrimaryCache = new SQLitePureImageCache();
                    if (!GMaps.Instance.加载地图(__地图路径或服务器地址))
                    {
                        throw new ApplicationException(string.Format("地图文件 [{0}] 加载失败!", __地图路径或服务器地址));
                    }
                    try
                    {
                        var __文件名 = Path.GetFileNameWithoutExtension(__地图路径或服务器地址);
                        var __分段 = __文件名.Split('_');
                        if (__分段.Length == 3)
                        {
                            var __地区 = __分段[0];
                            var __地图源 = (E地图源)Enum.Parse(typeof(E地图源), __分段[1]);
                            var __最小层级 = int.Parse(__分段[2].Split('-')[0]);
                            var __最大层级 = int.Parse(__分段[2].Split('-')[1]);
                            var __行政区位置 = H行政区位置.所有.Find(q => q.市 == (__地区.EndsWith("市") ? __地区 : __地区 + "市"));
                            if (__行政区位置 == null)
                            {
                                __行政区位置 = H行政区位置.所有.Find(q => q.省 == __地区 || q.省 == __地区 + "省");
                            }
                            if (__行政区位置 == null)
                            {
                                __行政区位置 = H行政区位置.所有.Find(q => q.区 == __地区 || q.区 == __地区 + "区" || q.区 == __地区 + "县");
                            }
                            初始化地图参数(__地图源, new M经纬度(__行政区位置.经度, __行政区位置.纬度), __最小层级, __最大层级);
                        }
                    }
                    catch (Exception)
                    {
                        //未自动初始化地图参数
                        ;
                    }
                }
            }
            else
            {
                GMaps.Instance.PrimaryCache = null;
                GMaps.Instance.SecondaryCache = null;
            }
        }

        public void 设置层级范围(int __最小层级, int __最大层级)
        {
            this.do缩放.设置级别范围(this.最小层级, this.最大层级);
        }

        public E地图源 当前地图源 {
            get { return _当前地图源; }
            set
            {
                if (_当前地图源 == value)
                {
                    return;
                }
                _当前地图源 = value;
                switch (value)
                {
                    case E地图源.无:
                        this.out地图控件.MapProvider = GMapProviders.EmptyProvider;
                        this.out地图控件.Manager.Mode = AccessMode.ServerOnly;
                        break;
                    case E地图源.谷歌2D图:
                        this.out地图控件.MapProvider = GMapProviders.GoogleChinaMap;
                        this.out地图控件.Manager.Mode = AccessMode.CacheOnly;
                        break;
                    case E地图源.谷歌混合图:
                        this.out地图控件.MapProvider = GMapProviders.GoogleChinaHybridMap;
                        this.out地图控件.Manager.Mode = AccessMode.CacheOnly;
                        break;
                    case E地图源.百度2D图:
                        this.out地图控件.MapProvider = GMapProviders.BaiduMap;
                        this.out地图控件.Manager.Mode = AccessMode.CacheOnly;
                        break;
                    //case E地图源.高德2D图:
                    //    this.out地图控件.MapProvider = GMapProviders.AMap;
                    //    this.out地图控件.Manager.Mode = AccessMode.CacheOnly;
                    //    break;
                    //case E地图源.高德卫星图:
                    //    this.out地图控件.MapProvider = GMapProviders.AMapSatelite;
                    //    this.out地图控件.Manager.Mode = AccessMode.CacheOnly;
                    //    break;
                    //case E地图源.PGIS2D图:
                    //    this.out地图控件.MapProvider = GMapProviders.PGISMap;
                    //    this.out地图控件.Manager.Mode = AccessMode.CacheOnly;
                    //    break;
                    default:
                        throw new ArgumentOutOfRangeException("地图源未定义");
                }
                this.out地图控件.ReloadMap();
            }
        }

        public void 初始化地图参数(E地图源 __地图源, M经纬度 __中心位置, int __最小层级, int __最大层级)
        {
            this.最小层级 = __最小层级;
            this.最大层级 = __最大层级;
            设置层级范围(this.最小层级, this.最大层级);
            this.当前层级 = __最小层级 + (__最大层级 - __最小层级)/2;
            this.do缩放.设置当前级别(this.当前层级);
            this.out地图控件.Position = GPS转换(__中心位置);
            this.当前地图源 = __地图源;
            //this.out地图控件.BoundsOfMap = new RectLatLng(_地图初始中心, new SizeLatLng(0.2, 0.2)); //限定地图移动范围
        }

        public M经纬度 屏幕坐标转经纬度(Point __相对地图控件的坐标)
        {
            var __经纬度 = this.out地图控件.FromLocalToLatLng(__相对地图控件的坐标.X, __相对地图控件的坐标.Y);
            return new M经纬度 { 经度 = __经纬度.Lng, 纬度 = __经纬度.Lat, 类型 = E坐标类型.谷歌 };
        }

        public M经纬度 纠偏(M经纬度 __原始坐标)
        {
            var __temp = GPS转换(__原始坐标);
            return new M经纬度(__temp.Lng, __temp.Lat) { 类型 = E坐标类型.谷歌 };
        }

        private PointLatLng GPS转换(M经纬度 __GPS, bool __纠偏 = true)
        {
            double __标准经度 = __GPS.经度;
            double __标准纬度 = __GPS.纬度;
            if (__纠偏 && __GPS.类型 == E坐标类型.设备)
            {
                if (当前地图源 == E地图源.谷歌2D图 || 当前地图源 == E地图源.谷歌混合图)
                {
                    //double __谷歌坐标经度;
                    //double __谷歌坐标纬度;
                    //HGPS坐标转换.原始坐标转谷歌坐标(__标准纬度, __标准经度, out __谷歌坐标纬度, out __谷歌坐标经度);
                    //return new PointLatLng(__谷歌坐标纬度, __谷歌坐标经度);
                    return H坐标转换.gps84_To_Gcj02(__标准纬度, __标准经度);

                }
                if (当前地图源 == E地图源.百度2D图 || 当前地图源 == E地图源.百度混合图)
                {
                    return H坐标转换.gps84_To_Bd09(__标准纬度, __标准经度);
                }
            }
            return new PointLatLng(__标准纬度, __标准经度);
        }

        public void 添加图层(string __名称, int __顺序 = 0)
        {
            __名称 = "k" + __名称;
            if (_所有图层.ContainsKey(__名称))
            {
                throw new ApplicationException("图层名称已存在, 请使用其他名称");
            }
            var __图层 = new GMapOverlay(__名称) { 顺序 = __顺序 };
            _所有图层[__名称] = __图层;
            _所有覆盖物[__图层] = new M覆盖物();
            this.out地图控件.Overlays.Add(__图层);
        }

        private void 添加默认图层()
        {
            var __图层 = new GMapOverlay("w");
            _所有图层["w"] = __图层;
            _所有覆盖物[__图层] = new M覆盖物();
            this.out地图控件.Overlays.Add(__图层);
        }

        public void 删除图层(string __名称)
        {
            __名称 = "k" + __名称;
            if (!_所有图层.ContainsKey(__名称))
            {
                throw new ApplicationException("图层名称不存在");
            }
            var __图层 = _所有图层[__名称];
            __图层.Clear();
            this.out地图控件.Overlays.Remove(__图层);
            _所有覆盖物.Remove(__图层);
            _所有图层.Remove(__名称);
        }

        public void 隐藏图层(string __名称)
        {
            __名称 = "k" + __名称;
            if (!_所有图层.ContainsKey(__名称))
            {
                throw new ApplicationException("图层名称不存在");
            }
            _所有图层[__名称].IsVisibile = false;
        }

        public void 显示图层(string __名称)
        {
            __名称 = "k" + __名称;
            if (!_所有图层.ContainsKey(__名称))
            {
                throw new ApplicationException("图层名称不存在");
            }
            _所有图层[__名称].IsVisibile = true;
        }

        public void 调整图层顺序(string __名称, int __顺序)
        {
            __名称 = "k" + __名称;
            if (!_所有图层.ContainsKey(__名称))
            {
                throw new ApplicationException("图层名称不存在");
            }
            _所有图层[__名称].顺序 = __顺序;
        }

        private GMapOverlay 获取图层(string __名称)
        {
            if (__名称 == null)
            {
                return _所有图层["w"];
            }
            __名称 = "k" + __名称;
            if (!_所有图层.ContainsKey(__名称))
            {
                throw new ApplicationException("图层名称不存在");
            }
            return _所有图层[__名称];
        }

        public UInt64 添加点(M经纬度 __点, Image __图片, string __标题 = null, object __绑定对象 = null, string __图层名称 = null, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver, bool __图标偏移 = false)
        {
            if (this.InvokeRequired)
            {
                var __信号量 = this.BeginInvoke(new Func<M经纬度, Image, string, object, string, E标题显示方式, bool, UInt64>(添加点), __点, __图片, __标题, __绑定对象, __图层名称, __标题显示方式, __图标偏移);
                __信号量.AsyncWaitHandle.WaitOne();
                return (UInt64)this.EndInvoke(__信号量);
            }
            return 添加点(获取图层(__图层名称), __点, __图片, __标题, __绑定对象 != null || __标题 != null, __绑定对象, __标题显示方式, __图标偏移);
        }

        public UInt64 添加点(M经纬度 __点, M点绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                var __信号量 = this.BeginInvoke(new Func<M经纬度, M点绘制参数, object, string, UInt64>(添加点), __点, __绘制参数, __绑定对象, __图层名称);
                __信号量.AsyncWaitHandle.WaitOne();
                return (UInt64)this.EndInvoke(__信号量);
            }
            return 添加点(获取图层(__图层名称), __点, __绘制参数.图片, __绘制参数.标题, __绑定对象 != null || __绘制参数.标题 != null, __绑定对象, __绘制参数.标题显示方式, __绘制参数.偏移);
        }

        private UInt64 添加点(GMapOverlay __图层, M经纬度 __点, Image __图片, string __标题 = null, bool __允许交互 = true, object __绑定对象 = null, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver, bool __图标偏移 = true)
        {
            var __GPS = GPS转换(__点);
            //GMapMarker __图标 = new GMarkerGoogle(__GPS, GMarkerGoogleType.blue_small);
            GMapMarker __图标 = new GMarkerGoogle(__GPS, __图片);
            __图标.ToolTipText = __标题;
            __图标.ToolTipMode = (MarkerTooltipMode)(int)__标题显示方式;
            __图标.Tag = __绑定对象;
            if (__图标偏移)
            {
                __图标.Offset = new Point(-__图片.Width / 2 + 1, -__图片.Height + 1);
            }
            __图标.IsHitTestVisible = __允许交互;
            __图层.Markers.Add(__图标);
            var __标识 = _所有覆盖物[__图层].标识++;
            _所有覆盖物[__图层].点集[__标识] = __图标;
            return __标识;
        }

        public void 删除点(UInt64 __标识, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<UInt64, string>(删除点), __标识, __图层名称);
                return;
            }
            var __图层 = 获取图层(__图层名称);
            if (_所有覆盖物[__图层].点集.ContainsKey(__标识))
            {
                __图层.Markers.Remove(_所有覆盖物[__图层].点集[__标识]);
                _所有覆盖物[__图层].点集.Remove(__标识);
            }
        }

        public void 定位(M经纬度 __点)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M经纬度>(定位), __点);
                return;
            }

            this.out地图控件.Position = GPS转换(__点);
        }

        public void 定位(List<M经纬度> __位置列表)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<List<M经纬度>>(定位), __位置列表);
                return;
            }

            if (__位置列表.Count == 1)
            {
                this.out地图控件.Position = GPS转换(__位置列表[0]);
            }
            else
            {
                double __最小经度 = 180;
                double __最大经度 = -180;
                double __最小纬度 = 90;
                double __最大纬度 = -90;
                __位置列表.ForEach(q =>
                {
                    __最小经度 = Math.Min(__最小经度, q.经度);
                    __最大经度 = Math.Max(__最大经度, q.经度);
                    __最小纬度 = Math.Min(__最小纬度, q.纬度);
                    __最大纬度 = Math.Max(__最大纬度, q.纬度);
                });
                var __左上 = GPS转换(new M经纬度(__最小经度, __最大纬度));
                var __右下 = GPS转换(new M经纬度(__最大经度, __最小纬度));
                this.out地图控件.SetZoomToFitRect(RectLatLng.FromLTRB(__左上.Lng, __左上.Lat, __右下.Lng, __右下.Lat));
            }
        }

        public UInt64 添加线(List<M经纬度> __点列表, int __线宽度, Color __线颜色, object __绑定对象 = null, string __图层名称 = null)
        {
            return 添加线(__点列表, new Pen(__线颜色) { Width = __线宽度 }, __绑定对象 != null, __绑定对象, __图层名称);
        }

        /// <summary>
        ///  可以绘制特殊的线, 例如设置画笔的参数为DashPattern = new float[] { 4.0F, 4.0F }//new float[]{4.0F, 2.0F, 1.0F, 3.0F};
        /// </summary>
        public UInt64 添加线(List<M经纬度> __点列表, Pen __画笔, bool __允许交互, object __绑定对象 = null, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                var __信号量 = this.BeginInvoke(new Func<List<M经纬度>, Pen, bool, object, string, UInt64>(添加线), __点列表, __画笔, __允许交互, __绑定对象, __图层名称);
                __信号量.AsyncWaitHandle.WaitOne();
                return (UInt64)this.EndInvoke(__信号量);
            }
            var __图层 = 获取图层(__图层名称);
            var __GPS = new List<PointLatLng>();
            __点列表.ForEach(q => __GPS.Add(GPS转换(q)));
            var __线 = new GMapRoute(__GPS, "")
            {
                Tag = __绑定对象,
                IsHitTestVisible = __允许交互,
                Stroke = __画笔
            };
            __图层.Routes.Add(__线);
            var __标识 = _所有覆盖物[__图层].标识++;
            _所有覆盖物[__图层].线集[__标识] = __线;
            return __标识;
        }

        public void 删除线(UInt64 __标识, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<UInt64, string>(删除线), __标识, __图层名称);
                return;
            }

            var __图层 = 获取图层(__图层名称);
            if (_所有覆盖物[__图层].线集.ContainsKey(__标识))
            {
                __图层.Routes.Remove(_所有覆盖物[__图层].线集[__标识]);
                _所有覆盖物[__图层].线集.Remove(__标识);
            }
        }

        public UInt64 添加多边形(List<M经纬度> __点列表, M区域绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null)
        {
            return 添加多边形(__点列表, new Pen(__绘制参数.边框颜色, __绘制参数.边框宽度), new SolidBrush(__绘制参数.填充颜色), __绑定对象 != null, __绑定对象, __图层名称);
        }

        public UInt64 添加多边形(List<M经纬度> __点列表, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, object __绑定对象 = null, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                var __信号量 = this.BeginInvoke(new Func<List<M经纬度>, Pen, Brush, bool, object, string, UInt64>(添加多边形), __点列表, __边框画笔, __填充笔刷, __允许交互, __绑定对象, __图层名称);
                __信号量.AsyncWaitHandle.WaitOne();
                return (UInt64)this.EndInvoke(__信号量);
            }
            var __图层 = 获取图层(__图层名称);
            var __GPS = new List<PointLatLng>();
            __点列表.ForEach(q => __GPS.Add(GPS转换(q)));
            var __区域 = new GMapPolygon(__GPS, "")
            {
                Tag = __绑定对象,
                Stroke = __边框画笔,
                IsHitTestVisible = __允许交互,
                Fill = __填充笔刷,
            };
            __图层.Polygons.Add(__区域);
            var __标识 = _所有覆盖物[__图层].标识++;
            _所有覆盖物[__图层].多边形集[__标识] = __区域;
            return __标识;
        }

        public void 删除多边形(UInt64 __标识, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<UInt64, string>(删除多边形), __标识, __图层名称);
                return;
            }
            var __图层 = 获取图层(__图层名称);
            if (_所有覆盖物[__图层].多边形集.ContainsKey(__标识))
            {
                __图层.Polygons.Remove(_所有覆盖物[__图层].多边形集[__标识]);
                _所有覆盖物[__图层].多边形集.Remove(__标识);
            }
        }

        public UInt64 添加矩形(M经纬度 __左上角点, M经纬度 __右下角点, M区域绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null)
        {
            var __点列表 = new List<M经纬度> {                         
                        __左上角点,
                        __左上角点.偏移(__右下角点.经度 - __左上角点.经度, 0),
                        __右下角点,
                        __右下角点.偏移(__左上角点.经度 - __右下角点.经度, 0),
                     };
            return 添加多边形(__点列表, __绘制参数, __绑定对象, __图层名称);
        }

        public UInt64 添加矩形(M经纬度 __左上角点, M经纬度 __右下角点, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, object __绑定对象 = null, string __图层名称 = null)
        {
            var __点列表 = new List<M经纬度> {                         
                        __左上角点,
                        __左上角点.偏移(__右下角点.经度 - __左上角点.经度, 0),
                        __右下角点,
                        __右下角点.偏移(__左上角点.经度 - __右下角点.经度, 0),
                     };
            return 添加多边形(__点列表, __边框画笔, __填充笔刷, __允许交互, __绑定对象, __图层名称);
        }

        public void 删除矩形(UInt64 __标识, string __图层名称 = null)
        {
            删除多边形(__标识, __图层名称);
        }

        /// <param name="__半径">单位:米</param>
        /// <param name="__绑定对象">暂不支持</param>
        public UInt64 添加圆(M经纬度 __圆心, int __半径, M区域绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null)
        {
            return 添加圆(__圆心, __半径, new Pen(__绘制参数.边框颜色) { Width = __绘制参数.边框宽度 }, new SolidBrush(__绘制参数.填充颜色), __绑定对象 != null, __绑定对象,
                __图层名称);
        }

        public UInt64 添加圆(M经纬度 __圆心, int __半径, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, object __绑定对象 = null, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                var __信号量 = this.BeginInvoke(new Func<M经纬度, int, Pen, Brush, bool, object, string, UInt64>(添加圆), __圆心, __半径, __边框画笔, __填充笔刷, __允许交互, __绑定对象, __图层名称);
                __信号量.AsyncWaitHandle.WaitOne();
                return (UInt64)this.EndInvoke(__信号量);
            }
            var __图层 = 获取图层(__图层名称);
            var __覆盖范围 = new GMapMarkerCircle(GPS转换(__圆心), __边框画笔, __填充笔刷, __允许交互) { Radius = __半径, IsFilled = __填充笔刷 != null };
            __图层.Markers.Add(__覆盖范围);
            var __标识 = _所有覆盖物[__图层].标识++;
            _所有覆盖物[__图层].点集[__标识] = __覆盖范围;
            return __标识;
        }

        public void 删除圆(UInt64 __标识, string __图层名称 = null)
        {
            删除点(__标识, __图层名称);
        }

        public UInt64 添加麻点图(List<M经纬度> __点列表, Image __图片, string __标题 = null, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                var __信号量 = this.BeginInvoke(new Func<List<M经纬度>, Image, string, E标题显示方式, string, UInt64>(添加麻点图), __点列表, __图片, __标题, __标题显示方式, __图层名称);
                __信号量.AsyncWaitHandle.WaitOne();
                return (UInt64)this.EndInvoke(__信号量);
            }
            var __图层 = 获取图层(__图层名称);
            var __点缓存 = new List<UInt64>();
            __点列表.ForEach(q => __点缓存.Add(添加点(__图层, q, __图片, __标题, false, null, __标题显示方式)));
            var __标识 = _所有覆盖物[__图层].标识++;
            _所有覆盖物[__图层].麻点图集[__标识] = __点缓存;
            return __标识;
        }

        public void 删除麻点图(UInt64 __标识, string __图层名称 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<UInt64, string>(删除麻点图), __标识, __图层名称);
                return;
            }
            var __图层 = 获取图层(__图层名称);
            if (_所有覆盖物[__图层].麻点图集.ContainsKey(__标识))
            {
                _所有覆盖物[__图层].麻点图集[__标识].ForEach(q => 删除点(q, __图层名称));
                _所有覆盖物[__图层].麻点图集.Remove(__标识);
            }
        }

        #region 包装地图事件

        void out地图控件_OnMapZoomChanged()
        {
            On地图缩放(this.当前层级);
        }

        void out地图控件_OnRouteLeave(GMapRoute item)
        {
            if (item.Tag == null)
            {
                return;
            }
            On离开线(item.Tag);
        }

        void out地图控件_OnRouteEnter(GMapRoute item)
        {
            if (item.Tag == null)
            {
                return;
            }
            On进入线(item.Tag);
        }

        void out地图控件_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            if (item.Tag == null)
            {
                return;
            }
            On单击线(item.Tag, e);
        }

        void out地图控件_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.Tag == null)
            {
                return;
            }
            On单击点(item.Tag, e);
        }

        void out地图控件_OnMarkerLeave(GMapMarker item)
        {
            if (item.Tag == null)
            {
                return;
            }
            On离开点(item.Tag);
        }

        void out地图控件_OnMarkerEnter(GMapMarker item)
        {
            if (item.Tag == null)
            {
                return;
            }
            On进入点(item.Tag);
        }

        void out地图控件_OnPolygonLeave(GMapPolygon item)
        {
            if (item.Tag == null)
            {
                return;
            }
            On离开多边形(item.Tag);
        }

        void out地图控件_OnPolygonEnter(GMapPolygon item)
        {
            if (item.Tag == null)
            {
                return;
            }
            On进入多边形(item.Tag);
        }

        void out地图控件_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            if (item.Tag == null)
            {
                return;
            }
            On单击多边形(item.Tag, e);
        }

        public event Action<object, MouseEventArgs> 单击点;

        protected virtual void On单击点(object arg, MouseEventArgs e)
        {
            var handler = 单击点;
            if (handler != null) handler(arg, e);
        }

        /// <summary>
        /// 参数为tag
        /// </summary>
        public event Action<object> 进入点;

        protected virtual void On进入点(object arg)
        {
            var handler = 进入点;
            if (handler != null) handler(arg);
        }

        /// <summary>
        /// 参数为tag
        /// </summary>
        public event Action<object> 离开点;

        protected virtual void On离开点(object arg)
        {
            var handler = 离开点;
            if (handler != null) handler(arg);
        }

        public event Action<int> 地图缩放;

        protected virtual void On地图缩放(int 层级)
        {
            Action<int> handler = 地图缩放;
            if (handler != null) handler(层级);
        }

        public event Action<object, MouseEventArgs> 单击线;

        protected virtual void On单击线(object arg, MouseEventArgs e)
        {
            var handler = 单击线;
            if (handler != null) handler(arg, e);
        }

        public event Action<object> 进入线;

        protected virtual void On进入线(object arg)
        {
            var handler = 进入线;
            if (handler != null) handler(arg);
        }

        public event Action<object> 离开线;

        protected virtual void On离开线(object arg)
        {
            var handler = 离开线;
            if (handler != null) handler(arg);
        }


        public event Action<object, MouseEventArgs> 单击多边形;

        protected virtual void On单击多边形(object arg, MouseEventArgs e)
        {
            var handler = 单击多边形;
            if (handler != null) handler(arg, e);
        }

        public event Action<object> 进入多边形;

        protected virtual void On进入多边形(object obj)
        {
            var handler = 进入多边形;
            if (handler != null) handler(obj);
        }

        public event Action<object> 离开多边形;

        protected virtual void On离开多边形(object obj)
        {
            var handler = 离开多边形;
            if (handler != null) handler(obj);
        }

        #endregion

    }

}
