using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("ExceptionCode = {ExceptionCode}, ExceptionFlags = {ExceptionFlags}, ExceptionRecord = {ExceptionRecord}, ExceptionAddress = {ExceptionAddress}, NumberParameters = {NumberParameters}, ExceptionInformation = {ExceptionInformation}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct EXCEPTION_RECORD
    {
        public NTSTATUS ExceptionCode;
        public ExceptionFlags ExceptionFlags;
        public IntPtr ExceptionRecord;
        public IntPtr ExceptionAddress;
        public int NumberParameters;

        //Each ExceptionInformation record is a native integer large. The options for representing this is either to
        //have a fixed array of nint (not supported in C# 6), a fixed array of IntPtr (not allowed) or a byval array of IntPtr
        //(the default marshaller freaks out because of all the crazy unioning in the DEBUG_EVENT). As such the only remaining
        //option is to list all the records manually.

        public IntPtr ExceptionInformation_0;
        public IntPtr ExceptionInformation_1;
        public IntPtr ExceptionInformation_2;
        public IntPtr ExceptionInformation_3;
        public IntPtr ExceptionInformation_4;
        public IntPtr ExceptionInformation_5;
        public IntPtr ExceptionInformation_6;
        public IntPtr ExceptionInformation_7;
        public IntPtr ExceptionInformation_8;
        public IntPtr ExceptionInformation_9;
        public IntPtr ExceptionInformation_10;
        public IntPtr ExceptionInformation_11;
        public IntPtr ExceptionInformation_12;
        public IntPtr ExceptionInformation_13;
        public IntPtr ExceptionInformation_14;
    }
}
