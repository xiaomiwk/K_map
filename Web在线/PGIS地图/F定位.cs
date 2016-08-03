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
    public partial class F定位 : UserControl
    {
        private HtmlDocument _HtmlDocument;

        private readonly Dictionary<int, M标记> _标记缓存 = new Dictionary<int, M标记>();

        private double _初始经度 = 120.14331;

        private double _初始纬度 = 30.30581;

        public F定位()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in显示模式.Items.Clear();
            this.in显示模式.Items.AddRange(new object[] { "手动", "概览" });
            this.in显示模式.SelectedIndex = 0;
            this.in显示模式.SelectedIndexChanged += in显示模式_SelectedIndexChanged;

            this.do清除所有.Click += do清除所有_Click;
            this.out浏览器.ScriptErrorsSuppressed = true;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "F定位.html"));

            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;
        }

        void in显示模式_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __显示模式 = (string)this.in显示模式.SelectedItem;
            _HtmlDocument.InvokeScript("设置显示模式", new object[] { __显示模式 });
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
            MessageBox.Show(string.Format("处理WEB请求，事件名称：{0}, 事件参数：{1}", __事件名称, __事件参数));
            if (__事件名称 == "删除标记")
            {
                var __Id = int.Parse(__事件参数);
                删除标记(__Id);
                _标记缓存.Remove(__Id);
            }
        }

        public void 处理定位(M号码 __号码)
        {
            if (_标记缓存.ContainsKey(__号码.Id))
            {
                删除标记(__号码.Id);
                _标记缓存.Remove(__号码.Id);
            }
            else
            {
                _标记缓存[__号码.Id] = 添加标记(__号码);
            }
        }

        private M标记 添加标记(M号码 __号码)
        {
            var __随机数 = new Random();
            var __随机数1 = __随机数.NextDouble() * 0.01;
            var __随机数2 = __随机数.NextDouble() * 0.01;

            var __标记 = new M标记
            {
                Id = __号码.Id,
                名称 = __号码.名称,
                号码 = __号码.号码,
                描述 = __号码.描述,
                经度 = _初始经度 + __随机数1,
                纬度 = _初始纬度 + __随机数2,
                打开描述 = false,
            };
            var __序列化器 = new JavaScriptSerializer();
            var __字符串 = __序列化器.Serialize(__标记);
            this.Invoke(new Action(() =>
            {
                _HtmlDocument.InvokeScript("添加标记", new object[] { __字符串 });
            }));
            return __标记;
        }

        private void 删除标记(int __Id)
        {
            this.Invoke(new Action(() =>
            {
                _HtmlDocument.InvokeScript("删除标记", new object[] { __Id, true });
            }));
        }

        void do清除所有_Click(object sender, EventArgs e)
        {
            _HtmlDocument.InvokeScript("清除所有标记");
            _标记缓存.Clear();
        }
    }
}
