using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("854FD751-C2E1-4EB2-B525-6619CB97A588")]
    [ComImport]
    public interface IDebugHostSymbols
    {
        [PreserveSig]
        HRESULT CreateModuleSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszModuleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMinVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMaxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModuleSignature ppModuleSignature);
        
        [PreserveSig]
        HRESULT CreateTypeSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule module,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        HRESULT CreateTypeSignatureForModuleRange(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string minVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string maxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator moduleEnum);
        
        [PreserveSig]
        HRESULT FindModuleByName(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);
        
        [PreserveSig]
        HRESULT FindModuleByLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location moduleLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);
        
        [PreserveSig]
        HRESULT GetMostDerivedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out] out Location derivedLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType derivedType);
    }
}
