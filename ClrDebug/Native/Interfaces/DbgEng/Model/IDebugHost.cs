using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B8C74943-6B2C-4EEB-B5C5-35D378A6D99D")]
    [ComImport]
    public interface IDebugHost
    {
        [PreserveSig]
        HRESULT GetHostDefinedInterface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object hostUnk);
        
        [PreserveSig]
        HRESULT GetCurrentContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);
        
        [PreserveSig]
        HRESULT GetDefaultMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore defaultMetadataStore);
    }
}
