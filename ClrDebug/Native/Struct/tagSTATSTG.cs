using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("pwcsName = {pwcsName}, type = {type}, cbSize = {cbSize.ToString(),nq}, mtime = {mtime.ToString(),nq}, ctime = {ctime.ToString(),nq}, atime = {atime.ToString(),nq}, grfMode = {grfMode}, grfLocksSupported = {grfLocksSupported}, clsid = {clsid.ToString(),nq}, grfStateBits = {grfStateBits}, reserved = {reserved}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public partial struct tagSTATSTG
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwcsName;
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
