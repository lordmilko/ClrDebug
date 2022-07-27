using System;
using System.Runtime.InteropServices;

namespace DbgEngTypedData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LDR_DATA_TABLE_ENTRY
    {
        public LIST_ENTRY InLoadOrderLinks;
        public LIST_ENTRY InMemoryOrderLinks;
        public LIST_ENTRY InInitializationOrderLinks;
        public IntPtr DllBase;
        public IntPtr EntryPoint;
        public uint SizeOfImage;
        public UNICODE_STRING FullDllName;
        public UNICODE_STRING BaseDllName;
    }
}
