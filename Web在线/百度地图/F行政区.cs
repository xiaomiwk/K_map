using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Demo
{
    public partial class F行政区 : UserControl
    {
        private HtmlDocument _HtmlDocument;

        private List<M行政区位置> _所有行政区 = new List<M行政区位置>();

        private AutoResetEvent _锁 = new AutoResetEvent(false);

        private List<string> _失败信息 = new List<string>();

        public F行政区()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out调试信息.Text = "";
            var __所有省 = H行政区位置.所有.Select(q => q.省).Distinct().ToList();

            this.in省.DataSource = __所有省;
            this.in省.SelectedIndexChanged += in省_SelectedIndexChanged;
            this.in市.SelectedIndexChanged += in市_SelectedIndexChanged;
            this.in区.SelectedIndexChanged += in区_SelectedIndexChanged;
            this.in省.SelectedIndex = __所有省.FindIndex(q => q == "江苏省");

            this.do绘制边界.Click += do绘制边界_Click;
            this.do导出所有.Click += do导出所有_Click;
            this.do单个查询.Click += do单个查询_Click;
            this.out浏览器.ScriptErrorsSuppressed = true;
            this.out浏览器.Navigate(Path.Combine(Environment.CurrentDirectory, "F行政区.html"));

            this.out浏览器.DocumentCompleted += out浏览器_DocumentCompleted;

            //压缩(@"E:\项目--公共\基础\地图\Web地图\调试输出_百度地图\行政区 - 第二次校对后.csv");
        }

        void do绘制边界_Click(object sender, EventArgs e)
        {
            var __省 = (string)this.in省.SelectedValue;
            var __市 = (string)this.in市.SelectedValue;
            var __区 = (string)this.in区.SelectedValue;
            if (__市 == __省 || string.IsNullOrEmpty(__市))
            {
                _HtmlDocument.InvokeScript("绘制边界", new object[] { __省 });
                return;
            }
            if (__区 == __市 || string.IsNullOrEmpty(__区))
            {
                _HtmlDocument.InvokeScript("绘制边界", new object[] { __市 });
                return;
            }
            _HtmlDocument.InvokeScript("绘制边界", new object[] { __市 + __区 });
        }

        void in区_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __区 = (string)this.in区.SelectedValue;
            //if (_HtmlDocument != null)
            //{
            //    _HtmlDocument.InvokeScript("绘制边界", new object[] { __区 });
            //}
        }

        void in市_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省 = (string)this.in省.SelectedValue;
            var __市 = (string)this.in市.SelectedValue;
            if (__省 == __市)
            {
                this.in区.DataSource = null;
                return;
            }
            var __区 = H行政区位置.所有.Where(q => q.省 == __省 && q.市 == __市).Select(q => q.区).Distinct();
            this.in区.DataSource = __区.ToList();
        }

        void in省_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省 = (string)this.in省.SelectedValue;
            var __省内市 = H行政区位置.所有.Where(q => q.省 == __省).Select(q => q.市).Distinct();
            this.in市.DataSource = __省内市.ToList();
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

        void 压缩(string __文件名)
        {
            var __文件 = new FileInfo(__文件名);
            using (FileStream ___源文件流 = __文件.OpenRead())
            {
                if ((File.GetAttributes(__文件.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & __文件.Extension != ".gz")
                {
                    using (FileStream __目的文件流 = File.Create(__文件.FullName + ".gz"))
                    {
                        using (var __压缩流 = new GZipStream(__目的文件流, CompressionMode.Compress))
                        {
                            ___源文件流.CopyTo(__压缩流);
                            Console.WriteLine("文件 {0} 从 {1} 压缩到 {2} bytes.", __文件.Name, __文件.Length, __目的文件流.Length);
                        }
                    }
                }
            }
        }

        void do导出所有_Click(object sender, EventArgs e)
        {
            this.do导出所有.Enabled = false;
            H行政区位置.重新初始化();

            var __任务 = new Task(() =>
            {
                //执行后台任务
                _所有行政区.Clear();
                H行政区位置.所有.ForEach(q => 查询区域(q.描述));

                var __描述 = new StringBuilder();
                H行政区位置.所有.ForEach(q => __描述.Append(q.序列化()).AppendLine());
                var __文件名 = string.Format("行政区 {0}", DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss"));
                var __文件路径 = Path.Combine(Environment.CurrentDirectory, __文件名);
                File.WriteAllText(__文件路径, __描述.ToString(), Encoding.UTF8);
                压缩(__文件路径);

                if (_失败信息.Count > 0)
                {
                    var __temp = new StringBuilder();
                    _失败信息.ForEach(q => __temp.Append(q).AppendLine());
                    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "失败信息.txt"), __temp.ToString(), Encoding.UTF8);
                }
                else
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, "失败信息.txt"));
                }
            });
            __任务.ContinueWith(task =>
            {
                //成功后提示, 并取消限制 
                this.do导出所有.Enabled = true;
                this.out调试信息.Text = "";
                MessageBox.Show("下载完毕");

            },
                CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                 TaskScheduler.FromCurrentSynchronizationContext());
            __任务.ContinueWith(task =>
            {
                //失败后提示, 并取消限制    
                this.do导出所有.Enabled = true;
                MessageBox.Show("下载出错: " + task.Exception.GetBaseException().Message);
                task.Exception.Handle(q => true);
            },
                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                 TaskScheduler.FromCurrentSynchronizationContext());

            //开始任务
            __任务.Start();

        }

        void do单个查询_Click(object sender, EventArgs e)
        {
            var __窗口 = new F行政区_单个查询 { StartPosition = FormStartPosition.CenterParent };
            __窗口.提交 += (arg1, arg2) => _HtmlDocument.InvokeScript(arg1, arg2);
            查询HTML元素("do触发事件").AttachEventHandler("onclick", (sender1, e1) =>
            {
                var __事件名称 = 查询HTML元素("do触发事件").GetAttribute("value");
                var __事件参数 = 查询HTML元素("in事件参数").GetAttribute("value");
                __窗口.处理响应(__事件名称, __事件参数);
            });
            __窗口.ShowDialog();
            __窗口.Close();
        }

        private void 查询区域(string __当前区域)
        {
            this.Invoke(new Action(() =>
            {
                this.out调试信息.Text = "正在查询: " + __当前区域;
                _HtmlDocument.InvokeScript("导出边界", new object[] { __当前区域 });
            }));
            _锁.WaitOne();
            //Thread.Sleep(50);
            this.Invoke(new Action(() => _HtmlDocument.InvokeScript("查询位置", new object[] { __当前区域 })));
            _锁.WaitOne();
            Thread.Sleep(50);
        }

        private void 处理WEB请求(object sender, EventArgs e)
        {
            var __事件名称 = 查询HTML元素("do触发事件").GetAttribute("value");
            var __事件参数 = 查询HTML元素("in事件参数").GetAttribute("value");
            //MessageBox.Show(string.Format("处理WEB请求，事件名称：{0}, 事件参数：{1}", __事件名称, __事件参数));

            var __地址 = __事件参数.Split(':')[0];
            M行政区位置 __当前行政区 = null;
            foreach (M行政区位置 q in H行政区位置.所有)
            {
                if (q.描述 == __地址)
                {
                    __当前行政区 = q;
                    break;
                }
            }

            if (__事件名称 == "导出边界")
            {
                var __边界坐标 = __事件参数.Split(':')[1];
                if (__边界坐标 == "0,0")
                {
                    _失败信息.Add(__地址 + " : 导出边界");
                }
                else
                {
                    __当前行政区.边界坐标 = __边界坐标;
                }
                _锁.Set();
            }

            if (__事件名称 == "查询位置")
            {
                var __位置参数 = __事件参数.Split(':')[1];
                if (__位置参数 == "0,0")
                {
                    _失败信息.Add(__地址 + " : 查询位置");
                }
                else
                {
                    __当前行政区.经度 = double.Parse(__位置参数.Split(',')[0]);
                    __当前行政区.纬度 = double.Parse(__位置参数.Split(',')[1]);
                }
                _锁.Set();
            }
        }
    }
}
