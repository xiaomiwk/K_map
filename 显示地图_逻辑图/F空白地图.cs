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
    public partial class F空白地图 : Form
    {
        private IF地图 _I地图;

        private readonly List<UInt64> _点索引 = new List<UInt64>();

        private readonly List<UInt64> _线索引 = new List<UInt64>();

        private readonly List<UInt64> _多边形索引 = new List<UInt64>();

        private M经纬度 __中心 = new M经纬度(118.818035, 32.027785); //南京: 经度="118.818035" 纬度="32.027785"

        private F提示 __提示框;

        public F空白地图()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _I地图 = this.out地图;
            //_I地图.加载地图("", E地图源.无, __中心, 8, 18);
            _I地图.加载地图("");
            _I地图.初始化地图参数(E地图源.无, __中心, 8, 18);

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
            _I地图.定位(__中心);
        }

        void do删除覆盖物_Click(object sender, EventArgs e)
        {
            _点索引.ForEach(q => _I地图.删除点(q));
            _线索引.ForEach(q => _I地图.删除线(q));
            _多边形索引.ForEach(q => _I地图.删除多边形(q));
        }

        void do添加覆盖物_Click(object sender, EventArgs e)
        {
            _点索引.Add(_I地图.添加点(__中心.偏移(-0.05, 0), 创建图标("基站", "正常"), "基站1", new M示例业务对象 { 标识 = 1, 类型 = "基站", 名称 = "基站1", 状态 = "正常" }));
            _点索引.Add(_I地图.添加点(__中心.偏移(0.05, 0), 创建图标("车台", "正常"), "车台1", new M示例业务对象 { 标识 = 2, 类型 = "车台", 名称 = "车台1", 状态 = "正常" }));
            _线索引.Add(_I地图.添加线(new List<M经纬度> { __中心.偏移(-0.05, 0), __中心.偏移(0.05, 0) }, 1, Color.Red, new M示例业务对象 { 标识 = 2, 类型 = "连接状态", 名称 = "基站1-车台1", 状态 = "正常" }));
            _多边形索引.Add(_I地图.添加多边形(new List<M经纬度> { __中心.偏移(-0.02, 0), __中心.偏移(0.02, 0), __中心.偏移(0.02, 0.02), __中心.偏移(-0.02, 0.02) }, new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.Red, 填充颜色 = Color.Yellow }, new M示例业务对象 { 标识 = 2, 类型 = "区域", 名称 = "区域1", 状态 = "正常" }));
        }

        private Bitmap 创建图标(string __类型, string __样式)
        {
            var __图片 = H图标.获取图标(E常用图标.默认图标_橙色);
            //return __图片;
            return H合成图片.添加左侧柱状图(__图片, 5, new List<int> { 10, 5, 15 }, new List<Color> { Color.Green, Color.Red, Color.Indigo });
        }

    }
}