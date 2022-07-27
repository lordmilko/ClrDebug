using System;
using System.Runtime.InteropServices;

namespace DbgEngTypedData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UNICODE_STRING
    {
        public ushort Length;
        public ushort MaximumLength;
        public IntPtr Buffer;
    }
}