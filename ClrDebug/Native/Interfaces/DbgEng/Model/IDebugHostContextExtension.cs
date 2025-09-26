using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5E67115D-5449-4553-A9E9-CA446578CAB2")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostContextExtension
    {
        [PreserveSig]
        HRESULT AddExtensionData(
            [In] int blobId,
            [In] int dataSize,
            [In] IntPtr data);
        
        [PreserveSig]
        HRESULT FinalizeContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext immutableContext);
    }
}
