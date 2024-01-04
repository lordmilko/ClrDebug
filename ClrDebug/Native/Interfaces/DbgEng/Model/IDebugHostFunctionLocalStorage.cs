using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F2F303B-39BE-4B6D-9BFB-4FAA49DBBD45")]
    [ComImport]
    public interface IDebugHostFunctionLocalStorage
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
