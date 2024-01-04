using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7EBB44D0-3C22-41E1-AAB9-083E774CFF5D")]
    [ComImport]
    public interface ISvcDebugSourceFileMapping
    {
        [PreserveSig]
        HRESULT MapFile(
            [Out] out IntPtr mapAddress,
            [Out] out long mapSize);
        
        [PreserveSig]
        HRESULT GetHandle(
            [Out] out IntPtr pHandle);
    }
}
