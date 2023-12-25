using System.Runtime.InteropServices;

namespace ClrDebug.Tests
{
    internal partial class NativeMethods
    {
        internal const string dbghelp = "dbghelp.dll";
        private const string kernel32 = "kernel32.dll";

        [LibraryImport(kernel32, SetLastError = true)]
        public static partial IntPtr GetModuleHandleW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

        [LibraryImport(kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            IntPtr lpBuffer,
            int dwSize,
            out int lpNumberOfBytesRead);

        [LibraryImport(dbghelp, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool SymInitializeW(
            IntPtr hProcess,
            [MarshalAs(UnmanagedType.LPWStr)] string UserSearchPath,
            [MarshalAs(UnmanagedType.Bool)] bool fInvadeProcess);

        [LibraryImport(dbghelp, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool SymCleanup(
            IntPtr hProcess);

        [LibraryImport(dbghelp, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SymGetDiaSession(IntPtr hProcess, long modBase, out IntPtr session);

        [LibraryImport(dbghelp, SetLastError = true)]
        internal static partial ulong SymLoadModuleExW(
            IntPtr hProcess,
            [Optional] IntPtr hFile,
            [Optional, MarshalAs(UnmanagedType.LPWStr)] string ImageName,
            [Optional, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [Optional] ulong BaseOfDll,
            [Optional] int DllSize,
            [Optional] IntPtr Data,
            [Optional] int Flags);
    }
}
