using System.Runtime.InteropServices;

namespace MythCapture
{
    /// <summary>
    /// DLL辅助类
    /// </summary>
    class PrScrnHelper
    {
        [DllImport("PrScrn.dll", EntryPoint = "PrScrn")]
        public static extern int PrScrn();
    }
}
