using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FF4713F1-74DD-4CBC-830C-7F13D7E31AA3")]
    [ComImport]
    public interface ISvcModuleWithTimestampAndChecksum : ISvcModule
    {
        [PreserveSig]
        new HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);
        
        [PreserveSig]
        new HRESULT GetKey(
            [Out] out long moduleKey);
        
        [PreserveSig]
        new HRESULT GetBaseAddress(
            [Out] out long moduleBaseAddress);
        
        [PreserveSig]
        new HRESULT GetSize(
            [Out] out long moduleSize);
        
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string moduleName);
        
        [PreserveSig]
        new HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modulePath);
        
        [PreserveSig]
        HRESULT GetTimeDateStamp(
            [Out] out int moduleTimeDateStamp);
        
        [PreserveSig]
        HRESULT GetCheckSum(
            [Out] out int moduleCheckSum);
    }
}
