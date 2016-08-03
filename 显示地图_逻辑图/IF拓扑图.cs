using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 显示地图;

namespace 显示地图_逻辑图
{
    public interface IF拓扑图
    {
        void 初始化(Point __中心位置, int __层级, Color __背景色);

        int 最小层级 { get; }

        int 最大层级 { get; }

        int 当前层级 { get; set; }

        /// <summary>
        /// 参数为当前层级
        /// </summary>
        event Action<int> 地图缩放;

        UInt64 添加点(Point __点1, Bitmap __图片, string __标题, object __绑定对象, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver);

        void 删除点(UInt64 __标识);

        void 定位(Point __点);

        UInt64 添加线(List<Point> __点列表, int __线宽度, Color __线颜色, object __绑定对象 = null);

        void 删除线(UInt64 __标识);

        UInt64 添加圆(Point __圆心, int __半径, M区域绘制参数 __绘制参数, object __绑定对象 = null);

        void 删除圆(UInt64 __标识);

        UInt64 添加多边形(List<Point> __点列表, M区域绘制参数 __绘制参数, object __绑定对象 = null);

        void 删除多边形(UInt64 __标识);

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object, MouseEventArgs> 单击点;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object> 进入点;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object> 离开点;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object, MouseEventArgs> 单击线;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object> 进入线;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object> 离开线;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object, MouseEventArgs> 单击多边形;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object> 进入多边形;

        /// <summary>
        /// 参数为绑定对象
        /// </summary>
        event Action<object> 离开多边形;
    }
}
