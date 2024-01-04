using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F980577B-73FA-40FE-95A3-C4D44100FD68")]
    [ComImport]
    public interface ISvcWindowsKdInfrastructure
    {
        [PreserveSig]
        HRESULT FindKdVersionBlock(
            [Out] out long kdVersionBlockAddress);
        
        [PreserveSig]
        HRESULT FindKdDebuggerDataBlock(
            [Out] out long kdDebuggerDataBlockAddress);
        
        [PreserveSig]
        HRESULT GetKdDebuggerDataBlock(
            [Out] out IntPtr kdDebuggerDataBlock,
            [Out] out long dataBlockSize);
    }
}
