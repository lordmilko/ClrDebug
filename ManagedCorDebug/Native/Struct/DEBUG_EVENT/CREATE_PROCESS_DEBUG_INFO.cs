using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CREATE_PROCESS_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"hFile = {hFile}, hProcess = {hProcess}, hThread = {hThread}, lpBaseOfImage = {lpBaseOfImage}, dwDebugInfoFileOffset = {dwDebugInfoFileOffset}, nDebugInfoSize = {nDebugInfoSize}, lpThreadLocalBase = {lpThreadLocalBase}, lpStartAddress = {lpStartAddress}, lpImageName = {lpImageName}, fUnicode = {fUnicode}";

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
