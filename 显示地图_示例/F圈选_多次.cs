using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_示例
{
    public partial class F圈选_多次 : UserControl
    {
        public E圈选方式 当前方式 { get; private set; }

        private UInt64 _圈选图形索引;

        private F地图 _I地图;

        private List<Point> _鼠标点击位置列表 = new List<Point>();

        bool _绘制中 = false;

        public F圈选_多次(F地图 __IF地图)
        {
            _I地图 = __IF地图;
            InitializeComponent();
        }

        public void 删除圈选区域()
        {
            if (_圈选图形索引 == 0)
            {
                return;
            }
            switch (当前方式)
            {
                case E圈选方式.无:
                    break;
                case E圈选方式.矩形:
                    _I地图.删除多边形(_圈选图形索引);
                    break;
                case E圈选方式.圆形:
                    _I地图.删除圆(_圈选图形索引);
                    break;
                case E圈选方式.多边形:
                    _I地图.删除线(_圈选图形索引);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do矩形.ForeColor = Color.Yellow;
            当前方式 = E圈选方式.矩形;

            this.do矩形.Click += do矩形_Click;
            this.do圆形.Click += do圆形_Click;
            this.do多边形.Click += do多边形_Click;
            this.do关闭.Click += do关闭_Click;
            _I地图.MouseDown += out地图_MouseDown;
            _I地图.MouseMove += out地图_MouseMove;
            _I地图.MouseUp += out地图_MouseUp;
            //_I地图.MouseClick += out地图_MouseClick;
            _I地图.MouseDoubleClick += out地图_MouseDoubleClick;

            this.do保存.Click += do保存_Click;
            this.do取消.Click += do取消_Click;
        }

        void do取消_Click(object sender, EventArgs e)
        {
            清除();
        }

        void do保存_Click(object sender, EventArgs e)
        {
            switch (当前方式)
            {
                case E圈选方式.无:
                    break;
                case E圈选方式.矩形:
                    if (_鼠标点击位置列表.Count != 2)
                    {
                        MessageBox.Show("请使用鼠标右键绘图");
                        return;
                    }
                    var __矩形起点 = _I地图.屏幕坐标转经纬度(_鼠标点击位置列表[0]);
                    var __矩形终点 = _I地图.屏幕坐标转经纬度(_鼠标点击位置列表[1]);
                    On处理矩形圈选结束(__矩形起点, __矩形终点);
                    break;
                case E圈选方式.圆形:
                    if (_鼠标点击位置列表.Count != 2)
                    {
                        MessageBox.Show("请使用鼠标右键绘图");
                        return;
                    }
                    var __圆形起点 = _I地图.屏幕坐标转经纬度(_鼠标点击位置列表[0]);
                    var __圆形终点 = _I地图.屏幕坐标转经纬度(_鼠标点击位置列表[1]);
                    var __圆心 = __圆形起点;
                    var __半径 = H地图算法.测量两点间间距(__圆心, __圆形终点);
                    On处理圆形圈选结束(__圆心, __半径);
                    break;
                case E圈选方式.多边形:
                    if (_鼠标点击位置列表.Count < 4)
                    {
                        MessageBox.Show("请使用鼠标右键绘图");
                        return;
                    }
                    var __顶点列表 = _鼠标点击位置列表.Select(q => _I地图.屏幕坐标转经纬度(q)).ToList();
                    On处理多边形圈选结束(__顶点列表);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            清除();
        }

        void do关闭_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void do圆形_Click(object sender, EventArgs e)
        {
            this.do圆形.ForeColor = Color.Yellow;
            this.do矩形.ForeColor = Color.White;
            this.do多边形.ForeColor = Color.White;
            清除();
            当前方式 = E圈选方式.圆形;
        }

        private void 清除()
        {
            _鼠标点击位置列表.Clear();
            if (_圈选图形索引 > 0)
            {
                switch (当前方式)
                {
                    case E圈选方式.无:
                        break;
                    case E圈选方式.矩形:
                        _I地图.删除多边形(_圈选图形索引);
                        break;
                    case E圈选方式.圆形:
                        _I地图.删除圆(_圈选图形索引);
                        break;
                    case E圈选方式.多边形:
                        _I地图.删除线(_圈选图形索引);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        void do矩形_Click(object sender, EventArgs e)
        {
            this.do圆形.ForeColor = Color.White;
            this.do矩形.ForeColor = Color.Yellow;
            this.do多边形.ForeColor = Color.White;
            清除();
            当前方式 = E圈选方式.矩形;
        }

        void do多边形_Click(object sender, EventArgs e)
        {
            this.do圆形.ForeColor = Color.White;
            this.do矩形.ForeColor = Color.White;
            this.do多边形.ForeColor = Color.Yellow;
            清除();
            当前方式 = E圈选方式.多边形;
        }

        public event Action<M经纬度, M经纬度> 处理矩形圈选结束;

        protected virtual void On处理矩形圈选结束(M经纬度 左上角, M经纬度 右下角)
        {
            var handler = 处理矩形圈选结束;
            if (handler != null) handler(HGPS坐标转换.转原始坐标(左上角), HGPS坐标转换.转原始坐标(右下角));
        }

        public event Action<M经纬度, int> 处理圆形圈选结束;

        protected virtual void On处理圆形圈选结束(M经纬度 圆心, int 半径)
        {
            var handler = 处理圆形圈选结束;
            if (handler != null) handler(HGPS坐标转换.转原始坐标(圆心), 半径);
        }

        public event Action<List<M经纬度>> 处理多边形圈选结束;

        protected virtual void On处理多边形圈选结束(List<M经纬度> 顶点列表)
        {
            var handler = 处理多边形圈选结束;
            if (handler != null) handler(顶点列表.Select(HGPS坐标转换.转原始坐标).ToList());
        }

        void out地图_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.Visible || e.Button != MouseButtons.Right || 当前方式 == E圈选方式.无 || e.Clicks != 1)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine("out地图_MouseDown Clicks:" + e.Clicks);
            if (!_绘制中)
            {
                清除();
            }
            _绘制中 = true;
            _鼠标点击位置列表.Add(e.Location);
        }

        void out地图_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.Visible || !_绘制中)
            {
                return;
            }
            //System.Diagnostics.Debug.WriteLine("out地图_MouseMove Clicks:" + e.Clicks);
            //Debug.WriteLine("鼠标移动位置: " + e.Location);
            switch (当前方式)
            {
                case E圈选方式.无:
                    break;
                case E圈选方式.矩形:
                    if (e.Button != MouseButtons.Right)
                    {
                        return;
                    }
                    绘制矩形(e);
                    break;
                case E圈选方式.圆形:
                    if (e.Button != MouseButtons.Right)
                    {
                        return;
                    }
                    绘制圆形(e);
                    break;
                case E圈选方式.多边形:
                    绘制多边形(e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void 绘制矩形(MouseEventArgs e)
        {
            var __起点 = _I地图.屏幕坐标转经纬度(_鼠标点击位置列表[0]);
            var __终点 = _I地图.屏幕坐标转经纬度(e.Location);
            _I地图.删除多边形(_圈选图形索引);
            _圈选图形索引 = _I地图.添加多边形(new List<M经纬度>
                    {
                        __起点,
                        __起点.偏移(__终点.经度 - __起点.经度, 0),
                        __终点,
                        __终点.偏移(__起点.经度 - __终点.经度, 0),
                    },
            new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(255, 0, 0, 255), 填充颜色 = Color.FromArgb(55, 135, 206, 235) });
        }

        private void 绘制圆形(MouseEventArgs e)
        {
            var __起点 = _I地图.屏幕坐标转经纬度(_鼠标点击位置列表[0]);
            var __终点 = _I地图.屏幕坐标转经纬度(e.Location);
            _I地图.删除圆(_圈选图形索引);
            var __圆心 = __起点;
            var __半径 = H地图算法.测量两点间间距(__圆心, __终点);
            _圈选图形索引 = _I地图.添加圆(
                __圆心,
                __半径,
                new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(255, 0, 0, 255), 填充颜色 = Color.FromArgb(55, 135, 206, 235) });
        }

        private void 绘制多边形(MouseEventArgs e)
        {
            if (_鼠标点击位置列表.Count == 0)
            {
                return;
            }
            _I地图.删除线(_圈选图形索引);
            var __顶点列表 = _鼠标点击位置列表.Select(q => _I地图.屏幕坐标转经纬度(q)).ToList();
            __顶点列表.Add(_I地图.屏幕坐标转经纬度(e.Location));
            _圈选图形索引 = _I地图.添加线(__顶点列表, 1, Color.FromArgb(255, 0, 0, 255));
        }

        void out地图_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.Visible || e.Button != MouseButtons.Right || 当前方式 == E圈选方式.无)
            {
                return;
            }
            //Debug.WriteLine("鼠标释放位置: " + e.Location);
            if (当前方式 != E圈选方式.多边形)
            {
                _鼠标点击位置列表.Add(e.Location);
                _绘制中 = false;
            }
        }

        void out地图_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible || e.Button != MouseButtons.Right || 当前方式 != E圈选方式.多边形)
            {
                return;
            }
            if (_鼠标点击位置列表.Count < 4)
            {
                _鼠标点击位置列表.Clear();
                return;
            }
            System.Diagnostics.Debug.WriteLine("out地图_MouseDoubleClick Clicks:" + e.Clicks);
            _I地图.删除线(_圈选图形索引);
            var __temp = new List<Point>(_鼠标点击位置列表);
            __temp.Add(__temp[0]);
            var __顶点列表 = __temp.Select(q => _I地图.屏幕坐标转经纬度(q)).ToList();
            _圈选图形索引 = _I地图.添加线(__顶点列表, 1, Color.FromArgb(255, 0, 0, 255));
            _绘制中 = false;
        }

    }
}
