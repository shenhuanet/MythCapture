using System;

namespace MythCapture
{
    [Flags()]
    public enum HotkeyModifiers
    {
        MOD_ALT = 0x1, MOD_CONTROL = 0x2, MOD_SHIFT = 0x4, MOD_WIN = 0x8
    }
}
