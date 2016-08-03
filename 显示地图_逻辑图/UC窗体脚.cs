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
    public partial class UC窗体脚 : UserControl
    {
        private bool _按下鼠标;

        private Point _按下鼠标时位置;

        public UC窗体脚()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ParentForm.MaximumSize = Screen.FromControl(this).WorkingArea.Size;
            //this.ParentForm.SetDesktopBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width,
            //    Screen.PrimaryScreen.WorkingArea.Height);
            
            this.MouseDown += FDemo主界面_MouseDown;
            this.MouseMove += FDemo主界面_MouseMove;
            this.MouseUp += FDemo主界面_MouseUp;

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
                //this.ParentForm.Location = new Point(this.ParentForm.Location.X + __X偏移, this.ParentForm.Location.Y + __Y偏移);
                this.ParentForm.Width += __X偏移;
                this.ParentForm.Height += __Y偏移;
                _按下鼠标时位置 = __temp;
            }
        }

        void FDemo主界面_MouseUp(object sender, MouseEventArgs e)
        {
            _按下鼠标 = false;
        }

    }
}
