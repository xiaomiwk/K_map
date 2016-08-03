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
    public partial class F跟踪 : UserControl
    {
        private HtmlDocument _HtmlDocument;

        private readonly Dictionary<int, M标记> _标记缓存 = new Dictionary<int, M标记>();

        private readonly object _标记缓存锁 = new object();

        private readonly Dictionary<int, DateTime> _跟踪开始时间 = new Dictionary<int, DateTime>();

        private readonly Dictionary<int, string> _跟踪状态 = new Dictionary<int, string>();

        private const int _即将离线间隔 = 6; //秒

        private const int _离线间隔 = 18; //秒

        public F跟踪()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in显示模式.Items.Clear();
            this.in显示模式.Items.AddRange(new object[] { "手动", "以个体为中心", "概览" });
            this.in显示模式.SelectedIndex = 0;
            this.in显示模式.SelectedIndexChanged += in显示模式_SelectedIndexChanged;
            this.do设置中心号码.Click += do设置中心号码_Click;
            this.out以个体为中心.Visible = false;

            this.do清除所有.Click += do清除所有_Click;
            this.out浏览器.ScriptErrorsSuppressed = true;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "F跟踪.html"));

            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;

            this.out用户列表.MouseDoubleClick += out用户列表_MouseDoubleClick;
        }

        void out用户列表_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var __Id = this.out用户列表.SelectedIndex;
            if (__Id < 0)
            {
                return;
            }

            var __姓名 = this.out用户列表.SelectedItem.ToString();
            var __号码 = string.Format("1000{0}", this.out用户列表.SelectedIndex);
            this.处理跟踪(new M号码 { Id = __Id, 名称 = __姓名, 号码 = __号码, 描述 = "此处省略100字" });
        }

        void do设置中心号码_Click(object sender, EventArgs e)
        {
            _HtmlDocument.InvokeScript("设置中心序号", new object[] { this.in中心号码.Text.Trim() });
        }

        void in显示模式_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __显示模式 = (string)this.in显示模式.SelectedItem;
            _HtmlDocument.InvokeScript("设置显示模式", new object[] { __显示模式 });
            this.out以个体为中心.Visible = __显示模式 == "以个体为中心";
        }

        void out浏览器_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _HtmlDocument = this.out浏览器.Document;
            _HtmlDocument.InvokeScript("初始化地图", new object[] { "南京" });
            查询HTML元素("do触发事件").AttachEventHandler("onclick", 处理WEB请求);
            out浏览器_Resize(null, null);
            this.out浏览器.Resize += out浏览器_Resize;

            new Task(检测跟踪状态).Start();
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
            MessageBox.Show(string.Format("处理WEB请求，事件名称：{0}, 事件参数：{1}", __事件名称, __事件参数));
            if (__事件名称 == "删除标记")
            {
                var __Id = int.Parse(__事件参数);
                删除标记(__Id);
                lock (_标记缓存锁)
                {
                    _标记缓存.Remove(__Id);
                    _跟踪开始时间.Remove(__Id);

                }
            }
        }

        public void 处理跟踪(M号码 __号码)
        {
            lock (_标记缓存锁)
            {
                if (_标记缓存.ContainsKey(__号码.Id))
                {
                    删除标记(__号码.Id);
                    _标记缓存.Remove(__号码.Id);
                    _跟踪开始时间.Remove(__号码.Id);
                    if (_跟踪状态.ContainsKey(__号码.Id))
                    {
                        _跟踪状态.Remove(__号码.Id);
                    }
                }
                else
                {
                    _标记缓存[__号码.Id] = new M标记();
                    _跟踪开始时间[__号码.Id] = DateTime.Now;
                    new Task(模拟数据, new Tuple<M号码, DateTime>(__号码, _跟踪开始时间[__号码.Id])).Start();
                }
            }
        }

        private void 模拟数据(object __参数)
        {
            var __格式 = __参数 as Tuple<M号码, DateTime>;
            var __号码 = __格式.Item1;
            var __时间 = __格式.Item2;
            bool __第一次 = true;
            var __随机数 = new Random();
            var __起始经度 = 118.829829 + __随机数.NextDouble() * 0.1;
            var __起始纬度 = 32.031709 + __随机数.NextDouble() * 0.1;
            var __次数 = 1;

            while (_标记缓存.ContainsKey(__号码.Id) && _跟踪开始时间.ContainsKey(__号码.Id) && _跟踪开始时间[__号码.Id] == __时间)
            {
                if (!__第一次)
                {
                    删除标记(__号码.Id);
                }
                else
                {
                    __第一次 = false;
                }
                var __随机数1 = __随机数.NextDouble() * 0.001;
                var __随机数2 = __随机数.NextDouble() * 0.001;
                __起始经度 += __随机数1;
                __起始纬度 += __随机数2;
                var __标记 = new M标记
                {
                    Id = __号码.Id,
                    名称 = __号码.名称,
                    号码 = __号码.号码,
                    描述 = __号码.描述,
                    经度 = __起始经度,
                    纬度 = __起始纬度,
                    打开描述 = false,
                    误差半径 = 20,
                    方向 = 30 * __次数++ % 360,
                    时间 = DateTime.Now.ToString(),
                };
                lock (_标记缓存锁)
                {
                    _标记缓存[__号码.Id] = 添加标记(__标记);
                }
                System.Threading.Thread.Sleep(__随机数.Next(3, 30) * 1000);
            }

        }

        private M标记 添加标记(M标记 __标记)
        {
            var __序列化器 = new JavaScriptSerializer();
            var __字符串 = __序列化器.Serialize(__标记);
            try
            {
                this.Invoke(new Action(() =>
                    {
                        _HtmlDocument.InvokeScript("添加标记", new object[] { __字符串 });
                    }));
            }
            catch (Exception)
            {
                //记录异常，排除窗口关闭时更新界面
            }
            return __标记;
        }

        private void 删除标记(int __Id)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    _HtmlDocument.InvokeScript("删除标记", new object[] { __Id, true });
                }));
            }
            catch (Exception)
            {
                //记录异常，排除窗口关闭时更新界面
            }
        }

        private void 设置标注样式(int __Id, string __样式)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    _HtmlDocument.InvokeScript("设置标注样式", new object[] { __Id, __样式 });
                }));
            }
            catch (Exception)
            {
                //记录异常，排除窗口关闭时更新界面
            }
        }

        void do清除所有_Click(object sender, EventArgs e)
        {
            _HtmlDocument.InvokeScript("清除所有标记");
            lock (_标记缓存锁)
            {
                _标记缓存.Clear();
                _跟踪开始时间.Clear();
            }
        }

        private void 检测跟踪状态()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                lock (_标记缓存锁)
                {
                    foreach (var __标记 in _标记缓存)
                    {
                        DateTime __最后时间;
                        if (!DateTime.TryParse(__标记.Value.时间, out __最后时间))
                        {
                            continue;
                        }
                        if (__最后时间.AddSeconds(_离线间隔) < DateTime.Now)
                        {
                            if (!_跟踪状态.ContainsKey(__标记.Key) || _跟踪状态[__标记.Key] != "离线")
                            {
                                _跟踪状态[__标记.Key] = "离线";
                                设置标注样式(__标记.Key, "离线");
                                System.Diagnostics.Debug.WriteLine(__标记.Key + "离线");
                            }
                        }
                        else if (__最后时间.AddSeconds(_即将离线间隔) < DateTime.Now)
                        {
                            if (!_跟踪状态.ContainsKey(__标记.Key) || _跟踪状态[__标记.Key] != "即将离线")
                            {
                                _跟踪状态[__标记.Key] = "即将离线";
                                设置标注样式(__标记.Key, "即将离线");
                                System.Diagnostics.Debug.WriteLine(__标记.Key + "即将离线");
                            }
                        }
                        else
                        {
                            _跟踪状态[__标记.Key] = "在线";
                        }
                    }
                }
            }
        }
    }

}
