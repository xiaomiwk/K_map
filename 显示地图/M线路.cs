using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 显示地图
{
    public class M线路
    {
        public List<M经纬度> 点集合 { get; set; }

        public string 名称 { get; set; }

        public object 绑定对象 { get; set; }

        public M经纬度 起点
        {
            get
            {
                if (点集合.Count > 0)
                {
                    return 点集合[0];
                }

                return null;
            }
        }

        public M经纬度 终点
        {
            get
            {
                if (点集合.Count > 1)
                {
                    return 点集合[点集合.Count - 1];
                }

                return null;
            }
        }

        public M线路(string __名称)
            : this()
        {
            名称 = __名称;
        }

        public M线路(List<M经纬度> __步骤点, string __名称)
        {
            点集合.AddRange(__步骤点);
            名称 = __名称;
        }

        public List<string> 步骤说明 { get; set; }

        /// <summary>
        /// 单位:mi
        /// </summary>
        public int 距离 { get; set; }

        public string 备注 { get; set; }

        public M线路()
        {
            this.点集合 = new List<M经纬度>();
            this.步骤说明 = new List<string>();
        }
    }
}
