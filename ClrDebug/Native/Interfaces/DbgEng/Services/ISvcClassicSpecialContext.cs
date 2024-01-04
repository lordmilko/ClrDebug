using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("33D1251E-BD8C-489E-B07A-CC545A27042C")]
    [ComImport]
    public interface ISvcClassicSpecialContext
    {
        [PreserveSig]
        long GetSpecialContextSize();
        
        [PreserveSig]
        HRESULT GetSpecialContext(
            [In] long bufferSize,
            [Out] IntPtr contextBuffer,
            [Out] out long contextSize);
        
        [PreserveSig]
        HRESULT SetSpecialContext(
            [In] long bufferSize,
            [In] IntPtr contextBuffer);
    }
}
