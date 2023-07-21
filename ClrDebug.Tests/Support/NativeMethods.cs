using System;
using System.Runtime.InteropServices;

namespace ClrDebug.Tests
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool SymSetSearchPathDelegate(IntPtr hProcess, [MarshalAs(UnmanagedType.LPStr)] string SearchPath);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool SymSetSearchPathWDelegate(IntPtr hProcess, [MarshalAs(UnmanagedType.LPWStr)] string SearchPath);

    internal static class NativeMethods
    {
        internal const string DbgHelp = "dbghelp.dll";
        private const string kernel32 = "kernel32.dll";

        [DllImport(DbgHelp, SetLastError = true)]
        internal static extern bool SymInitializeW(IntPtr hProcess, string UserSearchPath, bool fInvadeProcess);

        [DllImport(DbgHelp, SetLastError = true)]
        internal static extern bool SymSetSearchPath(IntPtr hProcess, [MarshalAs(UnmanagedType.LPStr)] string SearchPath);

        [DllImport(DbgHelp, SetLastError = true)]
        internal static extern bool SymSetSearchPathW(IntPtr hProcess, [MarshalAs(UnmanagedType.LPWStr)] string SearchPath);

        [DllImport(DbgHelp, SetLastError = true)]
        internal static extern bool SymGetSearchPath(IntPtr hProcess, IntPtr SearchPath, [In] int SearchPathLength);

        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);
    }
}
