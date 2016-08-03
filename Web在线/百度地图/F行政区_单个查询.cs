using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class F行政区_单个查询 : Form
    {
        public F行政区_单个查询()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out多个边界.Visible = false;
            this.do查询.Click += do查询_Click;
            this.do复制边界坐标.Click += do复制边界坐标_Click;
            this.do复制经纬度.Click += do复制经纬度_Click;
        }

        void do查询_Click(object sender, EventArgs e)
        {
            var __参数 = this.in行政区.Text.Trim();
            this.in经纬度.Text = "";
            this.in边界坐标.Text = "";
            this.out多个边界.Visible = false;
            On提交("导出边界", new object[] { __参数 });
            On提交("查询位置", new object[] { __参数 });
        }

        void do复制经纬度_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.in经纬度.Text.Trim());
        }

        void do复制边界坐标_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.in边界坐标.Text.Trim());
        }

        public event Action<string, object[]> 提交;

        protected virtual void On提交(string arg1, object[] arg2)
        {
            Action<string, object[]> handler = 提交;
            if (handler != null) handler(arg1, arg2);
        }

        public void 处理响应(string __事件名称, string __事件参数)
        {
            if (__事件名称 == "导出边界")
            {
                var __边界坐标 = __事件参数.Split(':')[1];
                this.in边界坐标.Text = __边界坐标.Replace(" ", "");
                if (__边界坐标.Contains("||"))
                {
                    this.out多个边界.Visible = true;
                }
            }
            if (__事件名称 == "查询位置")
            {
                var __位置参数 = __事件参数.Split(':')[1];
                this.in经纬度.Text = __位置参数;
            }
        }
    }
}
