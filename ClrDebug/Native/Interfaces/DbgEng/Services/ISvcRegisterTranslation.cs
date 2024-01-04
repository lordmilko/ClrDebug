using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C5A05162-A375-48FC-AB00-3045C6386836")]
    [ComImport]
    public interface ISvcRegisterTranslation
    {
        [PreserveSig]
        HRESULT TranslateFromCanonicalId(
            [In] int canonicalId,
            [Out] out int domainId);
        
        [PreserveSig]
        HRESULT TranslateToCanonicalId(
            [In] int domainId,
            [Out] out int canonicalId);
    }
}
