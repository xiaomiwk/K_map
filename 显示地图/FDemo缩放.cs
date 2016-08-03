using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图
{
    public partial class FDemo缩放 : UserControl
    {
        public Color 按钮背景颜色
        {
            get
            {
                return this.do放大.BackColor;
            }
            set
            {
                this.do放大.BackColor = value;
                this.do缩小.BackColor = value;
            }
        }

        public Color 按钮文字颜色
        {
            get
            {
                return this.do放大.ForeColor;
            }
            set
            {
                this.do放大.ForeColor = value;
                this.do缩小.ForeColor = value;
            }
        }

        public FDemo缩放()
        {
            InitializeComponent();
        }

        public event Action<int> 缩放级别改变;

        protected void On缩放级别改变(int obj)
        {
            var handler = 缩放级别改变;
            if (handler != null) handler(obj);
        }

        public void 设置级别范围(int __最小, int __最大)
        {
            this.out进度条.ValueChanged -= out进度条_ValueChanged;
            out进度条.Minimum = __最小;
            out进度条.Maximum = __最大;
            out进度条.TickFrequency = 1;
            out进度条.LargeChange = 1;
            this.out进度条.ValueChanged += out进度条_ValueChanged;
        }

        public void 设置当前级别(int __级别)
        {
            if (out进度条.Value == __级别)
            {
                return;
            }
            this.out进度条.ValueChanged -= out进度条_ValueChanged;
            out进度条.Value = __级别;
            this.out进度条.ValueChanged += out进度条_ValueChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do缩小.Click += do缩小_Click;
            this.do放大.Click += do放大_Click;
            this.out进度条.ValueChanged += out进度条_ValueChanged;
        }

        private void do放大_Click(object sender, EventArgs e)
        {
            if (out进度条.Value < out进度条.Maximum)
            {
                out进度条.Value++;
                On缩放级别改变(out进度条.Value);
            }
        }

        private void do缩小_Click(object sender, EventArgs e)
        {
            if (out进度条.Value > out进度条.Minimum)
            {
                out进度条.Value--;
                On缩放级别改变(out进度条.Value);
            }
        }

        private void out进度条_ValueChanged(object sender, EventArgs e)
        {
            On缩放级别改变(out进度条.Value);
        }
    }
}
