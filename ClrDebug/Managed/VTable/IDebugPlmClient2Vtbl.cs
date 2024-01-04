using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugPlmClient2Vtbl
    {
        public readonly IntPtr LaunchPlmPackageForDebugWide;
        public readonly IntPtr LaunchPlmBgTaskForDebugWide;
    }
}
