using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("nLength = {nLength}, lpSecurityDescriptor = {lpSecurityDescriptor.ToString(),nq}, bInheritHandle = {bInheritHandle}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }
}
