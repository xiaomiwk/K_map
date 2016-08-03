using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图_逻辑图
{
    public partial class F提示 : Form
    {
        public F提示()
        {
            InitializeComponent();

            this.do关闭.Click += do关闭_Click;
        }

        void do关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
