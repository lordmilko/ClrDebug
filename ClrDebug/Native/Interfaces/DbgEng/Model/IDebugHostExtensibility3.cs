using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4BE234DE-D397-4378-BBB4-9055A425D7D1")]
    [ComImport]
    public interface IDebugHostExtensibility3 : IDebugHostExtensibility2
    {
        [PreserveSig]
        new HRESULT CreateFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject);
        
        [PreserveSig]
        new HRESULT DestroyFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName);
        
        [PreserveSig]
        new HRESULT CreateFunctionAliasWithMetadata(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        HRESULT ExtendHostContext(
            [In] int blobSize,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid identifier,
            [Out] out int blobId);
        
        [PreserveSig]
        HRESULT QueryHostContextExtension(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid identifier,
            [Out] out int blobId,
            [Out] out int blobSize);
        
        [PreserveSig]
        HRESULT ReleaseHostContextExtension(
            [In] int blobId);
    }
}
