using System;
using System.Runtime.InteropServices;

namespace DacTypeDump
{
    internal static class NativeMethods
    {
        private const string kernel32 = "kernel32.dll";

        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Wow64Process);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] IntPtr lpBuffer,
            int dwSize,
            out int lpNumberOfBytesRead);
    }
}
