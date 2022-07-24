using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EXTSTACKTRACE
    {
        IntPtr FramePointer;
        IntPtr ProgramCounter;
        IntPtr ReturnAddress;

        IntPtr Args0;
        IntPtr Args1;
        IntPtr Args2;
        IntPtr Args3;
    }
}
