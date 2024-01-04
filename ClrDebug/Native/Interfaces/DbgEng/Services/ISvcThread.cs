using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C6648B7C-F2E4-4304-9A3E-ED71CF0F26C6")]
    [ComImport]
    public interface ISvcThread
    {
        [PreserveSig]
        HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);
        
        [PreserveSig]
        HRESULT GetKey(
            [Out] out long threadKey);
        
        [PreserveSig]
        HRESULT GetId(
            [Out] out long threadId);
    }
}
