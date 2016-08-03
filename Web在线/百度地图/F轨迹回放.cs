using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class F轨迹回放 : UserControl
    {
        bool _地图显示;

        private object[] _默认颜色 = new object[]
            {
                "blue",
                "red",
                "yellow",
                "green",
                "black",
            };

        public F轨迹回放()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out颜色列.Items.AddRange(_默认颜色);
            this.in开始时间.Value = DateTime.Now.Date;
            this.in结束时间.Value = DateTime.Now.Date.AddDays(1);
            this.do开始生成.Click += do开始生成_Click;
            this.in用户列表.CellClick += in用户列表_CellClick;

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
            this.处理轨迹回放(new M号码 { Id = __Id, 名称 = __姓名, 号码 = __号码, 描述 = "此处省略100字" });
        }

        void in用户列表_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != this.in用户列表.ColumnCount - 1)
            {
                return;
            }
            this.in用户列表.Rows.RemoveAt(e.RowIndex);
        }

        public void 处理轨迹回放(M号码 __号码)
        {
            if (_地图显示)
            {
                return;
            }
            foreach (DataGridViewRow __行 in this.in用户列表.Rows)
            {
                var __绑定 = __行.Tag as M号码;
                if (__绑定.Id == __号码.Id)
                {
                    this.in用户列表.Rows.Remove(__行);
                    return;
                }
            }
            var __颜色 = this._默认颜色[(this.in用户列表.RowCount) % this._默认颜色.Length];
            this.in用户列表.Rows[this.in用户列表.Rows.Add(__号码.Id, __号码.名称, __颜色)].Tag = __号码;
        }

        void do开始生成_Click(object sender, EventArgs e)
        {
            var __起始时间 = this.in开始时间.Value;
            var __结束时间 = this.in结束时间.Value;

            //查询轨迹信息
            var __轨迹列表 = (from DataGridViewRow __行 in this.in用户列表.Rows
                          let __号码 = __行.Tag as M号码
                          let __颜色 = Color.FromName(__行.Cells["out颜色列"].Value.ToString())
                          select new M轨迹信息
                              {
                                  号码 = __号码,
                                  轨迹颜色 = __颜色,
                                  GPS列表 = 生成模拟数据(__起始时间)
                              }).ToList();
            var __地图 = new F轨迹回放_地图显示(__起始时间, __结束时间, __轨迹列表);
            _地图显示 = true;
            this.创建全覆盖控件(__地图, q => _地图显示 = false);
        }

        private List<MGPS> 生成模拟数据(DateTime __起始时间)
        {
            const double __参照经度 = 118.829829;
            const double __参照纬度 = 32.031709;
            var __随机数 = new Random(Environment.TickCount);
            var __结果 = new List<MGPS>();
            var __经度 = __参照经度 + __随机数.NextDouble() * 0.1;
            var __纬度 = __参照纬度 + __随机数.NextDouble() * 0.1;
            for (var i = 0; i < 1000; i++)
            {
                __经度 += __随机数.NextDouble() * 0.001;
                __纬度 += __随机数.NextDouble() * 0.001;
                var __gps = new MGPS()
                    {
                        时间 = __起始时间.AddSeconds(3).AddSeconds(i * 15),
                        误差半径 = 20,
                        方向 = i * 30 % 360,
                        经度 = __经度,
                        纬度 = __纬度,
                    };
                __结果.Add(__gps);
            }
            System.Threading.Thread.Sleep(100);
            return __结果;
        }
    }

    public class M轨迹信息
    {
        public M号码 号码 { get; set; }

        public Color 轨迹颜色 { get; set; }

        public List<MGPS> GPS列表 { get; set; }
    }

    public class MGPS
    {
        public double 经度 { get; set; }

        public double 纬度 { get; set; }

        /// <summary>
        /// 单位：米
        /// </summary>
        public int 误差半径 { get; set; }

        /// <summary>
        /// 范围：0-360
        /// </summary>
        public double 方向 { get; set; }

        public DateTime 时间 { get; set; }
    }



}
