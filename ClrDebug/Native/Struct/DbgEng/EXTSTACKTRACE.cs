using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("FramePointer = {FramePointer.ToString(),nq}, ProgramCounter = {ProgramCounter.ToString(),nq}, ReturnAddress = {ReturnAddress.ToString(),nq}, Args0 = {Args0.ToString(),nq}, Args1 = {Args1.ToString(),nq}, Args2 = {Args2.ToString(),nq}, Args3 = {Args3.ToString(),nq}")]
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
