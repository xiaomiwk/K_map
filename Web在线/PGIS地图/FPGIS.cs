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
    public partial class FPGIS : Form
    {
        private F定位 __定位;

        private F跟踪 __跟踪;

        private F轨迹回放 __轨迹回放;

        private F地址查询 __地址查询;

        private F区域操作 __区域操作;

        public FPGIS()
        {
            InitializeComponent();  
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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
            if (this.out功能容器.SelectedTab == this.out定位)
            {
                __定位.处理定位(new M号码 { Id = __Id, 名称 = __姓名, 号码 = __号码, 描述 = "此处省略100字" });
            }
            if (this.out功能容器.SelectedTab == this.out跟踪)
            {
                __跟踪.处理跟踪(new M号码 { Id = __Id, 名称 = __姓名, 号码 = __号码, 描述 = "此处省略100字" });
            }
            if (this.out功能容器.SelectedTab == this.out轨迹回放)
            {
                __轨迹回放.处理轨迹回放(new M号码 { Id = __Id, 名称 = __姓名, 号码 = __号码, 描述 = "此处省略100字" });
            }
        }
    }
}
