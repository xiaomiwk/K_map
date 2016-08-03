using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 下载网管地图
{
    public partial class F主界面 : Form
    {
        private B下载百度地图 __电子地图下载;
        private B下载百度地图 __卫星地图下载;
        private B下载百度地图 __道路地图下载;

        public F主界面()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in电子地图.Text = System.Configuration.ConfigurationManager.AppSettings["百度电子地图"];
            this.in卫星地图.Text = System.Configuration.ConfigurationManager.AppSettings["百度卫星地图"];
            this.in道路地图.Text = System.Configuration.ConfigurationManager.AppSettings["百度道路地图"];
            this.in电子地图_选择.Checked = true;
            this.in层级_开始.Text = "6";
            this.in层级_结束.Text = "15";
            this.do开始下载.Click += do下载_Click;
            this.do结束下载.Click += do结束下载_Click;
            初始化();

            var __所有省 = H行政区位置.所有.Select(q => q.省.Trim()).Distinct().ToList();
            __所有省 = __所有省.Distinct().ToList();
            this.in省.DataSource = __所有省;

            this.in省.SelectedIndexChanged += in省_SelectedIndexChanged;

            this.in省.SelectedIndex = __所有省.FindIndex(q => q == "江苏省");

        }

        private void 初始化()
        {
            this.out电子地图下载进度.Text = "0%";
            this.out卫星地图下载进度.Text = "0%";
            this.out道路地图下载进度.Text = "0%";
            this.do开始下载.Enabled = true;
            this.do结束下载.Enabled = false;
        }

        void do结束下载_Click(object sender, EventArgs e)
        {
            if (__电子地图下载 != null)
            {
                __电子地图下载.停止异步下载();
                __电子地图下载 = null;
            }
            if (__卫星地图下载 != null)
            {
                __卫星地图下载.停止异步下载();
                __卫星地图下载 = null;
            }
            if (__道路地图下载 != null)
            {
                __道路地图下载.停止异步下载();
                __道路地图下载 = null;
            }
            初始化();

        }

        void do下载_Click(object sender, EventArgs e)
        {
            var __省名称 = (string)this.in省.SelectedValue;
            var __市名称 = (string)this.in市.SelectedValue;
            var __目标区域 = string.IsNullOrEmpty(__市名称) ? H行政区位置.所有.Find(q => q.省 == __省名称) : H行政区位置.所有.Find(q => q.省 == __省名称 && q.市 == __市名称);

            int __最小级别 = int.Parse(this.in层级_开始.Text.Trim());
            int __最大级别 = int.Parse(this.in层级_结束.Text.Trim());
            double __左上经度 = __目标区域.边界坐标.Max(q => q.Min(k => k.Lng));
            double __左上纬度 = __目标区域.边界坐标.Max(q => q.Max(k => k.Lat));
            double __右下经度 = __目标区域.边界坐标.Max(q => q.Max(k => k.Lng));
            double __右下纬度 = __目标区域.边界坐标.Max(q => q.Min(k => k.Lat));
            String __路径 = Environment.CurrentDirectory;

            if (this.in电子地图_选择.Checked)
            {
                __电子地图下载 = new B下载百度地图(this.in电子地图.Text);
                __电子地图下载.下载进度变化 += __进度 => 下载进度变化(this.out电子地图下载进度, __进度);
                __电子地图下载.下载完毕 += __成功率 => 下载完毕(this.out电子地图下载进度, __成功率);
                __电子地图下载.异步下载(__最小级别, __最大级别, __左上经度, __右下经度, __右下纬度, __左上纬度, Path.Combine(__路径, "百度电子地图"));
            }
            if (this.in卫星地图_选择.Checked)
            {
                __卫星地图下载 = new B下载百度地图(this.in卫星地图.Text);
                __卫星地图下载.下载进度变化 += __进度 => 下载进度变化(this.out卫星地图下载进度, __进度);
                __卫星地图下载.下载完毕 += __成功率 => 下载完毕(this.out卫星地图下载进度, __成功率);
                __卫星地图下载.异步下载(__最小级别, __最大级别, __左上经度, __右下经度, __右下纬度, __左上纬度, Path.Combine(__路径, "百度卫星地图"));
            }
            if (this.in道路地图_选择.Checked)
            {
                __道路地图下载 = new B下载百度地图(this.in道路地图.Text);
                __道路地图下载.下载进度变化 += __进度 => 下载进度变化(this.out道路地图下载进度, __进度);
                __道路地图下载.下载完毕 += __成功率 => 下载完毕(this.out道路地图下载进度, __成功率);
                __道路地图下载.异步下载(__最小级别, __最大级别, __左上经度, __右下经度, __右下纬度, __左上纬度, Path.Combine(__路径, "百度道路地图"));
            }

            this.do开始下载.Enabled = false;
            this.do结束下载.Enabled = true;

        }

        void 下载完毕(Label __标签, int __成功率)
        {
            this.Invoke(new Action(() =>
            {
                this.do开始下载.Text = "下载";
                __标签.Text = "下载完成! 成功率:" + (100 - __成功率) + "%";
            }));

        }

        void 下载进度变化(Label __标签, int __进度)
        {
            this.Invoke(new Action(() => { __标签.Text = __进度 + "%"; }));

        }

        void in省_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省名称 = (string)this.in省.SelectedValue;
            var __省 = H行政区位置.所有.Find(q => q.省 == __省名称 && (q.市 == "" || q.省 == q.市));
            var __省内市 = H行政区位置.所有.Where(q => q.省 == __省名称).Select(q => q.市).Distinct();
            this.in市.DataSource = __省内市.ToList();
        }


    }
}
