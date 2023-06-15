using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CREATE_PROCESS_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"hFile = {hFile}, hProcess = {hProcess}, hThread = {hThread}, lpBaseOfImage = 0x{((ulong)(void*)lpBaseOfImage):X}, dwDebugInfoFileOffset = {dwDebugInfoFileOffset}, nDebugInfoSize = {nDebugInfoSize}, lpThreadLocalBase = 0x{((ulong)(void*)lpThreadLocalBase):X}, lpStartAddress = 0x{((ulong)(void*)lpStartAddress):X}, lpImageName = 0x{((ulong)(void*)lpImageName):X}, fUnicode = {fUnicode}";

        public IntPtr hFile;
        public IntPtr hProcess;
        public IntPtr hThread;
        public IntPtr lpBaseOfImage;
        public int dwDebugInfoFileOffset;
        public int nDebugInfoSize;
        public IntPtr lpThreadLocalBase;
        public IntPtr lpStartAddress;
        public IntPtr lpImageName;
        public short fUnicode;
    }
}
