using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图_示例
{
    public partial class F轨迹参数 : Form
    {
        public F轨迹参数()
        {
            InitializeComponent();
        }

        public int 频率
        {
            get { return (int)this.in频率.SelectedItem * 1000; }
            set { this.in频率.SelectedItem = value; }
        }

        public int 数量
        {
            get { return (int)this.in数量.SelectedItem; }
            set { this.in数量.SelectedItem = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in频率.DropDownStyle = ComboBoxStyle.DropDownList;
            this.in频率.Items.AddRange(new object[] { 1, 5, 10, 20, 30, 40, 60 });
            this.in频率.SelectedIndex = 0;
            this.in数量.DropDownStyle = ComboBoxStyle.DropDownList;
            this.in数量.Items.AddRange(new object[] { 10, 100, 1000, 5000 });
            this.in数量.SelectedIndex = 0;

            this.do确定.Click += do确定_Click;
        }

        void do确定_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
