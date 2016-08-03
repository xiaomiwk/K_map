using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 显示地图
{
    /// <summary>
    /// 不指定图层(图层=null), 表示默认图层管理
    /// </summary>
    public interface IF地图
    {
        /// <param name="__地图路径或服务器地址">文件名必须符合"城市"_"地图源"_"最小层级"-"最大层级".gmdb, 或者"http://xxx:xx"</param>
        void 加载地图(string __地图路径或服务器地址);

        void 初始化地图参数(E地图源 __地图源, M经纬度 __中心位置, int __最小层级, int __最大层级);

        E地图源 当前地图源 { get; set; }

        void 设置层级范围(int __最小层级, int __最大层级);

        int 最小层级 { get; }

        int 最大层级 { get; }

        int 当前层级 { get; set; }

        void 定位(M经纬度 __点);

        void 定位(List<M经纬度> __位置列表);

        M经纬度 屏幕坐标转经纬度(Point __相对地图控件的坐标);

        M经纬度 纠偏(M经纬度 __原始坐标);

        /// <summary>
        /// 参数为当前层级
        /// </summary>
        event Action<int> 地图缩放;

        void 添加图层(string __名称, int __顺序 = 0);

        void 删除图层(string __名称);

        void 隐藏图层(string __名称);

        void 显示图层(string __名称);

        void 调整图层顺序(string __名称, int __顺序);

        UInt64 添加点(M经纬度 __点, Image __图片, string __标题 = null, object __绑定对象 = null, string __图层名称 = null, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver, bool __偏移 = false);

        UInt64 添加点(M经纬度 __点, M点绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null);

        void 删除点(UInt64 __标识, string __图层名称 = null);

        UInt64 添加线(List<M经纬度> __点列表, int __线宽度, Color __线颜色, object __绑定对象 = null, string __图层名称 = null);

        UInt64 添加线(List<M经纬度> __点列表, Pen __画笔, bool __允许交互, object __绑定对象 = null, string __图层名称 = null);

        void 删除线(UInt64 __标识, string __图层名称 = null);

        UInt64 添加多边形(List<M经纬度> __点列表, M区域绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null);

        UInt64 添加多边形(List<M经纬度> __点列表, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, object __绑定对象 = null, string __图层名称 = null);

        void 删除多边形(UInt64 __标识, string __图层名称 = null);

        UInt64 添加矩形(M经纬度 __左上角点, M经纬度 __右下角点, M区域绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null);

        UInt64 添加矩形(M经纬度 __左上角点, M经纬度 __右下角点, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, object __绑定对象 = null, string __图层名称 = null);

        void 删除矩形(UInt64 __标识, string __图层名称 = null);

        /// <param name="__半径">单位:米</param>
        /// <param name="__绑定对象">暂不支持</param>
        UInt64 添加圆(M经纬度 __圆心, int __半径, M区域绘制参数 __绘制参数, object __绑定对象 = null, string __图层名称 = null);

        /// <param name="__半径">单位:米</param>
        /// <param name="__绑定对象">暂不支持</param>
        UInt64 添加圆(M经纬度 __圆心, int __半径, Pen __边框画笔, Brush __填充笔刷, bool __允许交互, object __绑定对象 = null, string __图层名称 = null);

        void 删除圆(UInt64 __标识, string __图层名称 = null);

        UInt64 添加麻点图(List<M经纬度> __点列表, Image __图片, string __标题 = null, E标题显示方式 __标题显示方式 = E标题显示方式.OnMouseOver, string __图层名称 = null);

        void 删除麻点图(UInt64 标识, string __图层名称 = null);

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
