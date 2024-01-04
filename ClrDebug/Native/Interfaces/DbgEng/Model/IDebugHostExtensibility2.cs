using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("91CC55E7-2A22-4494-9710-B729DAB48F71")]
    [ComImport]
    public interface IDebugHostExtensibility2 : IDebugHostExtensibility
    {
        [PreserveSig]
        new HRESULT CreateFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject);
        
        [PreserveSig]
        new HRESULT DestroyFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName);
        
        [PreserveSig]
        HRESULT CreateFunctionAliasWithMetadata(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
    }
}
