using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f2df5f53-071f-47bd-9de6-5734c3fed689")]
    [ComImport]
    public interface IDebugAdvanced
    {
        [PreserveSig]
        HRESULT GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        [PreserveSig]
        HRESULT SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);
    }
}
