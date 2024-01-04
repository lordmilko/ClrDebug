using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5253DCF8-5AFF-4C62-B302-56A289E00998")]
    [ComImport]
    public interface IModelKeyReference
    {
        [PreserveSig]
        HRESULT GetKeyName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string keyName);
        
        [PreserveSig]
        HRESULT GetOriginalObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject originalObject);
        
        [PreserveSig]
        HRESULT GetContextObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject containingObject);
        
        [PreserveSig]
        HRESULT GetKey(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT GetKeyValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);
    }
}
