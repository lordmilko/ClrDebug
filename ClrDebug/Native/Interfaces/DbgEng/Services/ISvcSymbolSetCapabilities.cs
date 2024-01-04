using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("05D19D56-C15E-4C1D-9125-BB14D61B9784")]
    [ComImport]
    public interface ISvcSymbolSetCapabilities
    {
        [PreserveSig]
        HRESULT QueryCapability(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);
    }
}
