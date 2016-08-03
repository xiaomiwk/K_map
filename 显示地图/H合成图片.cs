using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GMap地图
{
    public static class H合成图片
    {
        /// <param name="__柱形宽度">单位:像素</param>
        /// <param name="__柱形高度列表">单位:像素</param>
        public static Bitmap 添加左侧柱状图(Bitmap __图片, int __柱形宽度, List<int> __柱形高度列表, List<Color> __颜色列表, bool __带边框 = false)
        {
            //状态值
            var __状态图宽度 = __柱形高度列表.Count * (__柱形宽度 + 1);  //加1像素起分割间隔作用
            var __合成图片 = new Bitmap(__图片.Width + __状态图宽度, Math.Max(__图片.Height, __柱形高度列表.Max()));
            var __绘图 = Graphics.FromImage(__合成图片);
            var __x轴当前位置 = 0;
            for (int i = 0; i < __柱形高度列表.Count; i++)
            {
                绘制柱状图(__绘图, __x轴当前位置, __合成图片.Height, __柱形宽度, __柱形高度列表[i], __颜色列表[i]);
                __x轴当前位置 += __柱形宽度 + 1;
            }

            //边框
            if (__带边框)
            {
                var __直线 = new Pen(Color.Gold);
                __绘图.DrawRectangle(__直线, 0, 0, __合成图片.Width - 1, __合成图片.Height - 1);
            }

            __绘图.DrawImage(__图片, __状态图宽度, __合成图片.Height - __图片.Height, __图片.Width, __图片.Height);
            return __合成图片;
        }

        private static void 绘制柱状图(Graphics __绘图, int __起始X坐标, int __图片高度, int __柱状图1宽度, int __柱状图1高度, Color __填充色)
        {
            var __填充刷 = new SolidBrush(__填充色);
            __绘图.FillRectangle(__填充刷, __起始X坐标, __图片高度 - __柱状图1高度, __柱状图1宽度, __柱状图1高度);
        }

    }
}
