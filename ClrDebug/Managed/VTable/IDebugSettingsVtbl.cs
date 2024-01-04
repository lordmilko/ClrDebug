using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugSettingsVtbl
    {
        public readonly IntPtr LoadSettingsFromString;
        public readonly IntPtr StoreSettingsInStream;
    }
}
