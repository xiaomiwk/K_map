using System;
using System.Collections;
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
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_示例
{
    public partial class F主窗口 : Form
    {
        private readonly IF地图 _IF地图;

        private readonly List<UInt64> _点索引 = new List<UInt64>();

        private readonly List<UInt64> _线索引 = new List<UInt64>();

        private readonly List<UInt64> _圆索引 = new List<UInt64>();

        private readonly List<UInt64> _多边形索引 = new List<UInt64>();

        private readonly List<UInt64> _麻点图索引 = new List<UInt64>();

        private readonly List<UInt64> _区域检索索引 = new List<UInt64>();

        private readonly List<UInt64> _地址编码索引 = new List<UInt64>();

        private readonly List<UInt64> _线路查询索引 = new List<UInt64>();

        private F提示 _绑定对象信息框;

        private F圈选_单次 _单次圈选窗口;

        private F圈选_多次 _多次圈选窗口;

        private string _圈选窗口业务;

        private List<M经纬度> _圈选测试数据 = new List<M经纬度>();

        private B轨迹 _B轨迹;

        private Dictionary<string, UInt64> _轨迹点缓存 = new Dictionary<string, UInt64>();

        private Dictionary<string, UInt64> _轨迹线缓存 = new Dictionary<string, UInt64>();

        private F测距 _F测距;

        private M经纬度 _中心位置 = H行政区位置.查询城市经纬度("南京市");

        public F主窗口()
        {
            InitializeComponent();
            _IF地图 = this.out地图;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text += "  -  " + Assembly.GetExecutingAssembly().GetName().Version;
            this.in区域检索_城市.Text = "南京市";
            this.in区域检索_关键字.Text = "威尼斯水城";
            this.in地址编码_城市.Text = "南京市";
            this.in地址编码_地名.Text = "威尼斯水城";
            this.in逆地址编码_经度.Text = "118.7519";
            this.in逆地址编码_纬度.Text = "32.1359";
            this.in查询路径_从城市.Text = "南京市";
            this.in查询路径_到城市.Text = "南京市";
            this.in查询路径_从地名.Text = "威尼斯水城";
            this.in查询路径_到地名.Text = "蓝旗街";
            this.in查询路径_从经纬度.Text = "118.7519,32.1359";
            this.in查询路径_到经纬度.Text = "118.8229,32.02552";

            this.in查询路径_地名_方式.Items.Clear();
            this.in查询路径_地名_方式.Items.AddRange(Enum.GetNames(typeof(E驾车路线选择策略)));
            this.in查询路径_地名_方式.SelectedItem = E驾车路线选择策略.最少时间.ToString();
            this.in查询路径_经纬度_方式.Items.Clear();
            this.in查询路径_经纬度_方式.Items.AddRange(Enum.GetNames(typeof(E驾车路线选择策略)));
            this.in查询路径_经纬度_方式.SelectedItem = E驾车路线选择策略.最少时间.ToString();

            _IF地图.地图缩放 += out地图_地图缩放;
            _IF地图.单击点 += 鼠标单击;
            _IF地图.进入点 += 鼠标进入;
            _IF地图.离开点 += 鼠标离开;
            _IF地图.单击线 += 鼠标单击;
            _IF地图.进入线 += 鼠标进入;
            _IF地图.离开线 += 鼠标离开;
            _IF地图.单击多边形 += 鼠标单击;
            _IF地图.进入多边形 += 鼠标进入;
            _IF地图.离开多边形 += 鼠标离开;

            this.out层级.Text = _IF地图.当前层级.ToString();

            this.do加载地图.Click += do加载地图_Click;
            this.do添加覆盖物.Click += do添加覆盖物_Click;
            this.do添加覆盖物2.Click += do添加覆盖物2_Click;
            this.do删除覆盖物.Click += do删除覆盖物_Click;
            this.do定位初始点.Click += (sender1, e1) => _IF地图.定位(_中心位置);
            this.do单次圈选.Click += do单次圈选_Click;
            this.do多次圈选.Click += do多次圈选_Click;
            this.do模拟轨迹.Click += do模拟轨迹_Click;
            this.do图层操作.Click += do图层操作_Click;
            this.out地图.MouseMove += out地图_MouseMove;
            this.do开始测距.Click += do开始测距_Click;

            //在线应用
            this.do区域检索_城市.Click += do区域检索_城市_Click;
            this.do区域检索_圈选.Click += do区域检索_圈选_Click;
            this.do逆地址编码.Click += do逆地址编码_Click;
            this.do地址编码.Click += do地址编码_Click;
            this.do查询路径_驾车_地名.Click += do查询路径_驾车_地名_Click;
            this.do查询路径_驾车_经纬度.Click += do查询路径_驾车_经纬度_Click;
            this.do查询路径_公交_地名.Click += do查询路径_公交_地名_Click;
            this.do查询路径_公交_经纬度.Click += do查询路径_公交_经纬度_Click;

            _单次圈选窗口 = new F圈选_单次(this.out地图) { Left = this.out地图.Left + 100, Top = this.out地图.Top + 30 };
            this.Controls.Add(_单次圈选窗口);
            _单次圈选窗口.BringToFront();
            _单次圈选窗口.Hide();

            _多次圈选窗口 = new F圈选_多次(this.out地图) { Left = this.out地图.Left + 100, Top = this.out地图.Top + 30 };
            this.Controls.Add(_多次圈选窗口);
            _多次圈选窗口.BringToFront();
            _多次圈选窗口.Hide();

            this.do加载地图.PerformClick();

            this.Activate();
        }

        void do开始测距_Click(object sender, EventArgs e)
        {
            if (_F测距 == null)
            {
                _F测距 = new F测距(this.out地图);
            }
            if (this.do开始测距.Text == "开始测距")
            {
                this.do开始测距.Text = "结束测距";
                _F测距.开始();
            }
            else
            {
                this.do开始测距.Text = "开始测距";
                _F测距.结束();
            }
        }

        void do加载地图_Click(object sender, EventArgs e)
        {
            new F选择地图(_IF地图).ShowDialog();
        }

        void do添加覆盖物_Click(object sender, EventArgs e)
        {
            添加覆盖物(null);
        }

        private void 添加覆盖物(string __图层名称)
        {
            var __图标1 = H图标.获取图标(E常用图标.默认图标_红色);
            var __图标2 = H图标.获取图标(E常用图标.开始);
            _点索引.Add(_IF地图.添加点(_中心位置.偏移(-0.05, 0), __图标1, "x1", new M示例业务对象 { 标识 = 1, 类型 = "基站", 名称 = "基站1", 状态 = "正常" }, __图层名称, E标题显示方式.Always, true));
            _点索引.Add(_IF地图.添加点(_中心位置.偏移(0.05, 0), __图标2, "y1", new M示例业务对象 { 标识 = 2, 类型 = "车台", 名称 = "车台1", 状态 = "正常" }, __图层名称));
            Debug.WriteLine("线起点: {0}; \r\n线终点: {1}", _中心位置.偏移(-0.05, 0), _中心位置.偏移(0.05, 0));
            Debug.WriteLine("线起点: {0}; \r\n线终点: {1}", _IF地图.纠偏(_中心位置.偏移(-0.05, 0)), _IF地图.纠偏(_中心位置.偏移(0.05, 0)));
            _线索引.Add(_IF地图.添加线(new List<M经纬度>
            {
                _中心位置.偏移(-0.05,0), 
                _中心位置.偏移(0.05, 0)
            }, 2, Color.Red, new M示例业务对象 { 标识 = 2, 类型 = "连接状态", 名称 = "基站1-车台1", 状态 = "正常" }, __图层名称));
            _圆索引.Add(_IF地图.添加圆(_中心位置.偏移(-0.02, -0.02), 1000, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(255, 0, 0, 255), 填充颜色 = Color.FromArgb(55, 135, 206, 235) }, new M示例业务对象 { 标识 = 2, 类型 = "圆", 名称 = "圆1", 状态 = "正常" }, __图层名称));
            _多边形索引.Add(_IF地图.添加多边形(new List<M经纬度>
            {
                _中心位置.偏移(0.02, 0.02),
                _中心位置.偏移(0.02, 0.03),
                _中心位置.偏移(0.01, 0.04),
                _中心位置.偏移(0.01, 0.03),
                _中心位置.偏移(-0.01, 0.03),
            }, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.Blue, 填充颜色 = Color.FromArgb(55, 135, 206, 235) }, new M示例业务对象 { 标识 = 2, 类型 = "区域", 名称 = "区域1", 状态 = "正常" }, __图层名称));
        }

        void do添加覆盖物2_Click(object sender, EventArgs e)
        {
            //添加随机用户麻点
            var r = new Random();
            var __图标 = H图标.获取图标(E常用图标.默认图标_红色_小);
            for (int i = 0; i < 5000; i++)
            {
                var __经度 = _中心位置.经度 - 0.5 + r.NextDouble() * 1;
                var __纬度 = _中心位置.纬度 - 0.5 + r.NextDouble() * 1;
                var __经纬度 = new M经纬度(__经度, __纬度);
                _圈选测试数据.Add(__经纬度);
            }
            //_圈选测试数据.Add(new M经纬度(118.8200000, 32.0500000));
            //_圈选测试数据.Add(new M经纬度(118.8220000, 32.0520000));
            //_圈选测试数据.Add(new M经纬度(118.8240000, 32.0540000));
            //_圈选测试数据.Add(new M经纬度(118.8160000, 32.0560000));
            //_圈选测试数据.Add(new M经纬度(118.8160000, 32.0580000));
            _麻点图索引.Add(_IF地图.添加麻点图(_圈选测试数据, __图标));

            //添加行政区域
            var __行政区 = H行政区位置.所有.Find(q => q.省 == "江苏省" && q.市 == "南京市" && q.区 == "浦口区");
            if (__行政区 != null && __行政区.边界坐标.Count > 0)
            {
                _线索引.Add(_IF地图.添加线(__行政区.边界坐标[0], 2, Color.Blue));
            }
        }

        void do删除覆盖物_Click(object sender, EventArgs e)
        {
            _点索引.ForEach(q => _IF地图.删除点(q));
            _线索引.ForEach(q => _IF地图.删除线(q));
            _多边形索引.ForEach(q => _IF地图.删除多边形(q));
            _圆索引.ForEach(q => _IF地图.删除圆(q));

            //删除覆盖物2
            _麻点图索引.ForEach(q => _IF地图.删除麻点图(q));
            _圈选测试数据.Clear();
        }

        void do单次圈选_Click(object sender, EventArgs e)
        {
            if (_单次圈选窗口.Visible)
            {
                if (_圈选窗口业务 != "圈选覆盖物")
                {
                    MessageBox.Show("圈选工具正用于'" + _圈选窗口业务 + "', 请先处理完毕并关闭圈选工具, 然后再次打开");
                }
                return;
            }
            _圈选窗口业务 = "圈选覆盖物";
            _单次圈选窗口.自动删除圈选 = false;
            _单次圈选窗口.处理矩形圈选结束 += 处理矩形圈选;
            _单次圈选窗口.处理圆形圈选结束 += 处理圆形圈选;
            _单次圈选窗口.处理多边形圈选结束 += 处理多边形圈选;
            _单次圈选窗口.VisibleChanged += (sender1, e1) =>
            {
                if (!_单次圈选窗口.Visible)
                {
                    _单次圈选窗口.删除圈选区域();
                    _单次圈选窗口.处理矩形圈选结束 -= 处理矩形圈选;
                    _单次圈选窗口.处理圆形圈选结束 -= 处理圆形圈选;
                    _单次圈选窗口.处理多边形圈选结束 -= 处理多边形圈选;
                }
            };
            _单次圈选窗口.Visible = true;
        }

        void 处理圆形圈选(M经纬度 __圆心, int __半径)
        {
            if (_圈选测试数据.Count == 0)
            {
                return;
            }
            var __圈选数量 = 0;
            _圈选测试数据.ForEach(q =>
            {
                if (H地图算法.判断点在圆形内(_IF地图.纠偏(q), __圆心, __半径))
                {
                    __圈选数量++;
                }
            });
            MessageBox.Show("圈选数量: " + __圈选数量);
            //_IF地图.添加圆(__圆心, __半径, new M区域绘制参数 {边框宽度 = 1, 边框颜色 = Color.Red});
        }

        void 处理矩形圈选(M经纬度 __左上角, M经纬度 __右下角)
        {
            if (_圈选测试数据.Count == 0)
            {
                return;
            }
            var __圈选数量 = 0;
            var __矩形点集 = new List<M经纬度>
                    {
                        __左上角,
                        __左上角.偏移(__右下角.经度 - __左上角.经度, 0),
                        __右下角,
                        __右下角.偏移(__左上角.经度 - __右下角.经度, 0),
                    };
            _圈选测试数据.ForEach(q =>
            {
                if (H地图算法.判断点在矩形内(_IF地图.纠偏(q), __矩形点集))
                {
                    __圈选数量++;
                }
            });
            MessageBox.Show("圈选数量: " + __圈选数量);
            //_IF地图.添加矩形(__左上角, __右下角, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.Red });
        }

        void 处理多边形圈选(List<M经纬度> __顶点列表)
        {
            if (_圈选测试数据.Count == 0)
            {
                return;
            }
            var __圈选数量 = 0;
            _圈选测试数据.ForEach(q =>
            {
                if (H地图算法.判断点在多边形内(_IF地图.纠偏(q), __顶点列表))
                {
                    __圈选数量++;
                }
            });
            MessageBox.Show("圈选数量: " + __圈选数量);
            //_IF地图.添加多边形(__顶点列表, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.Red});
        }

        void do多次圈选_Click(object sender, EventArgs e)
        {
            var __绘制参数 = new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(180, Color.Green), 填充颜色 = Color.FromArgb(20, Color.Green) };
            var __圆形索引 = new List<ulong>();
            var __矩形索引 = new List<ulong>();
            var __多边形索引 = new List<ulong>();
            Action<M经纬度, int> __处理圈选圆形 = (__圆心, __半径) => __圆形索引.Add(_IF地图.添加圆(__圆心, __半径, __绘制参数));
            Action<M经纬度, M经纬度> __处理圈选矩形 = (__左上角, __右下角) => __矩形索引.Add(_IF地图.添加矩形(__左上角, __右下角, __绘制参数));
            Action<List<M经纬度>> __处理圈选多边形 = __顶点列表 => __多边形索引.Add(_IF地图.添加多边形(__顶点列表, __绘制参数));
            _多次圈选窗口.处理矩形圈选结束 += __处理圈选矩形;
            _多次圈选窗口.处理圆形圈选结束 += __处理圈选圆形;
            _多次圈选窗口.处理多边形圈选结束 += __处理圈选多边形;
            _多次圈选窗口.VisibleChanged += (sender1, e1) =>
            {
                if (!_多次圈选窗口.Visible)
                {
                    _多次圈选窗口.删除圈选区域();
                    //删除图形
                    __圆形索引.ForEach(q => _IF地图.删除圆(q));
                    __矩形索引.ForEach(q => _IF地图.删除矩形(q));
                    __多边形索引.ForEach(q => _IF地图.删除多边形(q));
                    _多次圈选窗口.处理矩形圈选结束 -= __处理圈选矩形;
                    _多次圈选窗口.处理圆形圈选结束 -= __处理圈选圆形;
                    _多次圈选窗口.处理多边形圈选结束 -= __处理圈选多边形;
                }
            };
            _多次圈选窗口.Visible = true;
        }

        void do模拟轨迹_Click(object sender, EventArgs e)
        {
            if (_B轨迹 == null)
            {
                _B轨迹 = new B轨迹();
                const int __线中点最多数量 = 5;
                _B轨迹.位置更新 += (string __号码, M经纬度 __最新位置, List<M经纬度> __轨迹缓存) =>
                {
                    if (!_B轨迹.订阅中)
                    {
                        return;
                    }
                    if (_轨迹点缓存.ContainsKey(__号码))
                    {
                        _IF地图.删除点(_轨迹点缓存[__号码]);
                    }
                    _轨迹点缓存[__号码] = _IF地图.添加点(__最新位置, H图标.获取图标(E常用图标.默认图标_蓝色), __号码);
                    if (_轨迹线缓存.ContainsKey(__号码))
                    {
                        _IF地图.删除线(_轨迹线缓存[__号码]);
                    }
                    if (__轨迹缓存.Count >= 2)
                    {
                        var __点数量 = Math.Min(__轨迹缓存.Count, __线中点最多数量);
                        _轨迹线缓存[__号码] = _IF地图.添加线(__轨迹缓存.GetRange(__轨迹缓存.Count - __点数量, __点数量), 2, Color.Yellow);
                    }
                };
                _B轨迹.取消完毕 += () =>
                {
                    _轨迹线缓存.Values.ToList().ForEach(q => _IF地图.删除线(q));
                    _轨迹点缓存.Values.ToList().ForEach(q => _IF地图.删除点(q));
                    _轨迹线缓存.Clear();
                    _轨迹点缓存.Clear();
                };
            }
            if (_B轨迹.订阅中)
            {
                _B轨迹.取消订阅();
            }
            else
            {
                var __参数窗口 = new F轨迹参数() { StartPosition = FormStartPosition.CenterParent };
                if (__参数窗口.ShowDialog() == DialogResult.OK)
                {
                    _B轨迹.订阅(__参数窗口.数量, __参数窗口.频率, _中心位置);
                }
            }
        }

        void do图层操作_Click(object sender, EventArgs e)
        {
            var __图层 = new F图层();
            EventHandler __增加图层 = (sender1, e1) =>
            {
                this._IF地图.添加图层("1");
                _IF地图.添加圆(_中心位置.偏移(-0.02, -0.02), 1000, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(255, 0, 0, 255), 填充颜色 = Color.FromArgb(55, 135, 206, 235) }, new M示例业务对象 { 标识 = 2, 类型 = "圆", 名称 = "圆1", 状态 = "正常" }, "1");
                this._IF地图.添加图层("2");
                _IF地图.添加圆(_中心位置.偏移(-0.02, -0.03), 1000, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(255, 255, 0, 255), 填充颜色 = Color.FromArgb(255, 135, 206, 235) }, new M示例业务对象 { 标识 = 2, 类型 = "圆", 名称 = "圆1", 状态 = "正常" }, "2");
                this._IF地图.调整图层顺序("1", 1);
                this._IF地图.调整图层顺序("2", 2);
            };
            EventHandler __删除图层 = (sender1, e1) =>
            {
                this._IF地图.删除图层("1");
                this._IF地图.删除图层("2");
            };
            EventHandler __隐藏图层 = (sender1, e1) =>
            {
                this._IF地图.隐藏图层("1");
            };
            EventHandler __显示图层 = (sender1, e1) =>
            {
                this._IF地图.显示图层("1");
            };
            EventHandler __调整顺序 = (sender1, e1) =>
            {
                this._IF地图.调整图层顺序("1", 2);
                this._IF地图.调整图层顺序("2", 1);
                this.out地图.Refresh();
            };
            __图层.增加图层 += __增加图层;
            __图层.删除图层 += __删除图层;
            __图层.隐藏图层 += __隐藏图层;
            __图层.显示图层 += __显示图层;
            __图层.调整顺序 += __调整顺序;
            __图层.ShowDialog();
            __图层.增加图层 -= __增加图层;
            __图层.删除图层 -= __删除图层;
            __图层.隐藏图层 -= __隐藏图层;
            __图层.显示图层 -= __显示图层;
            __图层.调整顺序 -= __调整顺序;
        }

        void out地图_MouseMove(object sender, MouseEventArgs e)
        {
            var __经纬度 = _IF地图.屏幕坐标转经纬度(e.Location);
            this.out经度.Text = __经纬度.经度.ToString("F5");
            this.out纬度.Text = __经纬度.纬度.ToString("F5");
        }

        void 鼠标进入(object obj)
        {
            //如果在进行圈选操作, 不弹出显示
            if (_多次圈选窗口.Visible || _单次圈选窗口.Visible)
            {
                return;
            }
            鼠标离开(obj);
            _绑定对象信息框 = new F提示()
            {
                TopMost = true,
                StartPosition = FormStartPosition.Manual,
                Location = MousePosition,
                ShowIcon = false,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.None,
            };
            _绑定对象信息框.Show();
        }

        void 鼠标离开(object obj)
        {
            if (_绑定对象信息框 != null)
            {
                _绑定对象信息框.Close();
                _绑定对象信息框 = null;
            }
        }

        void 鼠标单击(object obj, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            鼠标离开(obj);
            _绑定对象信息框 = new F提示()
            {
                TopMost = true,
                StartPosition = FormStartPosition.CenterParent,
                ShowIcon = false,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.None,
            };
            _绑定对象信息框.ShowDialog();
        }

        void out地图_地图缩放(int 层级)
        {
            this.out层级.Text = 层级.ToString();
        }

        #region 在线应用
        void do查询路径_驾车_经纬度_Click(object sender, EventArgs e)
        {
            var __从经度 = this.in查询路径_从经纬度.Text.Trim().Split(',')[0];
            var __从纬度 = this.in查询路径_从经纬度.Text.Trim().Split(',')[1];
            var __到经度 = this.in查询路径_到经纬度.Text.Trim().Split(',')[0];
            var __到纬度 = this.in查询路径_到经纬度.Text.Trim().Split(',')[1];
            var __方式 = (E驾车路线选择策略)Enum.Parse(typeof(E驾车路线选择策略), this.in查询路径_经纬度_方式.SelectedItem.ToString());
            try
            {
                List<M地址> __可能起点;
                List<M地址> __可能终点;
                var __线路 = H信息查询.查询驾车线路(new M经纬度(double.Parse(__从经度), double.Parse(__从纬度)) { 类型 = E坐标类型.谷歌 }, new M经纬度(double.Parse(__到经度), double.Parse(__到纬度)) { 类型 = E坐标类型.谷歌 }, "南京市", "南京市", __方式, out __可能起点, out __可能终点);
                显示线路(__线路, __可能起点, __可能终点, this.in查询路径_经纬度_说明);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到路径\n\r" + ex.Message);
            }
        }

        void do查询路径_驾车_地名_Click(object sender, EventArgs e)
        {
            var __从城市 = this.in查询路径_从城市.Text.Trim();
            var __到城市 = this.in查询路径_到城市.Text.Trim();
            var __从地名 = this.in查询路径_从地名.Text.Trim();
            var __到地名 = this.in查询路径_到地名.Text.Trim();
            var __方式 = (E驾车路线选择策略)Enum.Parse(typeof(E驾车路线选择策略), this.in查询路径_地名_方式.SelectedItem.ToString());
            try
            {
                List<M地址> __可能起点;
                List<M地址> __可能终点;
                var __线路 = H信息查询.查询驾车线路(__从地名, __到地名, __从城市, __到城市, __方式, out __可能起点, out __可能终点);
                显示线路(__线路, __可能起点, __可能终点, this.in查询路径_地名_说明);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到路径\n\r" + ex.Message);
            }
        }

        private void 显示线路(M线路 __线路, List<M地址> __可能起点, List<M地址> __可能终点, TextBox __输出信息)
        {
            _线路查询索引.ForEach(q => _IF地图.删除线(q));
            _线路查询索引.ForEach(q => _IF地图.删除点(q));
            __输出信息.Text = "";
            if (__线路 == null)
            {
                __可能起点.ForEach(
                    q => _线路查询索引.Add(_IF地图.添加点(q.坐标, H图标.获取图标(E常用图标.开始), q.名称, null, null, E标题显示方式.Always)));
                __可能终点.ForEach(
                    q => _线路查询索引.Add(_IF地图.添加点(q.坐标, H图标.获取图标(E常用图标.停止), q.名称, null, null, E标题显示方式.Always)));
                _IF地图.定位(__可能起点.Concat(__可能终点).Select(q => q.坐标).ToList());
                var __说明1 = new StringBuilder();
                __说明1.AppendLine("可能起点:");
                __可能起点.ForEach(q =>
                {
                    __说明1.AppendLine(q.名称);
                    if (!string.IsNullOrEmpty(q.详细地址))
                    {
                        __说明1.AppendLine(q.详细地址);
                    }
                    if (!string.IsNullOrEmpty(q.备注))
                    {
                        __说明1.AppendLine(q.备注);
                    }
                    __说明1.AppendLine();
                });
                __输出信息.Text = __说明1.ToString();
                MessageBox.Show("请输入精确的起点/终点");
                return;
            }
            var __说明 = new StringBuilder();
            __线路.步骤说明.ForEach(q => __说明.AppendLine(q));
            __输出信息.Text = string.Format("距离: {0}公里{3}{1}{3}{2}", __线路.距离 * 1.0 / 1000, __线路.备注, __说明, Environment.NewLine);
            _线路查询索引.Add(_IF地图.添加线(__线路.点集合, 2, Color.Blue, __线路.名称));
            _线路查询索引.Add(_IF地图.添加点(__线路.点集合[0], H图标.获取图标(E常用图标.开始)));
            _线路查询索引.Add(_IF地图.添加点(__线路.点集合[__线路.点集合.Count - 1], H图标.获取图标(E常用图标.停止)));
            _IF地图.定位(__线路.点集合);

        }

        void do查询路径_公交_经纬度_Click(object sender, EventArgs e)
        {
            var __从经度 = this.in查询路径_从经纬度.Text.Trim().Split(',')[0];
            var __从纬度 = this.in查询路径_从经纬度.Text.Trim().Split(',')[1];
            var __到经度 = this.in查询路径_到经纬度.Text.Trim().Split(',')[0];
            var __到纬度 = this.in查询路径_到经纬度.Text.Trim().Split(',')[1];
            var __方式 = (E驾车路线选择策略)Enum.Parse(typeof(E驾车路线选择策略), this.in查询路径_经纬度_方式.SelectedItem.ToString());
            try
            {
                List<M地址> __可能起点;
                List<M地址> __可能终点;
                var __线路列表 = H信息查询.查询公交线路(new M经纬度(double.Parse(__从经度), double.Parse(__从纬度)) { 类型 = E坐标类型.谷歌 }, new M经纬度(double.Parse(__到经度), double.Parse(__到纬度)) { 类型 = E坐标类型.谷歌 }, "南京市", __方式, out __可能起点, out __可能终点);
                显示线路(__线路列表, __可能起点, __可能终点, in查询路径_经纬度_说明);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到路径\n\r" + ex.Message);
            }
        }

        void do查询路径_公交_地名_Click(object sender, EventArgs e)
        {
            var __从城市 = this.in查询路径_从城市.Text.Trim();
            //var __到城市 = this.in查询路径_到城市.Text.Trim();
            var __从地名 = this.in查询路径_从地名.Text.Trim();
            var __到地名 = this.in查询路径_到地名.Text.Trim();
            var __方式 = (E驾车路线选择策略)Enum.Parse(typeof(E驾车路线选择策略), this.in查询路径_地名_方式.SelectedItem.ToString());
            try
            {
                List<M地址> __可能起点;
                List<M地址> __可能终点;
                var __线路列表 = H信息查询.查询公交线路(__从地名, __到地名, __从城市, __方式, out __可能起点, out __可能终点);
                显示线路(__线路列表, __可能起点, __可能终点, this.in查询路径_地名_说明);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到路径\n\r" + ex.Message);
            }
        }

        private void 显示线路(List<M线路> __线路列表, List<M地址> __可能起点, List<M地址> __可能终点, TextBox __输出信息)
        {
            _线路查询索引.ForEach(q => _IF地图.删除线(q));
            _线路查询索引.ForEach(q => _IF地图.删除点(q));
            __输出信息.Text = "";
            if (__线路列表 == null)
            {

                __可能起点.ForEach(
                    q => _线路查询索引.Add(_IF地图.添加点(q.坐标, H图标.获取图标(E常用图标.开始), q.名称, null, null, E标题显示方式.Always)));
                __可能终点.ForEach(
                    q => _线路查询索引.Add(_IF地图.添加点(q.坐标, H图标.获取图标(E常用图标.停止), q.名称, null, null, E标题显示方式.Always)));
                _IF地图.定位(__可能起点.Concat(__可能终点).Select(q => q.坐标).ToList());
                var __说明1 = new StringBuilder();
                __说明1.AppendLine("可能起点:");
                __可能起点.ForEach(q =>
                {
                    __说明1.AppendLine(q.名称);
                    if (!string.IsNullOrEmpty(q.详细地址))
                    {
                        __说明1.AppendLine(q.详细地址);
                    }
                    if (!string.IsNullOrEmpty(q.备注))
                    {
                        __说明1.AppendLine(q.备注);
                    }
                    __说明1.AppendLine();
                });
                __输出信息.Text = __说明1.ToString();
                MessageBox.Show("请输入精确的起点/终点");
                return;
            }
            var __可选颜色 = new Queue<Color>(new Color[] { Color.Red, Color.Blue, Color.Brown, Color.YellowGreen, Color.Coral, Color.Black });
            var __可选颜色描述 = new Queue<string>(new string[] { "红色", "蓝色", "棕色", "绿色", "橙色", "黑色" });
            if (__线路列表.Count > 6) //演示用,只取
            {
                __线路列表 = __线路列表.Take(6).ToList();
            }
            var __说明 = new StringBuilder();
            var __所有点 = new List<M经纬度>();
            __线路列表.ForEach(__线路 =>
            {
                var __颜色 = __可选颜色.Dequeue();
                var __颜色描述 = __可选颜色描述.Dequeue();
                __说明.AppendFormat("====={0}====", __颜色描述).AppendLine().AppendLine(__线路.名称).AppendLine();
                __线路.步骤说明.ForEach(q => __说明.AppendLine(q));
                __说明.AppendLine();
                _线路查询索引.Add(_IF地图.添加线(__线路.点集合, 2, __颜色, __线路.名称));
                __所有点.AddRange(__线路.点集合);
                for (int i = 0; i < __线路.点集合.Count; i++)
                {
                    if (i == 0)
                    {
                        _线路查询索引.Add(_IF地图.添加点(__线路.点集合[i], H图标.获取图标(E常用图标.开始), __线路.步骤说明[i]));
                    }
                    else if (i == __线路.点集合.Count - 1)
                    {
                        _线路查询索引.Add(_IF地图.添加点(__线路.点集合[i], H图标.获取图标(E常用图标.停止)));
                    }
                    else
                    {
                        _线路查询索引.Add(_IF地图.添加点(__线路.点集合[i], H图标.获取图标(E常用图标.默认图标_绿色_小), __线路.步骤说明[i]));
                    }
                }
            });
            _IF地图.定位(__所有点);
            __输出信息.Text = __说明.ToString();

        }

        void do逆地址编码_Click(object sender, EventArgs e)
        {
            var __经度 = this.in逆地址编码_经度.Text.Trim();
            var __纬度 = this.in逆地址编码_纬度.Text.Trim();
            if (string.IsNullOrEmpty(__经度) || string.IsNullOrEmpty(__纬度))
            {
                _地址编码索引.ForEach(q => _IF地图.删除点(q));
                return;
            }
            try
            {
                var __点 = new M经纬度(double.Parse(__经度), double.Parse(__纬度)) { 类型 = E坐标类型.谷歌 };
                var __地名 = H信息查询.逆地址编码(__点);
                if (string.IsNullOrEmpty(__地名))
                {
                    MessageBox.Show("未找到地名");
                    return;
                }
                _地址编码索引.Add(_IF地图.添加点(__点, H图标.获取图标(E常用图标.默认图标_红色), __地名, null, null, E标题显示方式.Always));
                _IF地图.定位(__点);
                MessageBox.Show(__地名);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到地名\n\r" + ex.Message);
            }
        }

        void do地址编码_Click(object sender, EventArgs e)
        {
            var __地名 = this.in地址编码_地名.Text.Trim();
            var __城市 = this.in地址编码_城市.Text.Trim();
            if (string.IsNullOrEmpty(__地名))
            {
                _地址编码索引.ForEach(q => _IF地图.删除点(q));
                return;
            }
            try
            {
                var __点 = H信息查询.地址编码(__地名, __城市);
                if (__点 == null)
                {
                    MessageBox.Show("未找到地名");
                    return;
                }
                _地址编码索引.Add(_IF地图.添加点(__点, H图标.获取图标(E常用图标.默认图标_红色), __地名, null, null, E标题显示方式.Always));
                _IF地图.定位(__点);
                MessageBox.Show(__点.ToString());
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到地名\n\r" + ex.Message);
            }
        }

        void do区域检索_城市_Click(object sender, EventArgs e)
        {
            _区域检索索引.ForEach(q => _IF地图.删除点(q));
            var __关键字 = this.in区域检索_关键字.Text.Trim();
            var __城市 = this.in区域检索_城市.Text.Trim();

            try
            {
                var __点集合 = H信息查询.区域检索(__关键字, __城市);
                if (__点集合.Count == 0)
                {
                    MessageBox.Show("未找到信息");
                    return;
                }
                __点集合.ForEach(q => _区域检索索引.Add(_IF地图.添加点(q.Item1, H图标.获取图标(E常用图标.默认图标_红色), q.Item2, null, null, E标题显示方式.Always)));
                _IF地图.定位(__点集合.Select(q => q.Item1).ToList());
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到信息\n\r" + ex.Message);
            }
        }

        void do区域检索_圈选_Click(object sender, EventArgs e)
        {
            if (_单次圈选窗口.Visible)
            {
                if (_圈选窗口业务 != "区域检索")
                {
                    MessageBox.Show("圈选工具正用于'" + _圈选窗口业务 + "', 请先处理完毕并关闭圈选工具, 然后再次打开");
                }
                return;
            }
            _圈选窗口业务 = "区域检索";
            _单次圈选窗口.自动删除圈选 = true;
            _单次圈选窗口.处理矩形圈选结束 += _区域检索_处理矩形圈选结束;
            _单次圈选窗口.处理圆形圈选结束 += _区域检索_处理圆形圈选结束;
            _单次圈选窗口.VisibleChanged += (sender1, e1) =>
            {
                if (!_单次圈选窗口.Visible)
                {
                    _区域检索索引.ForEach(q => _IF地图.删除点(q));
                    _单次圈选窗口.处理矩形圈选结束 -= _区域检索_处理矩形圈选结束;
                    _单次圈选窗口.处理圆形圈选结束 -= _区域检索_处理圆形圈选结束;
                }
            };
            _单次圈选窗口.Visible = true;
        }

        void _区域检索_处理矩形圈选结束(M经纬度 __左上角, M经纬度 __右下角)
        {
            _区域检索索引.ForEach(q => _IF地图.删除点(q));
            var __关键字 = this.in区域检索_关键字.Text.Trim();
            if (string.IsNullOrEmpty(__关键字))
            {
                MessageBox.Show("请输入关键字");
                return;
            }
            try
            {
                var __点集合 = H信息查询.区域检索(__关键字, __左上角, __右下角);
                if (__点集合.Count == 0)
                {
                    MessageBox.Show("未找到信息");
                    return;
                }
                __点集合.ForEach(q => _区域检索索引.Add(_IF地图.添加点(q.Item1, H图标.获取图标(E常用图标.默认图标_红色), q.Item2, null, null, E标题显示方式.Always)));
                //_I地图.定位(__点集合.Select(q => q.Item1).ToList());
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到信息\n\r" + ex.Message);
            }
        }

        void _区域检索_处理圆形圈选结束(M经纬度 __圆心, int __半径)
        {
            _区域检索索引.ForEach(q => _IF地图.删除点(q));
            var __关键字 = this.in区域检索_关键字.Text.Trim();
            if (string.IsNullOrEmpty(__关键字))
            {
                MessageBox.Show("请输入关键字");
                return;
            }
            try
            {
                var __点集合 = H信息查询.区域检索(__关键字, __圆心, __半径);
                if (__点集合.Count == 0)
                {
                    MessageBox.Show("未找到信息");
                    return;
                }
                __点集合.ForEach(q => _区域检索索引.Add(_IF地图.添加点(q.Item1, H图标.获取图标(E常用图标.默认图标_红色), q.Item2, null, null, E标题显示方式.Always)));
                //_I地图.定位(__点集合.Select(q => q.Item1).ToList());
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("该功能未实现");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到信息\n\r" + ex.Message);
            }
        }

        #endregion
    }
}