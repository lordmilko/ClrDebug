using System;
using System.Runtime.InteropServices;

namespace DbgEngTypedData
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LIST_ENTRY
    {
        public IntPtr Flink;
        public IntPtr Blink;
    }
}
