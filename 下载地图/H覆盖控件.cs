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
            //Application.DoEvents();
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
            //Application.DoEvents();
        }

    }


    //public class F等待 : DevExpress.XtraWaitForm.ProgressPanel, I覆盖控件
    //{
    //    public F等待()
    //    {
    //        this.Caption = "请等待";
    //        this.Description = "......";
    //    }

    //    public void 隐藏()
    //    {
    //        触发已隐藏();
    //        已隐藏 = null;
    //    }

    //    public event Action 已隐藏;

    //    protected void 触发已隐藏()
    //    {
    //        Action handler = 已隐藏;
    //        if (handler != null) handler();
    //    }
    //}

    //void doXXX_Click(object sender, EventArgs e)
    //{
    //    //获取并验证输入

    //    //限制界面
    //    var __等待面板 = new Win.系统.F等待();
    //    this.out辅助容器.创建局部覆盖控件(__等待面板, null);

    //    //配置任务
    //    var __任务 = new Task(() => 

    //    }));

    //    //反馈操作结果
    //    __任务.ContinueWith(task =>
    //    {
    //        __等待面板.隐藏();
    //        this.显示操作成功("");
    //    },
    //        CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
    //         TaskScheduler.FromCurrentSynchronizationContext());
    //    __任务.ContinueWith(task =>
    //    {
    //        __等待面板.隐藏();
    //        this.显示操作失败("");
    //        task.Exception.Handle(q => true);
    //    },
    //        CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
    //         TaskScheduler.FromCurrentSynchronizationContext());

    //    //开始任务
    //    __任务.Start();
    //}


}
