﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Data = {Data}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CLRDATA_FOLLOW_STUB_BUFFER
    {
        public fixed long Data[8];
    }
}
