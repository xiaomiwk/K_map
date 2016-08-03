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
    public partial class F地址查询 : UserControl
    {
        private HtmlDocument _HtmlDocument;

        private string[] _顺序 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public F地址查询()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out结果.Clear();
            this.in关键词.Text = "明故宫";
            this.out返回页数.Text = string.Empty;
            this.out浏览器.ScriptErrorsSuppressed = true;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "F地址查询.html"));

            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;
            this.do查询.Click += do查询_Click;
        }

        void do查询_Click(object sender, EventArgs e)
        {
            this.out结果.Clear();
            var __关键词 = this.in关键词.Text.Trim();
            if (string.IsNullOrEmpty(__关键词))
            {
                _HtmlDocument.InvokeScript("清除所有标记");
            }
            else
            {
                _HtmlDocument.InvokeScript("查询", new object[] { __关键词 });
            }
        }

        void out浏览器_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _HtmlDocument = this.out浏览器.Document;
            _HtmlDocument.InvokeScript("初始化地图", new object[] { "南京" });
            查询HTML元素("do触发事件").AttachEventHandler("onclick", 处理WEB请求);
            out浏览器_Resize(null, null);
            this.out浏览器.Resize += out浏览器_Resize;

        }

        void out浏览器_Resize(object sender, EventArgs e)
        {
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
            if (__事件名称 == "返回页数")
            {
                this.out返回页数.Text = string.Format("共{0}页，当前仅显示一页", __事件参数);
            }
            if (__事件名称 == "返回第一页")
            {
                var __json序列化 = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
                var __结果 = __json序列化.Deserialize<List<M相关位置>>(__事件参数);    //将json数据转化为对象类型并赋值给list
                var __索引 = 0;
                __结果.ForEach(q =>
                    {
                        this.out结果.AppendText(string.Format("{0} {1}{2}{2}", _顺序[__索引++], q.ToString(), Environment.NewLine));
                        //this.out结果.AppendText(q.ToString() + Environment.NewLine + Environment.NewLine);
                    });
            }
            if (__事件名称 == "查询失败")
            {
                this.out结果.AppendText("查询失败");
            }
        }

        private struct M相关位置
        {
            public string Title { get; set; }
            public string Address { get; set; }
            public override string ToString()
            {
                return string.Format("{0}{2}地址：{1}", Title, Address, Environment.NewLine);
            }
        }
    }
}
