using System;
using System.Runtime.InteropServices;
using DbgEngTypedData;

namespace DbgEngConsole
{
    internal static class NativeMethods
    {
        private const string kernel32 = "kernel32.dll";
        private const string dbghelp = "dbghelp.dll";

        [DllImport(kernel32)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        static extern IntPtr LocalFree(IntPtr hMem);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);

        [DllImport(dbghelp, SetLastError = true)]
        public static extern bool SymGetTypeInfo(
            [In] IntPtr hProcess,
            [In] long ModBase,
            [In] int TypeId,
            [In] IMAGEHLP_SYMBOL_TYPE_INFO GetType,
            [Out] out IntPtr pInfo);
    }
}
