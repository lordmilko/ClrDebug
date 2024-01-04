using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugPlmClientVtbl
    {
        public readonly IntPtr LaunchPlmPackageForDebugWide;
    }
}
