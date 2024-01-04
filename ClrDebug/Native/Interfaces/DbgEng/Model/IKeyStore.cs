using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0FC7557D-401D-4FCA-9365-DA1E9850697C")]
    [ComImport]
    public interface IKeyStore
    {
        [PreserveSig]
        HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        HRESULT GetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);
        
        [PreserveSig]
        HRESULT ClearKeys();
    }
}
