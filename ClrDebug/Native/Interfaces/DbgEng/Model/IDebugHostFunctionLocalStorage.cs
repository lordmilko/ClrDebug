using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F2F303B-39BE-4B6D-9BFB-4FAA49DBBD45")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostFunctionLocalStorage
    {
        [PreserveSig]
        HRESULT GetValidRange(
            [Out] out long start,
            [Out] out long end,
            [Out, MarshalAs(UnmanagedType.U1)] out bool guaranteed);
        
        [PreserveSig]
        HRESULT GetStorageKind(
            [Out] out StorageKind kind);
        
        [PreserveSig]
        HRESULT GetRegister(
            [Out] out int registerId);
        
        [PreserveSig]
        HRESULT GetOffset(
            [Out] out long offset);
    }
}
