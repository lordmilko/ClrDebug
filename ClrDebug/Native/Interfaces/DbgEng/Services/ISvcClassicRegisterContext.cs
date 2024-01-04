using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D9E1F476-4FAE-4051-89C9-45D25925DB41")]
    [ComImport]
    public interface ISvcClassicRegisterContext
    {
        [PreserveSig]
        long GetContextSize();
        
        [PreserveSig]
        HRESULT GetContext(
            [In] long bufferSize,
            [Out] IntPtr contextBuffer,
            [Out] out long contextSize);
        
        [PreserveSig]
        HRESULT SetContext(
            [In] long bufferSize,
            [In] IntPtr contextBuffer);
    }
}
