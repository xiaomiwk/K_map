using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Demo
{
    public partial class F区域操作 : UserControl
    {
        private HtmlDocument _HtmlDocument;

        private List<object> _区域列表 = new List<object>();

        private string[] _区域选择方法 = new string[]
            {
                "不可用",
                "长方形，点击：起点（左上点） - 终点（右下点）",
                "圆形，点击：起点（圆心） - 终点（半径另一端）",
                "圆形，点击：点（圆心），半径1公里",
            };

        private double _初始经度 = 120.14331;

        private double _初始纬度 = 30.30581;

        public F区域操作()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out结果.Clear();
            this.in区域选择方法.Items.Clear();
            this.in区域选择方法.Items.AddRange(_区域选择方法);
            this.in区域选择方法.SelectedIndex = 0;

            this.out浏览器.ScriptErrorsSuppressed = true;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "F区域操作.html"));

            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;

            this.do查询区域内手机.Click += do查询区域内手机_Click;
            this.do呼叫区域内手机.Click += do呼叫区域内手机_Click;
            this.do删除上一个区域.Click += do删除上一个区域_Click;
            this.do删除所有区域.Click += do删除所有区域_Click;
            this.in区域选择方法.SelectedIndexChanged += in区域选择方法_SelectedIndexChanged;
        }

        void in区域选择方法_SelectedIndexChanged(object sender, EventArgs e)
        {
            _HtmlDocument.InvokeScript("设置区域选择方法", new object[] { in区域选择方法.SelectedItem.ToString() });
        }

        void do删除所有区域_Click(object sender, EventArgs e)
        {
            if (_区域列表.Count > 0)
            {
                _HtmlDocument.InvokeScript("删除所有区域");
                _区域列表.Clear();
                this.out结果.AppendText("删除所有区域");
            }
        }

        void do删除上一个区域_Click(object sender, EventArgs e)
        {
            if (_区域列表.Count > 0)
            {
                _HtmlDocument.InvokeScript("删除上一个区域");
                _区域列表.RemoveAt(_区域列表.Count - 1);
                this.out结果.AppendText("删除上一个区域" + Environment.NewLine);
            }
        }

        void do呼叫区域内手机_Click(object sender, EventArgs e)
        {
            this.out结果.AppendText("XXX申请讲话" + Environment.NewLine);
            this.out结果.AppendText("XXX开始讲话" + Environment.NewLine);
            this.out结果.AppendText("XXX结束讲话" + Environment.NewLine);
        }

        void do查询区域内手机_Click(object sender, EventArgs e)
        {
            this.out结果.AppendText("XXX在区域内" + Environment.NewLine);
            this.out结果.AppendText("YYY在区域内" + Environment.NewLine);
            this.out结果.AppendText("ZZZ在区域内" + Environment.NewLine);
        }

        void out浏览器_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _HtmlDocument = this.out浏览器.Document;
            //_HtmlDocument.InvokeScript("初始化地图", new object[] { "南京" });
            _HtmlDocument.InvokeScript("初始化地图", new object[] { _初始经度, _初始纬度 });
            查询HTML元素("do触发事件").AttachEventHandler("onclick", 处理WEB请求);
            out浏览器_Resize(null, null);
            this.out浏览器.Resize += out浏览器_Resize;

        }

        void out浏览器_Resize(object sender, EventArgs e)
        {
            // 程序处于最小化状态
            if (this.out浏览器.Width < 100)
            {
                return;
            }
            _HtmlDocument.InvokeScript("设置地图大小", new object[] { (this.out浏览器.Width - 25) + "px", (this.out浏览器.Height - 10) + "px" });
        }

        private HtmlElement 查询HTML元素(string __ID)
        {
            return _HtmlDocument.GetElementById(__ID);
        }

        private void 处理WEB请求(object sender, EventArgs e)
        {
            var __事件名称 = 查询HTML元素("do触发事件").GetAttribute("value");
            var __事件参数 = 查询HTML元素("in事件参数").GetAttribute("value");
            //MessageBox.Show(string.Format("处理WEB请求，事件名称：{0}, 事件参数：{1}", __事件名称, __事件参数));

            var __json序列化 = new JavaScriptSerializer();   //实例化一个能够序列化数据的类

            if (__事件名称 == "选择长方形区域")
            {
                var __结果 = __json序列化.Deserialize<M长方形区域>(__事件参数);    //将json数据转化为对象类型并赋值给list
                _区域列表.Add(__结果);
                var __长 = GetDistance(__结果.左上角.经度, __结果.左上角.纬度, __结果.右下角.经度, __结果.右下角.纬度);
                var __宽 = GetDistance(__结果.右下角.经度, __结果.左上角.纬度, __结果.右下角.经度, __结果.右下角.纬度);
                this.out结果.AppendText(string.Format("选择长方形区域，长：{0}米，宽：{1}米{2}", Math.Floor(__长), Math.Floor(__宽), Environment.NewLine));
            }
            if (__事件名称 == "选择圆形区域")
            {
                var __结果 = __json序列化.Deserialize<M圆形区域>(__事件参数);    //将json数据转化为对象类型并赋值给list
                _区域列表.Add(__结果);
                this.out结果.AppendText(string.Format("选择圆形区域，半径：{0}米{1}", __结果.半径, Environment.NewLine));
            }
        }

        /// 两点距离
        /// </summary>
        /// <param name="lng1">经度1</param>
        /// <param name="lat1">纬度1</param>
        /// <param name="lng2">经度2</param>
        /// <param name="lat2">纬度2</param>
        /// <returns>距离:米</returns>
        /// <Author>lc</Author>
        /// <FinishT>2009-12-30</FinishT>
        public double GetDistance(double lng1, double lat1, double lng2, double lat2)
        {
            double latRadians1 = lat1 * (Math.PI / 180);
            double latRadians2 = lat2 * (Math.PI / 180);
            double latRadians = latRadians1 - latRadians2;
            double lngRadians = lng1 * (Math.PI / 180) - lng2 * (Math.PI / 180);
            double f = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(latRadians / 2), 2) + Math.Cos(latRadians1) * Math.Cos(latRadians2) * Math.Pow(Math.Sin(lngRadians / 2), 2)));
            return f * 6378137;
        }

        private struct M点
        {
            public float 经度 { get; set; }

            public float 纬度 { get; set; }
        }

        private struct M长方形区域
        {
            public M点 左上角 { get; set; }

            public M点 右下角 { get; set; }
        }

        private struct M圆形区域
        {
            public M点 圆心 { get; set; }

            public float 半径 { get; set; }
        }


    }
}
