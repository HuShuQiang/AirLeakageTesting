using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AirLeakageTesting
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            //如果该数组长度大于1，说明多次运行
            if (processes.Length > 1)
            {
                Environment.Exit(1);
                return;
            }

            //捕获全局异常 start
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //捕获全局异常 end
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            FormMain.myLog.Info(string.Format("捕获到未处理异常：{0}\n异常信息：{1}\n异常堆栈：{2}\r\nCLR即将退出：{3}", ex.GetType(), ex.Message, ex.StackTrace + ",msg=" + ex.Message, e.IsTerminating));
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            FormMain.myLog.Info(string.Format("捕获到未处理异常：{0}\n异常信息：{1}\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace + ",msg=" + ex.Message));
        }
    }
}
