using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_逻辑图
{
    public partial class F逻辑图 : Form
    {
        private IF拓扑图 _I地图;

        private readonly List<UInt64> _点索引 = new List<UInt64>();

        private readonly List<UInt64> _线索引 = new List<UInt64>();

        private readonly List<UInt64> _多边形索引 = new List<UInt64>();

        private F提示 __提示框;

        private readonly Point _中心坐标 = new Point(400, 300);

        public F逻辑图()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _I地图 = this.out地图;
            _I地图.初始化(_中心坐标, 5, Color.White);

            _I地图.单击点 += _I地图_单击对象;
            _I地图.进入点 += _I地图_进入对象;
            _I地图.离开点 += _I地图_离开对象;
            _I地图.单击线 += _I地图_单击对象;
            _I地图.进入线 += _I地图_进入对象;
            _I地图.离开线 += _I地图_离开对象;
            _I地图.单击多边形 += _I地图_单击对象;
            _I地图.进入多边形 += _I地图_进入对象;
            _I地图.离开多边形 += _I地图_离开对象;

            this.do删除覆盖物.Click += do删除覆盖物_Click;
            this.do添加覆盖物.Click += do添加覆盖物_Click;
            this.do定位点.Click += do定位点_Click;

            this.do添加覆盖物.PerformClick();
        }

        void _I地图_单击对象(object tag, MouseEventArgs e)
        {
            关闭提示框();
            MessageBox.Show(tag.ToString(), "信息");
        }

        void _I地图_离开对象(object obj)
        {
            关闭提示框();
        }

        void 关闭提示框()
        {
            if (__提示框 != null)
            {
                __提示框.Close();
                __提示框 = null;
            }
        }

        void _I地图_进入对象(object obj)
        {
            if (__提示框 == null)
            {
                __提示框 = new F提示()
                {
                    TopMost = true,
                    StartPosition = FormStartPosition.Manual,
                    Location = MousePosition,
                    ShowIcon = false,
                    ShowInTaskbar = false,
                    FormBorderStyle = FormBorderStyle.None,
                };
                __提示框.Show();
            }
        }

        void do定位点_Click(object sender, EventArgs e)
        {
            _I地图.定位(_中心坐标);
        }

        void do删除覆盖物_Click(object sender, EventArgs e)
        {
            _点索引.ForEach(_I地图.删除点);
            _线索引.ForEach(_I地图.删除线);
            _多边形索引.ForEach(_I地图.删除多边形);
        }

        void do添加覆盖物_Click(object sender, EventArgs e)
        {
            _点索引.Add(_I地图.添加点(_中心坐标, 创建图标("基站", "正常"), "基站1", new M示例业务对象 { 标识 = 1, 类型 = "基站", 名称 = "基站1", 状态 = "正常" }));
            _点索引.Add(_I地图.添加点(new Point(500, 400), 创建图标("车台", "正常"), "车台1", new M示例业务对象 { 标识 = 2, 类型 = "车台", 名称 = "车台1", 状态 = "正常" }));
            _线索引.Add(_I地图.添加线(new List<Point> { _中心坐标, new Point(500, 400) }, 1, Color.Red, new M示例业务对象 { 标识 = 2, 类型 = "连接线", 名称 = "线1", 状态 = "正常" }));
            _多边形索引.Add(_I地图.添加多边形(new List<Point> { new Point(100, 100), new Point(100, 200), new Point(200, 200), new Point(200, 100) }, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.Red, 填充颜色 = Color.Yellow }, new M示例业务对象 { 标识 = 2, 类型 = "区域", 名称 = "区域1", 状态 = "正常" }));
        }

        private Bitmap 创建图标(string __类型, string __样式)
        {
            //var __路径 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), string.Format("images\\{0}-{1}.png", __类型, __样式));
            //var __图片 = new Bitmap(__路径);
            var __图片 = 显示地图.H图标.获取图标(E常用图标.默认图标_蓝色);
            //return __图片;
            return H合成图片.添加左侧柱状图(__图片, 5, new List<int> { 10, 5, 15 }, new List<Color> { Color.Green, Color.Red, Color.Indigo });
        }


    }
}