using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 下载地图
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //H行政区位置.保存省市();
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F主窗口());
        }


    }
}
