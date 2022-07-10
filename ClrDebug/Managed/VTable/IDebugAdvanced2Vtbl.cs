using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IDebugAdvanced2Vtbl
    {
        public readonly IntPtr GetThreadContext;
        public readonly IntPtr SetThreadContext;
        public readonly IntPtr Request;
        public readonly IntPtr GetSourceFileInformation;
        public readonly IntPtr FindSourceFileAndToken;
        public readonly IntPtr GetSymbolInformation;
        public readonly IntPtr GetSystemObjectInformation;
    }
}
