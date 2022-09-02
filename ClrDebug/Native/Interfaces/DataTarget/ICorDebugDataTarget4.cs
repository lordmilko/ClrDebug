using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E799DC06-E099-4713-BDD9-906D3CC02CF2")]
    [ComImport]
    public interface ICorDebugDataTarget4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT VirtualUnwind(
            [In] int threadID,
            [In] int contextSize,
            [In, Out] IntPtr context);
    }
}
