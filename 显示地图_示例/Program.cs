using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 显示地图_示例
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new F主窗口());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is ApplicationException)
            {
                MessageBox.Show(e.Exception.Message);
            }
        }
    }
}
