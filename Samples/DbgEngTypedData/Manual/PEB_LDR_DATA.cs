using System;
using System.Runtime.InteropServices;

namespace DbgEngTypedData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PEB_LDR_DATA
    {
        public uint Length;
        public byte Initialized;
        public IntPtr SsHandle;
        public LIST_ENTRY InLoadOrderModuleList;
        public LIST_ENTRY InMemoryOrderModuleList;
        public LIST_ENTRY InInitializationOrderModuleList;
        public IntPtr EntryInProgress;
        public byte ShutdownInProgress;
        public IntPtr ShutdownThreadId;
    }
}