using System;
using System.Runtime.InteropServices;

namespace ClrDebug.TTD
{
    public struct Module
    {
        public IntPtr szPath;
        public IntPtr cchPath;
        public GuestAddress address;
        public IntPtr size;
        public short timestamp;

        public override string ToString()
        {
            return Marshal.PtrToStringUni(szPath);
        }
    }
}
