using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EDDC117F-50EB-48C6-B201-1B7CB9C675AB")]
    [ComImport]
    public interface ISvcRegisterContextTranslation
    {
        [PreserveSig]
        HRESULT TranslateToCanonicalContext(
            [In] int domainContextSize,
            [In] IntPtr domainContext,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext canonicalContext);
        
        [PreserveSig]
        int GetDomainContextSize();
        
        [PreserveSig]
        HRESULT TranslateFromCanonicalContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext canonicalContext,
            [In] int domainRecordSize,
            [Out] IntPtr domainContext);
    }
}
