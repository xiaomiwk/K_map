using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 显示地图_示例
{
    public class M示例业务对象
    {
        public int 标识 { get; set; }

        public string 名称 { get; set; }

        public string 类型 { get; set; }

        public string 状态 { get; set; }

        public override string ToString()
        {
            return string.Format("标识:{0}{4}名称:{1}{4}类型:{2}{4}状态:{3}{4}", 标识, 名称, 类型, 状态, Environment.NewLine);
        }
    }
}
