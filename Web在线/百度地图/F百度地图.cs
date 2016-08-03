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
    public partial class F百度地图 : Form
    {
        private F定位 __定位;

        private F跟踪 __跟踪;

        private F轨迹回放 __轨迹回放;

        private F地址查询 __地址查询;

        private F区域操作 __区域操作;

        private F行政区 __行政区;

        public F百度地图()
        {
            InitializeComponent();

            __定位 = new F定位 { Dock = DockStyle.Fill };
            this.out定位.Controls.Add(__定位);

            __跟踪 = new F跟踪 { Dock = DockStyle.Fill };
            this.out跟踪.Controls.Add(__跟踪);

            __轨迹回放 = new F轨迹回放 { Dock = DockStyle.Fill };
            this.out轨迹回放.Controls.Add(__轨迹回放);

            __地址查询 = new F地址查询 { Dock = DockStyle.Fill };
            this.out地址查询.Controls.Add(__地址查询);

            __区域操作 = new F区域操作 { Dock = DockStyle.Fill };
            this.out区域操作.Controls.Add(__区域操作);

            __行政区 = new F行政区 { Dock = DockStyle.Fill };
            this.out行政区.Controls.Add(__行政区);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out功能容器.SelectedTab = this.out行政区;
        }

    }
}
