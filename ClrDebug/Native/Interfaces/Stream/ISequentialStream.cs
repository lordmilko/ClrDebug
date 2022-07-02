using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0C733A30-2A1C-11CE-ADE5-00AA0044773D")]
    [ComImport]
    public interface ISequentialStream
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemoteRead([Out] IntPtr pv, [In] int cb, [Out] out int pcbRead);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemoteWrite([In] IntPtr pv, [In] int cb, [Out] out int pcbWritten);
    }
}