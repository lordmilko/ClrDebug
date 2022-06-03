using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D28F3C5A-9634-4206-A509-477552EEFB10")]
    [ComImport]
    public interface ICLRDebugging
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OpenVirtualProcess(
            [In] ulong moduleBaseAddress,
            [MarshalAs(UnmanagedType.IUnknown), In]
            object pDataTarget,
            [MarshalAs(UnmanagedType.Interface), In]
            ICLRDebuggingLibraryProvider pLibraryProvider,
            [In] ref CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion,
            [In] ref Guid riidProcess,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppProcess,
            [In] [Out] ref CLR_DEBUGGING_VERSION pVersion,
            out CLR_DEBUGGING_PROCESS_FLAGS pdwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CanUnloadNow(IntPtr hModule);
    }
}