using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("cb = {cb}, lpReserved = {lpReserved}, lpDesktop = {lpDesktop}, lpTitle = {lpTitle}, dwX = {dwX}, dwY = {dwY}, dwXSize = {dwXSize}, dwYSize = {dwYSize}, dwXCountChars = {dwXCountChars}, dwYCountChars = {dwYCountChars}, dwFillAttribute = {dwFillAttribute}, dwFlags = {dwFlags}, wShowWindow = {wShowWindow}, cbReserved2 = {cbReserved2}, lpReserved2 = {lpReserved2.ToString(),nq}, hStdInput = {hStdInput.ToString(),nq}, hStdOutput = {hStdOutput.ToString(),nq}, hStdError = {hStdError.ToString(),nq}")]
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
        public STARTF dwFlags;
        public ShowWindow wShowWindow;
        public short cbReserved2;
        private IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }
}
