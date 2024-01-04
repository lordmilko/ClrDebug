using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E7983FA1-80A7-498C-988F-518DDC5D4025")]
    [ComImport]
    public interface IDynamicKeyProviderConcept
    {
        [PreserveSig]
        HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject keyValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasKey);
        
        [PreserveSig]
        HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject keyValue,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        HRESULT EnumerateKeys(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
    }
}
