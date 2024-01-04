using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6BAF1F48-65EE-4FF2-B3AF-10C7F21D38B2")]
    [ComImport]
    public interface IDebugHostSymbols2 : IDebugHostSymbols
    {
        [PreserveSig]
        new HRESULT CreateModuleSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszModuleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMinVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMaxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModuleSignature ppModuleSignature);
        
        [PreserveSig]
        new HRESULT CreateTypeSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule module,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        new HRESULT CreateTypeSignatureForModuleRange(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string minVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string maxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        new HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator moduleEnum);
        
        [PreserveSig]
        new HRESULT FindModuleByName(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);
        
        [PreserveSig]
        new HRESULT FindModuleByLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location moduleLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);
        
        [PreserveSig]
        new HRESULT GetMostDerivedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out] out Location derivedLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType derivedType);
        
        [PreserveSig]
        HRESULT DemangleSymbolName(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pSymbol,
            [In] int flags,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDemangledSymbolName);
    }
}
