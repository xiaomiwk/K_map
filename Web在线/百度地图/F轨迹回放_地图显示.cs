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
    public partial class F轨迹回放_地图显示 : UserControl, I覆盖控件
    {
        private HtmlDocument _HtmlDocument;

        private readonly Dictionary<int, M标记> _标记缓存 = new Dictionary<int, M标记>();

        private readonly List<M轨迹信息> _轨迹列表;

        private List<M轨迹信息> _未播轨迹列表;

        private DateTime _当前播放时间;

        private const int _定时器间隔 = 1000;

        private float _播放倍速;

        private bool _暂停;

        private bool _未开始播放 = true;

        private readonly DateTime _起始时间;

        private readonly DateTime _结束时间;

        private int _即将离线间隔 = 6;//秒

        private int _离线间隔 = 18;//秒

        private readonly Dictionary<int, string> _跟踪状态 = new Dictionary<int, string>();

        public F轨迹回放_地图显示(DateTime __起始时间, DateTime __结束时间, List<M轨迹信息> __轨迹列表)
        {
            _轨迹列表 = __轨迹列表;
            _起始时间 = __起始时间;
            _结束时间 = __结束时间;
            _当前播放时间 = _起始时间;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out播放进度.Maximum = 10;
            this.out当前时间.Text = this._起始时间.ToString();
            this.in定时器.Interval = _定时器间隔;
            this.in定时器.Tick += in定时器_Tick;
            this.in播放速度.Items.AddRange(new object[]
                {
                    "实际速度",
                    "10倍速度",
                    "30倍速度",
                    "60倍速度",
                    "600倍速度",
                });
            this.in播放速度.SelectedIndex = 0;
            in播放速度_SelectedIndexChanged(null, null);
            this.do停止.Visible = false;
            this.do暂停.Visible = false;

            this.do暂停.Click += do暂停_Click;
            this.do停止.Click += do停止_Click;
            this.do播放.Click += do播放_Click;
            this.in播放速度.SelectedIndexChanged += in播放速度_SelectedIndexChanged;
            this.do关闭.Click += do关闭_Click;

            this.in显示模式.Items.Clear();
            this.in显示模式.Items.AddRange(new object[] { "手动", "以个体为中心", "概览" });
            this.in显示模式.SelectedIndex = 0;
            this.in显示模式.SelectedIndexChanged += in显示模式_SelectedIndexChanged;
            this.do设置中心号码.Click += do设置中心号码_Click;
            this.out以个体为中心.Visible = false;

            this.out浏览器.ScriptErrorsSuppressed = true;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "F轨迹回放.html"));

            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;
        }

        void do关闭_Click(object sender, EventArgs e)
        {
            this.触发已隐藏();
        }

        void in定时器_Tick(object sender, EventArgs e)
        {
            if (this._暂停)
            {
                return;
            }
            var __播放起始时间 = _当前播放时间;
            _当前播放时间 = _当前播放时间.AddMilliseconds(_定时器间隔 * _播放倍速);
            this.out当前时间.Text = _当前播放时间.ToString();
            var __进度 = (int)(_当前播放时间.Subtract(_起始时间).TotalSeconds * this.out播放进度.Maximum / _结束时间.Subtract(_起始时间).TotalSeconds);
            this.out播放进度.Value = Math.Min(this.out播放进度.Maximum, __进度);
            foreach (var __轨迹信息 in _未播轨迹列表)
            {
                //查找对应时段内的轨迹，如果有则删除原标记，添加新标记
                var __匹配GPS = __轨迹信息.GPS列表.FindLast(q => q.时间 <= _当前播放时间);
                if (__匹配GPS != null)
                {
                    删除标记(__轨迹信息.号码.Id);
                    var __标记 = new M标记
                        {
                            Id = __轨迹信息.号码.Id,
                            名称 = __轨迹信息.号码.名称,
                            号码 = __轨迹信息.号码.号码,
                            描述 = __轨迹信息.号码.描述,
                            经度 = __匹配GPS.经度,
                            纬度 = __匹配GPS.纬度,
                            打开描述 = false,
                            误差半径 = __匹配GPS.误差半径,
                            方向 = __匹配GPS.方向,
                            颜色 = __轨迹信息.轨迹颜色,
                            时间 = __匹配GPS.时间.ToString(),
                        };
                    添加标记(__标记);
                    _标记缓存[__轨迹信息.号码.Id] = __标记;
                    __轨迹信息.GPS列表.RemoveAll(q => q.时间 <= _当前播放时间); 
                    _跟踪状态[__标记.Id] = "在线";
                }
                else
                {
                    //检测时间状态
                    if (!_标记缓存.ContainsKey(__轨迹信息.号码.Id))
                    {
                        continue;
                    }
                    var __标记 = _标记缓存[__轨迹信息.号码.Id];
                    DateTime __最后时间;
                    if (!DateTime.TryParse(__标记.时间, out __最后时间))
                    {
                        continue;
                    }
                    if (__最后时间.AddSeconds(_离线间隔) < _当前播放时间)
                    {
                        if (!_跟踪状态.ContainsKey(__标记.Id) || _跟踪状态[__标记.Id] != "离线")
                        {
                            _跟踪状态[__标记.Id] = "离线";
                            设置标注样式(__标记.Id, "离线");
                            System.Diagnostics.Debug.WriteLine(__标记.Id + "离线");
                        }
                    }
                    else if (__最后时间.AddSeconds(_即将离线间隔) < DateTime.Now)
                    {
                        if (!_跟踪状态.ContainsKey(__标记.Id) || _跟踪状态[__标记.Id] != "即将离线")
                        {
                            _跟踪状态[__标记.Id] = "即将离线";
                            设置标注样式(__标记.Id, "即将离线");
                            System.Diagnostics.Debug.WriteLine(__标记.Id + "即将离线");
                        }
                    }
                }
            }

            if (_结束时间 <= _当前播放时间)
            {
                do停止.PerformClick();
            }
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

            //画出路径，需要依据参数长度，循环绘制
            var __每次点数 = 100;
            foreach (var __轨迹信息 in _轨迹列表)
            {
                var __GPS数量 = __轨迹信息.GPS列表.Count;
                var __次数 = __GPS数量 / __每次点数;
                if (__GPS数量 % 100 > 0)
                {
                    __次数++;
                }
                object __上次最后一个点 = null;
                for (var i = 0; i < __次数; i++)
                {
                    var __数量 = Math.Min(__每次点数, __GPS数量 - i * __每次点数);
                    var __参数列表 = new List<object>();
                    if (__上次最后一个点 != null)
                    {
                        __参数列表.Add(__上次最后一个点);
                    }
                    for (var j = 0; j < __数量; j++)
                    {
                        var __gps = __轨迹信息.GPS列表[i * __每次点数 + j];
                        var __参数 = new { 经度 = __gps.经度, 纬度 = __gps.纬度 };
                        __参数列表.Add(__参数);
                    }
                    __上次最后一个点 = __参数列表.Last();
                    var __序列化器 = new JavaScriptSerializer();
                    var __字符串 = __序列化器.Serialize(__参数列表);
                    var __颜色 = string.Format("#{0:X2}{1:X2}{2:X2}", __轨迹信息.轨迹颜色.R, __轨迹信息.轨迹颜色.G, __轨迹信息.轨迹颜色.B);
                    _HtmlDocument.InvokeScript("画出路径", new object[] { __颜色, __字符串 });
                }
            }
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
                _标记缓存.Remove(__Id);
            }
        }

        private void 添加标记(M标记 __标记)
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

        void in播放速度_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.in播放速度.SelectedIndex)
            {
                case 0:
                    _播放倍速 = 1f;
                    break;
                case 1:
                    _播放倍速 = 10f;
                    break;
                case 2:
                    _播放倍速 = 30f;
                    break;
                case 3:
                    _播放倍速 = 60f;
                    break;
                case 4:
                    _播放倍速 = 600f;
                    break;
            }
        }

        void do播放_Click(object sender, EventArgs e)
        {
            if (_未开始播放)
            {
                _未开始播放 = false;
                _当前播放时间 = _起始时间;
                _未播轨迹列表 = new List<M轨迹信息>();
                _轨迹列表.ForEach(q => _未播轨迹列表.Add(new M轨迹信息
                    {
                        GPS列表 = new List<MGPS>(q.GPS列表),
                        轨迹颜色 = q.轨迹颜色,
                        号码 = q.号码,
                    }));
                _跟踪状态.Clear();
            }
            _暂停 = false;
            this.in定时器.Start();
            this.do播放.Visible = false;
            this.do停止.Visible = true;
            this.do暂停.Visible = true;
        }

        void do停止_Click(object sender, EventArgs e)
        {
            _未开始播放 = true;
            _暂停 = false;
            this.in定时器.Stop();
            this.do播放.Visible = true;
            this.do停止.Visible = false;
            this.do暂停.Visible = false;
        }

        void do暂停_Click(object sender, EventArgs e)
        {
            this._暂停 = true;
            this.do播放.Visible = true;
            this.do停止.Visible = false;
            this.do暂停.Visible = false;
        }

        public void 隐藏()
        {
            触发已隐藏();
            已隐藏 = null;
        }

        public event Action 已隐藏;

        protected void 触发已隐藏()
        {
            Action handler = 已隐藏;
            if (handler != null) handler();
        }
    }

}
