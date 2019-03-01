using System.Runtime.InteropServices;

namespace MythCapture
{
    /// <summary>
    /// DLL辅助类
    /// </summary>
    internal static class PrScrnHelper
    {
        [DllImport("PrScrn.dll", EntryPoint = "PrScrn")]
        public static extern int PrScrn();
    }
}
