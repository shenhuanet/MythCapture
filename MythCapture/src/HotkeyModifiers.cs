using System;

namespace MythCapture
{
    [Flags()]
    public enum HotKeyModifiers
    {
        ModAlt = 0x1, ModControl = 0x2, ModShift = 0x4, ModWin = 0x8
    }
}
