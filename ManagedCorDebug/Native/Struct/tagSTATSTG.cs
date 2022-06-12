using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct tagSTATSTG
    {
        [MarshalAs(UnmanagedType.LPWStr)] public string pwcsName;
        public int type;
        public ULARGE_INTEGER cbSize;
        public FILETIME mtime;
        public FILETIME ctime;
        public FILETIME atime;
        public int grfMode;
        public int grfLocksSupported;
        public Guid clsid;
        public int grfStateBits;
        public int reserved;
    }
}