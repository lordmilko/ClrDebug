using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    internal static partial class NativeMethods
    {
        private const string kernel32 = "kernel32.dll";

#if !GENERATED_MARSHALLING
        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport(kernel32)]
        public static extern void RtlZeroMemory(IntPtr Destination, int Length);
#else
        //This is only called on Windows. On other operating systems, a delegate must
        //be provided that contains the 
        [LibraryImport(kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool CloseHandle(IntPtr handle);

        //This is only used with WinDbg which is Windows only
        [LibraryImport(kernel32)]
        public static partial void RtlZeroMemory(IntPtr Destination, int Length);
#endif
    }
}
