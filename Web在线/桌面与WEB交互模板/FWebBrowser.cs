using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Demo
{
    public partial class FWebBrowser : Form
    {
        private HtmlDocument _HtmlDocument;

        public FWebBrowser()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.in传入参数.Text = "桌面输入";
            this.do执行客户端动作.Click += do发起_Click;
            this.do传入JSON.Click += do传入JSON_Click;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "FWebBrowser.html"));
            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;
        }

        void do传入JSON_Click(object sender, EventArgs e)
        {
            var __o1 = new MyStruct { 城市 = "北京", 区号 = 010 };
            var __o2 = new MyStruct { 城市 = "上海", 区号 = 021 };
            var __json序列化 = new JavaScriptSerializer();
            var __json字符串 = __json序列化.Serialize(new List<MyStruct> { __o1, __o2 });
            MessageBox.Show("传入字符串： " + __json字符串);
            //var jsonStr =
            //    "[{ \"城市\": \"北京\",\"区号\": 010},{ \"城市\": \"上海\", \"区号\": 021}]";
            //do解析JSON(__json字符串);
            _HtmlDocument.InvokeScript("处理JSON数据", new object[] { __json字符串 });   
        }

        public void do解析JSON(string jsonStr)
        {
            var __json序列化 = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            var __结果 = __json序列化.Deserialize<List<MyStruct>>(jsonStr);    //将json数据转化为对象类型并赋值给list
            MessageBox.Show(__结果[0].城市);
        }

        struct MyStruct
        {
            public string 城市 { get; set; }
            public int 区号 { get; set; }
        }

        void out浏览器_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _HtmlDocument = this.out浏览器.Document;
            查询HTML元素("do触发事件").AttachEventHandler("onclick", 处理WEB请求);
        }

        private void 处理WEB请求(object sender, EventArgs e)
        {
            var __事件名称 = 查询HTML元素("do触发事件").GetAttribute("value");
            var __事件参数 = 查询HTML元素("in事件参数").GetAttribute("value");
            MessageBox.Show(string.Format("处理WEB请求，事件名称：{0}, 事件参数：{1}", __事件名称, __事件参数));
        }

        void do发起_Click(object sender, EventArgs e)
        {
            //触发HTML元素事件
            //查询HTML元素("in输入").SetAttribute("value", this.in文本.Text);
            //查询HTML元素("do动作").InvokeMember("click");

            //触发脚本
            _HtmlDocument.InvokeScript("桌面发起", new object[] { this.in传入参数.Text });
        }

        private HtmlElement 查询HTML元素(string __ID)
        {
            return _HtmlDocument.GetElementById(__ID);
        }
    }
}
