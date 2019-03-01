using MythCapture.Properties;
using System;
using System.Windows.Forms;

namespace MythCapture
{
    public partial class MythCapture : Form
    {
        private const int WM_HOTKEY = 0x312; //窗口消息-热键
        private const int WM_CREATE = 0x1;   //窗口消息-创建
        private const int WM_DESTROY = 0x2;  //窗口消息-销毁

        public MythCapture()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_CREATE:
                    RegisterHotKey();
                    break;
                case WM_DESTROY:
                    UnRegisterHotKey();
                    break;
                case WM_HOTKEY:
                    OnHotKeyEvent(m.WParam.ToInt32());
                    break;
                default:
                    break;
            }
        }

        private void OnHotKeyEvent(int keyId)
        {
            Console.WriteLine("--截图按键：" + keyId);
            PrScrnHelper.PrScrn();
        }

        /// <summary>
        /// 注册热键，窗体句柄，热键ID，辅助键，实键
        /// </summary>
        private void RegisterHotKey()
        {
            HotKeyModifiers hm = HotKeyModifiers.ModControl | HotKeyModifiers.ModAlt;
            bool success = HotKeyHelper.RegisterHotKey(this.Handle, 0, hm, Keys.A);
            Console.WriteLine("--热键注册：" + success);
            if (!success)
            {
                MessageBox.Show("神话快捷截图，热键 Ctrl + Alt + A 已被其它程序占用\n使用替代方案 Alt + A",
                    Resources.app_name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool success2 = HotKeyHelper.RegisterHotKey(this.Handle, 0, HotKeyModifiers.ModAlt, Keys.A);
                if (!success2)
                {
                    DialogResult result = MessageBox.Show("神话快捷截图，热键 Alt + A 已被其它程序占用，程序将退出",
                      Resources.app_name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
        }

        /// <summary>
        /// 取消热键，程序退出时调用，窗体句柄，热键ID
        /// </summary>
        private void UnRegisterHotKey()
        {
            bool success = HotKeyHelper.UnregisterHotKey(this.Handle, 0);
            Console.WriteLine("--反注册热键：" + success);
        }
    }
}
