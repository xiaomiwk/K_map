using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 显示地图
{
    public class M经纬度
    {
        public double 经度 { get; set; }

        public double 纬度 { get; set; }

        public E坐标类型 类型 { get; set; }

        public M经纬度() { }

        public M经纬度(double 经度, double 纬度)
        {
            this.经度 = 经度;
            this.纬度 = 纬度;
        }

        public M经纬度 偏移(double __经度, double __纬度)
        {
            return new M经纬度 { 经度 = this.经度 + __经度, 纬度 = this.纬度 + __纬度, 类型 = 类型 };
        }

        public override string ToString()
        {
            return string.Format("经度:{0};\n\r纬度:{1}", 经度, 纬度);
        }
    }
}
