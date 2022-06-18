using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("59d9b5e1-4a6f-4531-84c3-51d12da22fd4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataTarget3
    {
        [PreserveSig]
        HRESULT GetMetaData(
            [In, MarshalAs(UnmanagedType.LPWStr)] string imagePath,
            [In] int imageTimestamp,
            [In] int imageSize,
            [In] ref Guid mvid,
            [In] int mdRva,
            [In] int flags,
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [Out] out int dataSize);
    }
}
