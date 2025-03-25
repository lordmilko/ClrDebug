using System;
using System.Runtime.InteropServices;

namespace ClrDebug.TTD
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public unsafe struct Exception
    {
        public IntPtr _unknown1;

        public int firstChance; //Can't be bool as bool requires marshalling
        public NTSTATUS ExceptionCode;

        public ExceptionFlags ExceptionFlags;
        public int _unknown2; //alignment?

        public IntPtr ExceptionRecord;
        public IntPtr ExceptionAddress;

        public int NumberParameters;
        public int __unusedAlignment;

        public fixed long ExceptionInformation[15];
    }
}
