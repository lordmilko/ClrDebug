using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("997DD0CC-A76F-4C82-8D79-EA87559D27AD")]
    [ComConversionLoss]
    [ComImport]
    public interface ISymUnmanagedSourceServerModule
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceServerData(out uint pDataByteCount, [Out] IntPtr ppData);
    }
}