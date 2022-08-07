using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    internal static class NativeMethods
    {
        private const string kernel32 = "kernel32.dll";

        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport(kernel32)]
        public static extern void RtlZeroMemory(IntPtr Destination, int Length);
    }
}
