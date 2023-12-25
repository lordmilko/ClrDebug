using System;
using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.Tests
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool SymSetSearchPathDelegate(IntPtr hProcess, [MarshalAs(UnmanagedType.LPStr)] string SearchPath);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool SymSetSearchPathWDelegate(IntPtr hProcess, [MarshalAs(UnmanagedType.LPWStr)] string SearchPath);

    internal static class NativeMethods
    {
        internal const string dbghelp = "dbghelp.dll";
        private const string kernel32 = "kernel32.dll";

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Wow64Process);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymInitializeW(IntPtr hProcess, string UserSearchPath, bool fInvadeProcess);

        [DllImport(dbghelp)]
        internal static extern bool SymCleanup(
            [In] IntPtr hProcess);

        [DllImport(dbghelp)]
        public static extern bool SymGetDiaSession(IntPtr hProcess, long modBase, out IntPtr session);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern ulong SymLoadModuleExW(
            [In] IntPtr hProcess,
            [In, Optional] IntPtr hFile,
            [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string ImageName,
            [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In, Optional] ulong BaseOfDll,
            [In, Optional] int DllSize,
            [In, Optional] IntPtr Data,
            [In, Optional] int Flags);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymSetSearchPath(IntPtr hProcess, [MarshalAs(UnmanagedType.LPStr)] string SearchPath);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymSetSearchPathW(IntPtr hProcess, [MarshalAs(UnmanagedType.LPWStr)] string SearchPath);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymGetSearchPath(IntPtr hProcess, IntPtr SearchPath, [In] int SearchPathLength);

        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetModuleHandleW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hLibModule);

        [DllImport(kernel32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "LoadLibraryW")]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(kernel32, SetLastError = true)]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] IntPtr lpBuffer,
            int dwSize,
            out int lpNumberOfBytesRead);

        [DllImport(kernel32, SetLastError = true)]
        public static extern uint WaitForSingleObject([In] IntPtr hHandle, [In] int dwMilliseconds);
    }
}
