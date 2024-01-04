using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80E2F7C5-7159-4E92-887E-7E0347E88406")]
    [ComImport]
    public interface IModelKeyReference2 : IModelKeyReference
    {
        [PreserveSig]
        new HRESULT GetKeyName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string keyName);
        
        [PreserveSig]
        new HRESULT GetOriginalObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject originalObject);
        
        [PreserveSig]
        new HRESULT GetContextObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject containingObject);
        
        [PreserveSig]
        new HRESULT GetKey(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT GetKeyValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);
        
        [PreserveSig]
        HRESULT OverrideContextObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject newContextObject);
    }
}
