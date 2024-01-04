using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("35C2DA2D-1359-44E6-996F-7A44C84B2956")]
    [ComImport]
    public interface IComponentFileSourceInitializer2 : IComponentFileSourceInitializer
    {
        [PreserveSig]
        new HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filePath);
        
        [PreserveSig]
        HRESULT InitializeFromHandle(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] IntPtr fileHandle);
    }
}
