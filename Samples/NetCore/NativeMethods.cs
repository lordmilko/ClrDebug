using System;
using System.Runtime.InteropServices;

namespace NetCore
{
    static partial class NativeMethods
    {
        private const string kernel32 = "kernel32.dll";

#if NET8_0_OR_GREATER
        [LibraryImport(kernel32, SetLastError = true)]
        public static partial uint WaitForSingleObject([In] IntPtr hHandle, [In] int dwMilliseconds);

        [LibraryImport(kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetEvent([In] IntPtr hEvent);
#else
        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern uint WaitForSingleObject([In] IntPtr hHandle, [In] int dwMilliseconds);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool SetEvent([In] IntPtr hEvent);
#endif
    }
}
