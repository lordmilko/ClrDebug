using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("50DEB97A-25CC-41C1-B467-96C5E3F454CA")]
    [ComImport]
    public interface ISvcPrivateProperties
    {
        [PreserveSig]
        HRESULT HasProperty(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasProperty);
        
        [PreserveSig]
        HRESULT GetProperty(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);
        
        [PreserveSig]
        HRESULT SetProperty(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int valueSize,
            [In] IntPtr valueBuffer);
    }
}
