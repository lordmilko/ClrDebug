using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
    public struct STARTUPINFO
    {
        public int cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public int dwX;
        public int dwY;
        public int dwXSize;
        public int dwYSize;
        public int dwXCountChars;
        public int dwYCountChars;
        public int dwFillAttribute;
        public int dwFlags;
        public short wShowWindow;
        public short cbReserved2;
        private IntPtr lpReserved2;
        public SafeFileHandle hStdInput;
        public SafeFileHandle hStdOutput;
        public SafeFileHandle hStdError;
    }
}
