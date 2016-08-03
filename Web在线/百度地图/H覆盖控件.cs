using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public interface I覆盖控件
    {
        void 隐藏();

        event Action 已隐藏;
    }

    public static class H覆盖控件
    {
        private static readonly string _类型名 = typeof(H覆盖控件).Name;

        public static void 创建全覆盖控件<T>(this Control 初始控件, T 覆盖控件, Action<T> 处理覆盖控件操作完毕)
            where T : Control, I覆盖控件
        {
            初始控件.Parent.Controls.Add(覆盖控件);
            覆盖控件.Dock = DockStyle.Fill;
            //初始控件.Parent.Controls.SetChildIndex(覆盖控件, 0);
            覆盖控件.BringToFront();
            覆盖控件.Focus();
            初始控件.Visible = false;
            覆盖控件.已隐藏 += () =>
            {
                //H调试.记录(_类型名 + ": 创建全覆盖控件", "覆盖控件.Visible = " + 覆盖控件.Visible + " 覆盖控件.Created = " + 覆盖控件.Created);
                if (处理覆盖控件操作完毕 != null)
                {
                    处理覆盖控件操作完毕(覆盖控件);
                }
                if (初始控件.Parent != null)
                {
                    初始控件.Parent.Controls.Remove(覆盖控件);
                }
                初始控件.Visible = true;
                if (覆盖控件.Created)
                {
                    覆盖控件.Dispose();
                }
            };
            Application.DoEvents();
        }

        public static void 创建局部覆盖控件<T>(this Control 初始控件, T 覆盖控件, Action<T> 处理覆盖控件操作完毕)
            where T : Control, I覆盖控件
        {
            var x = Math.Max(10, (初始控件.Parent.Width - 覆盖控件.Width) / 2);
            var y = Math.Max(10, (初始控件.Parent.Height - 覆盖控件.Height) / 2);
            创建局部覆盖控件(初始控件, 覆盖控件, 处理覆盖控件操作完毕, x, y);
        }

        public static void 创建局部覆盖控件<T>(this Control 初始控件, T 覆盖控件, Action<T> 处理覆盖控件操作完毕, int X, int Y)
            where T : Control, I覆盖控件
        {
            覆盖控件.Location = new Point(X, Y);
            初始控件.Parent.Controls.Add(覆盖控件);
            //初始控件.Parent.Controls.SetChildIndex(覆盖控件, 0);
            覆盖控件.BringToFront();
            覆盖控件.Focus();
            初始控件.Enabled = false;
            覆盖控件.已隐藏 += () =>
            {
                //H调试.记录(_类型名 + ": 创建局部覆盖控件1", "覆盖控件.Visible = " + 覆盖控件.Visible + " 覆盖控件.Created = " + 覆盖控件.Created);
                if (处理覆盖控件操作完毕 != null)
                {
                    处理覆盖控件操作完毕(覆盖控件);
                }
                if (初始控件.Parent != null)
                {
                    初始控件.Parent.Controls.Remove(覆盖控件);
                }
                初始控件.Enabled = true;
                if (覆盖控件.Created)
                {
                    覆盖控件.Dispose();
                }
            };
            Application.DoEvents();
        }

    }
}
