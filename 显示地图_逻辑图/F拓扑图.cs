using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_逻辑图
{
    public partial class F拓扑图 : F地图, IF拓扑图
    {
        private const double _经度比例 = 360.0 / 8379.0;

        private const double _纬度比例 = 360.0 / 8379.0;

        private int _默认层级 = 5;

        public F拓扑图()
        {
        }

        private M经纬度 转换(Point __点)
        {
            return new M经纬度(__点.X * _经度比例, __点.Y * _纬度比例);
        }

        private M经纬度 转换(int __X, int __Y)
        {
            return new M经纬度(__X * _经度比例, __Y * _纬度比例);
        }

        public void 初始化(Point __中心位置, int __层级, Color __背景色)
        {
            if (__层级 > 9 || __层级 < 3)
            {
                __层级 = 5;
            }
            base.加载地图("");
            base.初始化地图参数(E地图源.无, 转换(__中心位置), _默认层级 - (__层级 - 1) / 2, _默认层级 + (__层级 - 1) / 2);

        }

        public UInt64 添加点(Point __点, Bitmap __图片, string __标题, object __绑定对象, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver)
        {
            return base.添加点(转换(__点), __图片, __标题, __绑定对象, null, __标题显示方式);
        }

        public void 定位(Point __点)
        {
            base.定位(转换(__点));
        }

        public UInt64 添加线(List<Point> __点列表, int __线宽度, Color __线颜色, object __绑定对象 = null)
        {
            return base.添加线(__点列表.Select(转换).ToList(), __线宽度, __线颜色, __绑定对象);
        }

        public UInt64 添加圆(Point __圆心, int __半径, M区域绘制参数 __绘制参数, object __绑定对象 = null)
        {
            return base.添加圆(转换(__圆心), __半径, __绘制参数, __绑定对象);
        }

        public UInt64 添加多边形(List<Point> __点列表, M区域绘制参数 __绘制参数, object __绑定对象 = null)
        {
            return base.添加多边形(__点列表.Select(转换).ToList(), __绘制参数, __绑定对象);
        }


        public void 删除点(ulong __标识)
        {
            base.删除点(__标识);
        }

        public void 删除线(ulong __标识)
        {
            base.删除线(__标识);
        }

        public void 删除圆(ulong __标识)
        {
            base.删除圆(__标识);
        }

        public void 删除多边形(ulong __标识)
        {
            base.删除多边形(__标识);
        }
    }
}
