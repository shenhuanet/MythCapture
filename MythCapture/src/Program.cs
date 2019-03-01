using System;
using System.Windows.Forms;
using System.Threading;
using MythCapture.Properties;
using Microsoft.Win32;
using System.IO;

namespace MythCapture
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Console.WriteLine("--程序已启动");
            var mutex = new Mutex(true, Resources.app_name);
            if (mutex.WaitOne(0, false))
            {
                mutex.ReleaseMutex();
                new Thread(WriteFile).Start();
                AutoStartup();
                Application.Run(new res.MythCapture());
            }
            else
            {
                MessageBox.Show("神话快捷截图，程序已经在运行了", Resources.app_name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private static void WriteFile()
        {
            var dll = Resources.PrScrn;
            var path = Application.StartupPath + @"\PrScrn.dll";
            using (var fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(dll, 0, dll.Length);
            }
        }

        /// <summary>
        /// 自动启动
        /// </summary>
        private static void AutoStartup()
        {
            var rk = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (rk?.GetValue("MythCapture") != null) return;
            rk?.SetValue("MythCapture", Application.ExecutablePath);
            rk?.Close();
            Console.WriteLine("--已设置开机自启");
        }
    }
}
