using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图
{
    public partial class FDemo切换 : UserControl
    {
        public Color 按钮背景颜色
        {
            get
            {
                return this.do切换.BackColor;
            }
            set
            {
                this.do切换.BackColor = value;
            }
        }

        public Color 按钮文字颜色
        {
            get
            {
                return this.do切换.ForeColor;
            }
            set
            {
                this.do切换.ForeColor = value;
            }
        }

        private List<string> _地图路径列表;

        private IF地图 _F地图;

        private int _当前地图源索引;

        public FDemo切换()
        {
            InitializeComponent();
        }

        public void 初始化(F地图 __F地图, List<string> __地图路径列表, int __当前索引)
        {
            _F地图 = __F地图;
            _地图路径列表 = __地图路径列表;
            _当前地图源索引 = __当前索引;
            this.toolTip1.SetToolTip(this.do切换, string.Format("当前地图[{0}],下一地图[{1}]", Path.GetFileNameWithoutExtension(_地图路径列表[_当前地图源索引]), Path.GetFileNameWithoutExtension(_地图路径列表[新索引()])));

            this.do切换.Click += do切换_Click;
        }

        void do切换_Click(object sender, EventArgs e)
        {
            _当前地图源索引 = 新索引();
            _F地图.加载地图(_地图路径列表[_当前地图源索引]);
            this.toolTip1.SetToolTip(this.do切换, string.Format("当前地图[{0}],下一地图[{1}]", Path.GetFileNameWithoutExtension(_地图路径列表[_当前地图源索引]), Path.GetFileNameWithoutExtension(_地图路径列表[新索引()])));
        }

        private int 新索引()
        {
            var __temp  = _当前地图源索引 + 1;
            if (__temp >= _地图路径列表.Count)
            {
                __temp = 0;
            }
            return __temp;
        }
    }
}
