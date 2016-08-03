using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace 显示地图
{
    public class M点绘制参数
    {
        public Image 图片 { get;set;}

        public string 标题 { get;set;}

        public E标题显示方式 标题显示方式 { get;set;}

        public bool 偏移 { get;set;}

        public M点绘制参数()
        {
            标题显示方式 = E标题显示方式.OnMouseOver;
        }
    }
}
