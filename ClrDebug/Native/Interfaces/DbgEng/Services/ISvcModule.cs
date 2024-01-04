using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("360DE704-D055-483A-8E3B-BD67D2DA0133")]
    [ComImport]
    public interface ISvcModule
    {
        [PreserveSig]
        HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);
        
        [PreserveSig]
        HRESULT GetKey(
            [Out] out long moduleKey);
        
        [PreserveSig]
        HRESULT GetBaseAddress(
            [Out] out long moduleBaseAddress);
        
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long moduleSize);
        
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string moduleName);
        
        [PreserveSig]
        HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modulePath);
    }
}
