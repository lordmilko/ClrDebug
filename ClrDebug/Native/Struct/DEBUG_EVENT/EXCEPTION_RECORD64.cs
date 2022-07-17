using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("ExceptionCode = {ExceptionCode}, ExceptionFlags = {ExceptionFlags}, ExceptionRecord = {ExceptionRecord}, ExceptionAddress = {ExceptionAddress}, NumberParameters = {NumberParameters}, ExceptionInformation = {ExceptionInformation}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EXCEPTION_RECORD64
    {
        public NTSTATUS ExceptionCode;
        public ExceptionFlags ExceptionFlags;
        public IntPtr ExceptionRecord;
        public IntPtr ExceptionAddress;
        public int NumberParameters;
        public int __unusedAlignment;
        public fixed long ExceptionInformation[15];
    }
}
