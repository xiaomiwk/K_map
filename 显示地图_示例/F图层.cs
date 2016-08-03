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
    public partial class F图层 : Form
    {
        public F图层()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do增加图层.Click += (sender1, e1) => On增加图层();
            this.do删除图层.Click += (sender1, e1) => On删除图层();
            this.do隐藏图层.Click += (sender1, e1) => On隐藏图层();
            this.do显示图层.Click += (sender1, e1) => On显示图层();
            this.do调整顺序.Click += (sender1, e1) => On调整顺序();
        }

        public event EventHandler 增加图层;

        protected virtual void On增加图层()
        {
            EventHandler handler = 增加图层;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler 删除图层;

        protected virtual void On删除图层()
        {
            EventHandler handler = 删除图层;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler 隐藏图层;

        protected virtual void On隐藏图层()
        {
            EventHandler handler = 隐藏图层;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler 显示图层;

        protected virtual void On显示图层()
        {
            EventHandler handler = 显示图层;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler 调整顺序;

        protected virtual void On调整顺序()
        {
            EventHandler handler = 调整顺序;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
