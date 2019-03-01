using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MythCapture
{
    internal static class HotKeyHelper
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(
            IntPtr hwnd, //要定义热键的窗口的句柄
            int id,      //定义热键ID（不能与其它ID重复）
            HotKeyModifiers hotKeyModifiers, //标识热键是否在按Alt、Ctrl、Shift等键时才会生效
            Keys vk      //定义热键的内容
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hwnd, int id);
    }
}
