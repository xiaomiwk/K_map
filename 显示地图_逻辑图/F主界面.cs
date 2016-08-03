using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图_逻辑图
{
    public partial class F主界面 : Form
    {
        public F主界面()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do真实地图.Click += do真实地图_Click;
            this.do空白地图.Click += do空白地图_Click;
            this.do逻辑图.Click += do逻辑图_Click;
            this.do逻辑图2.Click += do逻辑图2_Click;
        }

        void do逻辑图2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new F逻辑图2().ShowDialog();
            this.Show();
        }

        void do逻辑图_Click(object sender, EventArgs e)
        {
            this.Hide();
            new F逻辑图().ShowDialog();
            this.Show();
        }

        void do空白地图_Click(object sender, EventArgs e)
        {
            this.Hide();
            new F空白地图().ShowDialog();
            this.Show();
        }

        void do真实地图_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //new FDemo真实地图().ShowDialog();
            //this.Show();
        }

    }
}
