using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6FD11E33-E5AD-410B-8011-68C6BC4BF80D")]
    [ComImport]
    public interface IDataModelScriptManager
    {
        [PreserveSig]
        HRESULT GetDefaultNameBinder(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelNameBinder ppNameBinder);
        
        [PreserveSig]
        HRESULT RegisterScriptProvider(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptProvider provider);
        
        [PreserveSig]
        HRESULT UnregisterScriptProvider(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptProvider provider);
        
        [PreserveSig]
        HRESULT FindProviderForScriptType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);
        
        [PreserveSig]
        HRESULT FindProviderForScriptExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptExtension,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);
        
        [PreserveSig]
        HRESULT EnumerateScriptProviders(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProviderEnumerator enumerator);
    }
}
