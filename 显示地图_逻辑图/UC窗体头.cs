using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图_逻辑图
{
    public partial class UC窗体头 : UserControl
    {
        private bool _按下鼠标;

        private Point _按下鼠标时位置;

        public bool 显示最大化按钮
        {
            get { return this.do最大化.Visible; }
            set
            {
                this.do最大化.Visible = value;
            }
        }
        public bool 显示最小化按钮
        {
            get { return this.do最小化.Visible; }
            set
            {
                this.do最小化.Visible = value;
            }
        }

        public UC窗体头()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ParentForm.MaximumSize = Screen.FromControl(this).WorkingArea.Size;
            //this.ParentForm.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width,
            //    Screen.PrimaryScreen.WorkingArea.Height);

            this.do关闭.Click += do关闭_Click;
            this.do最大化.Click += do最大化_Click;
            this.do最小化.Click += do最小化_Click;
            this.MouseDown += FDemo主界面_MouseDown;
            this.MouseMove += FDemo主界面_MouseMove;
            this.MouseUp += FDemo主界面_MouseUp;

            this.do最大化.MouseHover += (a, b) => this.do最大化.Image = this.ParentForm.WindowState == FormWindowState.Maximized ? 显示地图_逻辑图.Properties.Resources.默认大小1 : 显示地图_逻辑图.Properties.Resources.最大化1;
            this.do最大化.MouseLeave += (a, b) => this.do最大化.Image = this.ParentForm.WindowState == FormWindowState.Maximized ? 显示地图_逻辑图.Properties.Resources.默认大小0 : 显示地图_逻辑图.Properties.Resources.最大化0;
            this.do关闭.MouseHover += (a, b) => this.do关闭.Image = 显示地图_逻辑图.Properties.Resources.关闭1;
            this.do关闭.MouseLeave += (a, b) => this.do关闭.Image = 显示地图_逻辑图.Properties.Resources.关闭0;
            this.do最小化.MouseHover += (a, b) => this.do最小化.Image = 显示地图_逻辑图.Properties.Resources.最小化1;
            this.do最小化.MouseLeave += (a, b) => this.do最小化.Image = 显示地图_逻辑图.Properties.Resources.最小化0;
        }

        void do最小化_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        void do最大化_Click(object sender, EventArgs e)
        {
            if (this.ParentForm.WindowState == FormWindowState.Maximized)
            {
                this.ParentForm.WindowState = FormWindowState.Normal;
                this.do最大化.Image = 显示地图_逻辑图.Properties.Resources.最大化0;
            }
            else if (this.ParentForm.WindowState == FormWindowState.Normal)
            {
                this.ParentForm.WindowState = FormWindowState.Maximized;
                this.do最大化.Image = 显示地图_逻辑图.Properties.Resources.默认大小0;
            }
        }

        void do关闭_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        void FDemo主界面_MouseDown(object sender, MouseEventArgs e)
        {
            _按下鼠标 = true;
            _按下鼠标时位置 = MousePosition;
        }

        void FDemo主界面_MouseMove(object sender, MouseEventArgs e)
        {
            if (_按下鼠标)
            {
                var __temp = MousePosition;
                var __X偏移 = __temp.X - _按下鼠标时位置.X;
                var __Y偏移 = __temp.Y - _按下鼠标时位置.Y;
                this.ParentForm.Location = new Point(this.ParentForm.Location.X + __X偏移, this.ParentForm.Location.Y + __Y偏移);
                _按下鼠标时位置 = __temp;
            }
        }

        void FDemo主界面_MouseUp(object sender, MouseEventArgs e)
        {
            _按下鼠标 = false;
        }

    }
}
