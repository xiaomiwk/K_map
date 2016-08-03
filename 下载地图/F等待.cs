using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GIS.IView
{
    public partial class F等待 : UserControl, I覆盖控件
    {
        public F等待()
        {
            InitializeComponent();
            this.out提示.Text = string.Empty;
        }

        public string 提示
        {
            get { return this.out提示.Text; }
            set { this.out提示.Text = value; }
        }

        public void 隐藏()
        {
            触发已隐藏();
            已隐藏 = null;
        }

        public event Action 已隐藏;

        protected void 触发已隐藏()
        {
            Action handler = 已隐藏;
            if (handler != null) handler();
        }
    }
}
