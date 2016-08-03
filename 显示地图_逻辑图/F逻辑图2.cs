using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图_逻辑图
{
    public partial class F逻辑图2 : Form
    {
        private M可视树节点<M示例业务对象, Button, Label> _根可视节点;

        int _节点宽度 = 120;

        int _节点高度 = 30;

        int _连线厚度 = 2;

        Padding _留白 = new Padding(50, 20, 50, 20);

        public F逻辑图2()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Resize += FDemo逻辑图2_Resize;

            var __根节点 = new M树节点<M示例业务对象> { 业务对象 = new M示例业务对象 { 名称 = "根节点" } };
            for (int i = 0; i < 1; i++)
            {
                __根节点.子节点.Add(new M树节点<M示例业务对象> { 业务对象 = new M示例业务对象 { 名称 = "2层节点" }, 父节点 = __根节点 });
                var __2层节点 = __根节点.子节点[i];
                for (int j = 0; j < 2; j++)
                {
                    __2层节点.子节点.Add(new M树节点<M示例业务对象> { 业务对象 = new M示例业务对象 { 名称 = "1层节点" }, 父节点 = __2层节点 });
                    var __1层节点 = __2层节点.子节点[j];
                    for (int k = 0; k < 3; k++)
                    {
                        __1层节点.子节点.Add(new M树节点<M示例业务对象> { 业务对象 = new M示例业务对象 { 名称 = "0层节点" }, 父节点 = __1层节点 });
                    }
                }
            }
            _根可视节点 = M可视树节点<M示例业务对象, Button, Label>.生成可视树(__根节点, q => 生成节点(q.业务对象), q => 生成连线(q.业务对象));
            //_根可视节点.从左到右呈现(this.out容器, _节点宽度, _节点高度, _连线厚度, _留白, true);
            _根可视节点.从上到下呈现(this.out容器, _节点宽度, _节点高度, _连线厚度, _留白, true);
            var __所有节点 = _根可视节点.查询所有节点();
            var __所有可视节点 = _根可视节点.查询所有可视节点();
            var __所有业务对象树节点映射 = ((M树节点<M示例业务对象>)_根可视节点).查询业务对象映射();
            var __所有业务对象可视节点映射 = _根可视节点.查询业务对象映射();
            var __所有节点控件映射 = _根可视节点.查询节点控件映射();
            var __所有连线控件映射 = _根可视节点.查询连线控件映射();
        }

        void FDemo逻辑图2_Resize(object sender, EventArgs e)
        {
            //_根可视节点.从左到右呈现(this.out容器, _节点宽度, _节点高度, _连线厚度, _留白, false);
            _根可视节点.从上到下呈现(this.out容器, _节点宽度, _节点高度, _连线厚度, _留白, false);
        }

        private Button 生成节点(M示例业务对象 __业务对象)
        {
            var __控件 = new Button() { Text = __业务对象.名称, Width = _节点宽度, Height = _节点高度, Tag = __业务对象 };
            __控件.Click += (a, b) => MessageBox.Show(__业务对象.ToString(), "业务对象");
            return __控件;
        }

        private Label 生成连线(M示例业务对象 __业务对象)
        {
            var __连线 = new Label() { BackColor = __业务对象.名称 == "0层节点" ? Color.Red : Color.Green };
            __连线.Click += (a, b) => MessageBox.Show(__业务对象.ToString(), "业务对象");
            return __连线;
        }
    }

    /// <summary>
    /// M树节点
    /// </summary>
    /// <typeparam name="T">业务对象</typeparam>
    public class M树节点<T>
    {
        static int 索引 { get; set; }

        public string 标识 { get; set; }

        public T 业务对象 { get; set; }

        public M树节点<T> 父节点 { get; set; }

        public List<M树节点<T>> 子节点 { get; set; }

        public static List<M树节点<T>> 查询所有节点(M树节点<T> __节点)
        {
            var __结果 = new List<M树节点<T>> { __节点 };
            foreach (var __子节点 in __节点.子节点)
            {
                __结果.AddRange(查询所有节点(__子节点));
            }
            return __结果;
        }

        public List<M树节点<T>> 查询所有节点()
        {
            return 查询所有节点(this);
        }

        public static Dictionary<T, M树节点<T>> 查询业务对象映射(M树节点<T> __节点)
        {
            var __结果 = new Dictionary<T, M树节点<T>>();
            __结果[__节点.业务对象] = __节点;
            foreach (var __子节点 in __节点.子节点)
            {
                var __temp = 查询业务对象映射(__子节点);
                foreach (var kv in __temp)
                {
                    __结果[kv.Key] = kv.Value;
                }
            }
            return __结果;
        }

        public Dictionary<T, M树节点<T>> 查询业务对象映射()
        {
            return 查询业务对象映射(this);
        }

        public M树节点()
        {
            标识 = 索引++.ToString();
            子节点 = new List<M树节点<T>>();
        }
    }

    /// <summary>
    /// M可视树节点
    /// </summary>
    /// <typeparam name="T">业务对象</typeparam>
    /// <typeparam name="U">节点控件</typeparam>
    /// <typeparam name="V">连线控件</typeparam>
    public class M可视树节点<T, U, V> : M树节点<T>
        where U : Control
        where V : Control
    {
        public int 层数 { get; set; }

        public float 占位 { get; set; }

        public int 范围起始 { get; set; }

        public int 范围结束 { get; set; }

        public M可视树节点<T, U, V> 父可视节点 { get; set; }

        public List<M可视树节点<T, U, V>> 子可视节点 { get; set; }

        public U 节点控件 { get; set; }

        public List<V> 连线控件 { get; set; }

        private readonly Func<M树节点<T>, V> 生成连线;

        public M可视树节点(M树节点<T> __树节点, Func<M树节点<T>, U> __生成控件, Func<M树节点<T>, V> __生成连线)
        {
            this.子可视节点 = new List<M可视树节点<T, U, V>>();
            this.连线控件 = new List<V>();
            this.节点控件 = __生成控件(__树节点);
            this.生成连线 = __生成连线;

            this.父节点 = __树节点.父节点;
            this.标识 = __树节点.标识;
            this.子节点 = __树节点.子节点;
            this.业务对象 = __树节点.业务对象;
        }

        public static M可视树节点<T, U, V> 生成可视树(M树节点<T> __根节点, Func<M树节点<T>, U> __生成控件, Func<M树节点<T>, V> __生成连线)
        {
            int __总层数 = 0;
            var __终结点列表 = new List<M树节点<T>>();
            递归过滤终结点(__根节点, __终结点列表);
            __终结点列表.ForEach(q =>
            {
                int __层数 = 0;
                迭代计算总层数(q, ref __层数);
                if (__层数 > __总层数)
                {
                    __总层数 = __层数;
                }
            });
            var __可视终结点列表 = new List<M可视树节点<T, U, V>>();
            for (int i = 0; i < __终结点列表.Count; i++)
            {
                __可视终结点列表.Add(new M可视树节点<T, U, V>(__终结点列表[i], __生成控件, __生成连线) { 占位 = i, 范围起始 = i, 范围结束 = i, 层数 = 0 });
            }
            return 递归生成可视节点(__根节点, __总层数, __可视终结点列表, __生成控件, __生成连线);
        }

        private static void 递归过滤终结点(M树节点<T> __节点, List<M树节点<T>> __终结点)
        {
            if (__节点.子节点 == null || __节点.子节点.Count == 0)
            {
                __终结点.Add(__节点);
                return;
            }
            foreach (var __树节点 in __节点.子节点)
            {
                递归过滤终结点(__树节点, __终结点);
            }
        }

        private static void 迭代计算总层数(M树节点<T> __节点, ref int __层数)
        {
            __层数++;
            if (__节点.父节点 == null)
            {
                return;
            }
            迭代计算总层数(__节点.父节点, ref __层数);
        }

        private static M可视树节点<T, U, V> 递归生成可视节点(M树节点<T> __节点, int __层数, List<M可视树节点<T, U, V>> __可视终结点列表, Func<M树节点<T>, U> __生成控件, Func<M树节点<T>, V> __生成连线)
        {
            var __终结点 = new List<M树节点<T>>();
            递归过滤终结点(__节点, __终结点);
            var __范围起始 = int.MaxValue;
            var __范围结束 = 0;
            __终结点.ForEach(q =>
            {
                var __匹配可视终结点 = __可视终结点列表.Find(k => k.标识 == q.标识);
                __范围起始 = Math.Min(__范围起始, __匹配可视终结点.范围起始);
                __范围结束 = Math.Max(__范围结束, __匹配可视终结点.范围结束);
            });
            var __可视节点 = new M可视树节点<T, U, V>(__节点, __生成控件, __生成连线)
            {
                层数 = --__层数,
                范围起始 = __范围起始,
                范围结束 = __范围结束,
                占位 = (float)((__范围起始 + __范围结束) / 2.0)
            };
            if (__节点.子节点 == null || __节点.子节点.Count == 0)
            {
                return __可视节点;
            }
            foreach (var __树节点 in __节点.子节点)
            {
                var __可视子节点 = 递归生成可视节点(__树节点, __可视节点.层数, __可视终结点列表, __生成控件, __生成连线);
                //__可视子节点.父可视节点 = __可视节点;
                __可视节点.子可视节点.Add(__可视子节点);
            }
            return __可视节点;
        }

        public void 从左到右呈现(Control __容器, int __节点宽度, int __节点高度, int __连线厚度, Padding __留白, bool __合并连线 = false)
        {
            从左到右呈现(this, __容器, __节点宽度, __节点高度, __连线厚度, __留白, __合并连线);
        }

        public static void 从左到右呈现(M可视树节点<T, U, V> __可视树, Control __容器, int __节点宽度, int __节点高度, int __连线厚度, Padding __留白, bool __合并连线 = false)
        {
            var __容器长度 = __容器.Width;
            var __容器高度 = __容器.Height;
            var __连线X长度 = (__容器长度 - __留白.Left - __留白.Right - (__可视树.层数 + 1) * __节点宽度) / __可视树.层数;
            var __连线Y长度 = (__容器高度 - __留白.Top - __留白.Bottom - (__可视树.范围结束 - __可视树.范围起始 + 1) * __节点高度) / (__可视树.范围结束 - __可视树.范围起始);
            从左到右递归呈现(__可视树, __容器, __留白, __连线X长度, __连线Y长度, __可视树.层数, __连线厚度, __合并连线);
        }

        private static void 从左到右递归呈现(M可视树节点<T, U, V> __节点, Control __容器, Padding __留白, int __连线X长度, int __连线Y长度, int __总层数, int __连线厚度, bool __合并连线 = false)
        {
            __节点.节点控件.Left = __留白.Left + (__节点.节点控件.Width + __连线X长度) * (__总层数 - __节点.层数);
            __节点.节点控件.Top = (int)(__留白.Top + (__节点.节点控件.Height + __连线Y长度) * __节点.占位);
            __容器.Controls.Add(__节点.节点控件);
            var __子节点数量 = __节点.子节点.Count;
            var __当前子节点索引 = 0;
            foreach (var __子节点 in __节点.子可视节点)
            {
                从左到右递归呈现(__子节点, __容器, __留白, __连线X长度, __连线Y长度, __总层数, __连线厚度, __合并连线);
                if (__子节点数量 == 1)
                {
                    V __连线;
                    if (__子节点.连线控件.Count > 0)
                    {
                        __连线 = __子节点.连线控件[0];
                    }
                    else
                    {
                        __连线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__连线);
                        __子节点.连线控件.Add(__连线);
                    }
                    __连线.Width = __连线X长度;
                    __连线.Height = __连线厚度;
                    __连线.Left = __节点.节点控件.Left + __节点.节点控件.Width;
                    __连线.Top = __节点.节点控件.Top + __节点.节点控件.Height / 2;
                }
                else
                {
                    //前横线
                    int __X重叠偏移 = 0;
                    var __Y重叠偏移 = 0;
                    if (!__合并连线)
                    {
                        __X重叠偏移 = (__当前子节点索引 - __子节点数量 / 2) * (__连线厚度 + 1);
                        __Y重叠偏移 = __X重叠偏移;
                        if (__子节点数量 % 2 == 0 && __当前子节点索引 >= __子节点数量 / 2)
                        {
                            __X重叠偏移 = (__当前子节点索引 + 1 - __子节点数量 / 2) * (__连线厚度 + 1);
                        }
                    }
                    V __前横线;
                    if (__子节点.连线控件.Count > 0)
                    {
                        __前横线 = __子节点.连线控件[0];
                    }
                    else
                    {
                        __前横线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__前横线);
                        __子节点.连线控件.Add(__前横线);
                    }
                    __前横线.Width = __连线X长度 / 2 - Math.Abs(__X重叠偏移);
                    __前横线.Height = __连线厚度;
                    __前横线.Left = __节点.节点控件.Left + __节点.节点控件.Width;
                    __前横线.Top = __节点.节点控件.Top + __节点.节点控件.Height / 2 + __Y重叠偏移;

                    //后横线
                    V __后横线;
                    if (__子节点.连线控件.Count > 1)
                    {
                        __后横线 = __子节点.连线控件[1];
                    }
                    else
                    {
                        __后横线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__后横线);
                        __子节点.连线控件.Add(__后横线);
                    }
                    __后横线.Width = __子节点.节点控件.Left - __前横线.Left - __前横线.Width;
                    __后横线.Height = __连线厚度;
                    __后横线.Left = __前横线.Left + __前横线.Width;
                    __后横线.Top = __子节点.节点控件.Top + __节点.节点控件.Height / 2;
                    __容器.Controls.Add(__后横线);

                    //中竖线
                    V __中竖线;
                    if (__子节点.连线控件.Count > 2)
                    {
                        __中竖线 = __子节点.连线控件[2];
                    }
                    else
                    {
                        __中竖线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__中竖线);
                        __子节点.连线控件.Add(__中竖线);
                    }
                    __中竖线.Width = __连线厚度;
                    __中竖线.Height = Math.Abs(__后横线.Top - __前横线.Top) + __连线厚度;
                    __中竖线.Left = __后横线.Left;
                    __中竖线.Top = Math.Min(__前横线.Top, __后横线.Top);

                    __当前子节点索引++;
                }
            }
        }

        public void 从上到下呈现(Control __容器, int __节点宽度, int __节点高度, int __连线厚度, Padding __留白, bool __合并连线 = false)
        {
            从上到下呈现(this, __容器, __节点宽度, __节点高度, __连线厚度, __留白, __合并连线);
        }

        public static void 从上到下呈现(M可视树节点<T, U, V> __可视树, Control __容器, int __节点宽度, int __节点高度, int __连线厚度, Padding __留白, bool __合并连线 = false)
        {
            var __容器长度 = __容器.Width;
            var __容器高度 = __容器.Height;
            var __连线X长度 = (__容器长度 - __留白.Left - __留白.Right - (__可视树.范围结束 - __可视树.范围起始 + 1) * __节点宽度) / (__可视树.范围结束 - __可视树.范围起始);
            var __连线Y长度 = (__容器高度 - __留白.Top - __留白.Bottom - (__可视树.层数 + 1) * __节点高度) / __可视树.层数;
            从上到下递归呈现(__可视树, __容器, __留白, __连线X长度, __连线Y长度, __可视树.层数, __连线厚度, __合并连线);
        }

        private static void 从上到下递归呈现(M可视树节点<T, U, V> __节点, Control __容器, Padding __留白, int __连线X长度, int __连线Y长度, int __总层数, int __连线厚度, bool __合并连线 = false)
        {
            __节点.节点控件.Left = (int)(__留白.Left + (__节点.节点控件.Width + __连线X长度) * __节点.占位);
            __节点.节点控件.Top = __留白.Top + (__节点.节点控件.Height + __连线Y长度) * (__总层数 - __节点.层数);
            __容器.Controls.Add(__节点.节点控件);
            var __子节点数量 = __节点.子节点.Count;
            var __当前子节点索引 = 0;
            foreach (var __子节点 in __节点.子可视节点)
            {
                从上到下递归呈现(__子节点, __容器, __留白, __连线X长度, __连线Y长度, __总层数, __连线厚度, __合并连线);
                if (__子节点数量 == 1)
                {
                    V __连线;
                    if (__子节点.连线控件.Count > 0)
                    {
                        __连线 = __子节点.连线控件[0];
                    }
                    else
                    {
                        __连线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__连线);
                        __子节点.连线控件.Add(__连线);
                    }
                    __连线.Width = __连线厚度;
                    __连线.Height = __连线Y长度;
                    __连线.Left = __节点.节点控件.Left + __节点.节点控件.Width / 2;
                    __连线.Top = __节点.节点控件.Top + __节点.节点控件.Height;
                }
                else
                {
                    //前横线
                    int __X重叠偏移 = 0;
                    var __Y重叠偏移 = 0;
                    if (!__合并连线)
                    {
                        __Y重叠偏移 = (__当前子节点索引 - __子节点数量 / 2) * (__连线厚度 + 1);
                        __X重叠偏移 = __Y重叠偏移;
                        if (__子节点数量 % 2 == 0 && __当前子节点索引 >= __子节点数量 / 2)
                        {
                            __Y重叠偏移 = (__当前子节点索引 + 1 - __子节点数量 / 2) * (__连线厚度 + 1);
                        }
                    }
                    V __前横线;
                    if (__子节点.连线控件.Count > 0)
                    {
                        __前横线 = __子节点.连线控件[0];
                    }
                    else
                    {
                        __前横线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__前横线);
                        __子节点.连线控件.Add(__前横线);
                    }
                    __前横线.Width = __连线厚度;
                    __前横线.Height = __连线Y长度 / 2 - Math.Abs(__Y重叠偏移);
                    __前横线.Left = __节点.节点控件.Left + __节点.节点控件.Width / 2 + __X重叠偏移;
                    __前横线.Top = __节点.节点控件.Top + __节点.节点控件.Height;

                    //后横线
                    V __后横线;
                    if (__子节点.连线控件.Count > 1)
                    {
                        __后横线 = __子节点.连线控件[1];
                    }
                    else
                    {
                        __后横线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__后横线);
                        __子节点.连线控件.Add(__后横线);
                    }
                    __后横线.Width = __连线厚度;
                    __后横线.Height = __子节点.节点控件.Top - __前横线.Top - __前横线.Height;
                    __后横线.Left = __子节点.节点控件.Left + __节点.节点控件.Width / 2;
                    __后横线.Top = __前横线.Top + __前横线.Height;
                    __容器.Controls.Add(__后横线);

                    //中竖线
                    V __中竖线;
                    if (__子节点.连线控件.Count > 2)
                    {
                        __中竖线 = __子节点.连线控件[2];
                    }
                    else
                    {
                        __中竖线 = __节点.生成连线(__子节点);
                        __容器.Controls.Add(__中竖线);
                        __子节点.连线控件.Add(__中竖线);
                    }
                    __中竖线.Width = Math.Abs(__后横线.Left - __前横线.Left) + __连线厚度;
                    __中竖线.Height = __连线厚度;
                    __中竖线.Left = Math.Min(__前横线.Left, __后横线.Left);
                    __中竖线.Top = __后横线.Top;

                    __当前子节点索引++;
                }
            }
        }

        public static List<M可视树节点<T, U, V>> 查询所有可视节点(M可视树节点<T, U, V> __节点)
        {
            var __结果 = new List<M可视树节点<T, U, V>> { __节点 };
            foreach (var __子节点 in __节点.子可视节点)
            {
                __结果.AddRange(查询所有可视节点(__子节点));
            }
            return __结果;
        }

        public List<M可视树节点<T, U, V>> 查询所有可视节点()
        {
            return 查询所有可视节点(this);
        }

        public static Dictionary<T, M可视树节点<T, U, V>> 查询业务对象可视树映射(M可视树节点<T, U, V> __节点)
        {
            var __结果 = new Dictionary<T, M可视树节点<T, U, V>>();
            __结果[__节点.业务对象] = __节点;
            foreach (var __子节点 in __节点.子可视节点)
            {
                var __temp = 查询业务对象可视树映射(__子节点);
                foreach (var kv in __temp)
                {
                    __结果[kv.Key] = kv.Value;
                }
            }
            return __结果;
        }

        public new Dictionary<T, M可视树节点<T, U, V>> 查询业务对象映射()
        {
            return 查询业务对象可视树映射(this);
        }

        public static Dictionary<U, M可视树节点<T, U, V>> 查询节点控件映射(M可视树节点<T, U, V> __节点)
        {
            var __结果 = new Dictionary<U, M可视树节点<T, U, V>>();
            __结果[__节点.节点控件] = __节点;
            foreach (var __子节点 in __节点.子可视节点)
            {
                var __temp = 查询节点控件映射(__子节点);
                foreach (var kv in __temp)
                {
                    __结果[kv.Key] = kv.Value;
                }
            }
            return __结果;
        }

        public Dictionary<U, M可视树节点<T, U, V>> 查询节点控件映射()
        {
            return 查询节点控件映射(this);
        }

        public static Dictionary<V, M可视树节点<T, U, V>> 查询连线控件映射(M可视树节点<T, U, V> __节点)
        {
            var __结果 = new Dictionary<V, M可视树节点<T, U, V>>();
            foreach (var __连线 in __节点.连线控件)
            {
                __结果[__连线] = __节点;
            }
            foreach (var __子节点 in __节点.子可视节点)
            {
                var __temp = 查询连线控件映射(__子节点);
                foreach (var kv in __temp)
                {
                    __结果[kv.Key] = kv.Value;
                }
            }
            return __结果;
        }

        public Dictionary<V, M可视树节点<T, U, V>> 查询连线控件映射()
        {
            return 查询连线控件映射(this);
        }


    }
}
