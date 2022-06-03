using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3151C08D-4D09-4F9B-8838-2880BF18FE51")]
    [ComImport]
    public interface ICLRDebuggingLibraryProvider
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProvideLibrary(
            [In] ref ushort pwszFileName,
            [In] uint dwTimestamp,
            [In] uint dwSizeOfImage,
            out IntPtr phModule);
    }
}