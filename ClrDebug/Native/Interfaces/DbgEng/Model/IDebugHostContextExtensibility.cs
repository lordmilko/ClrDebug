using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("35AE8E40-F234-4EF1-B8EA-0DFBC58A2043")]
    [ComImport]
    public interface IDebugHostContextExtensibility
    {
        [return: MarshalAs(UnmanagedType.U1)]
        bool HasExtensionData(
            [In] int blobId);
        
        [PreserveSig]
        HRESULT ReadExtensionData(
            [In] int blobId,
            [In] int bufferSize,
            [Out] IntPtr buffer);
        
        [PreserveSig]
        HRESULT CloneContextForModification(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContextExtension extensionHandle);
        
        [PreserveSig]
        HRESULT CloneContextWithModification(
            [In] int blobId,
            [In] int dataSize,
            [In] IntPtr data,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext clonedContext);
    }
}
