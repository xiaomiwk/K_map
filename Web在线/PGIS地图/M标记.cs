using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Demo
{
    public struct M标记
    {
        public int Id { get; set; }

        public string 名称 { get; set; }

        public string 号码 { get; set; }

        public string 描述 { get; set; }

        public bool 打开描述 { get; set; }

        public Color 颜色 { get; set; } 
       
        public double 经度 { get; set; }

        public double 纬度 { get; set; }

        /// <summary>
        /// 单位：米
        /// </summary>
        public int 误差半径 { get; set; }

        /// <summary>
        /// 范围：0-360
        /// </summary>
        public double 方向 { get; set; }

        public string 时间 { get; set; }

    }
}
