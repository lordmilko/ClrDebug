using System;
using System.Runtime.InteropServices;

namespace NetCore
{
    static class NativeMethods
    {
        private const string kernel32 = "kernel32.dll";

        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern uint WaitForSingleObject([In] IntPtr hHandle, [In] int dwMilliseconds);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool SetEvent([In] IntPtr hEvent);
    }
}
