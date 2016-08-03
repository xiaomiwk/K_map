using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_示例
{
    public partial class F选择地图 : Form
    {
        private IF地图 _IF地图;

        public F选择地图(IF地图 __IF地图)
        {
            _IF地图 = __IF地图;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in服务器地图_类型.DataSource = Enum.GetNames(typeof(E地图源)).ToList().Where(q => q != E地图源.无.ToString()).ToArray();
            this.in服务器地图_类型.SelectedItem = E地图源.谷歌2D图.ToString();
            this.in服务器地图_最小层级.DataSource = new int[] { 6, 7, 8, 9, 10, 11, 12,13,14,15,16 };
            this.in服务器地图_最小层级.SelectedItem = 9;
            this.in服务器地图_最大层级.DataSource = new int[] { 14, 15, 16, 17, 18,19 };
            this.in服务器地图_最大层级.SelectedItem = 16;

            var __所有省 = H行政区位置.所有.Select(q => q.省.Trim()).Distinct().ToList();
            __所有省 = __所有省.Distinct().ToList();
            this.in服务器地图_省.DataSource = __所有省;

            this.in服务器地图_省.SelectedIndexChanged += in省_SelectedIndexChanged;
            this.in服务器地图_省.SelectedIndex = __所有省.FindIndex(q => q == "江苏省");
            this.in服务器地图_市.SelectedItem = "南京市";

            this.do本机地图.Click += do本机地图_Click;
            this.do服务器地图.Click += do服务器地图_Click;
            this.do空白地图.Click += do空白地图_Click;
            this.do关闭.Click += do关闭_Click;
        }

        void do关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void do空白地图_Click(object sender, EventArgs e)
        {
            _IF地图.加载地图("");
            _IF地图.初始化地图参数(E地图源.无, new M经纬度(118.79, 31.82), 8, 18);
            this.Close();
        }

        void do服务器地图_Click(object sender, EventArgs e)
        {
            M行政区位置 __行政区;
            var __省名称 = (string)this.in服务器地图_省.SelectedValue;
            var __市名称 = (string)this.in服务器地图_市.SelectedValue;
            if (string.IsNullOrEmpty(__市名称))
            {
                __行政区 = H行政区位置.所有.Find(q => q.省 == __省名称 && (q.市 == "" || q.省 == q.市));
            }
            else
            {
                __行政区 = H行政区位置.所有.Find(q => q.省 == __省名称 && q.市 == __市名称);
            }
            _IF地图.加载地图(this.in服务器地图_地址.Text.Trim());

            //方案一
            _IF地图.初始化地图参数(
                (E地图源)Enum.Parse(typeof(E地图源), (string)this.in服务器地图_类型.SelectedValue),
                new M经纬度(__行政区.经度, __行政区.纬度),
                (int)this.in服务器地图_最小层级.SelectedValue,
                (int)this.in服务器地图_最大层级.SelectedValue);

            //方案二
            //_IF地图.当前地图源 = (E地图源)Enum.Parse(typeof(E地图源), (string)this.in服务器地图_类型.SelectedValue);
            //_IF地图.定位(new M经纬度(__行政区.经度, __行政区.纬度));
            //_IF地图.设置层级范围((int)this.in服务器地图_最小层级.SelectedValue, (int)this.in服务器地图_最大层级.SelectedValue);
            //_IF地图.当前层级 = (_IF地图.最小层级 + _IF地图.最大层级) / 2;
            this.Close();
        }

        void do本机地图_Click(object sender, EventArgs e)
        {
            var __对话框 = new OpenFileDialog() { Multiselect = false, Title = "请选择地图文件('城市'_'地图源'_'最小层级'-'最大层级'.gmdb)", Filter = "地图文件(*.gmdb)|*.gmdb" };
            if (__对话框.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            _IF地图.加载地图(__对话框.FileName);
            this.Close();
        }

        void in省_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省名称 = (string)this.in服务器地图_省.SelectedValue;
            var __省 = H行政区位置.所有.Find(q => q.省 == __省名称 && (q.市 == "" || q.省 == q.市));
            var __省内市 = H行政区位置.所有.Where(q => q.省 == __省名称).Select(q => q.市).Distinct();
            this.in服务器地图_市.DataSource = __省内市.ToList();
        }

    }
}
