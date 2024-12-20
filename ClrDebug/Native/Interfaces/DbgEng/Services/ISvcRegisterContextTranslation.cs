using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_REGISTERCONTEXTTRANSLATION. The ISvcRegisterContextTranslation interface provides translation between register context domains.<para/>
    /// This can be utilized, for instance, to translate from Windows context record (struct CONTEXT / AMD64_CONTEXT, etc...) to a canonical ISvcRegisterContext or vice-versa.<para/>
    /// It can also be used to translate from a custom context record (e.g.: a custom architecture's user mode register context stored in a core dump) to a canonical ISvcRegisterContext or vice-versa.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EDDC117F-50EB-48C6-B201-1B7CB9C675AB")]
    [ComImport]
    public interface ISvcRegisterContextTranslation
    {
        /// <summary>
        /// Translates from a domain specific context record to a canonical context record.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateToCanonicalContext(
            [In] int domainContextSize,
            [In] IntPtr domainContext,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext canonicalContext);

        /// <summary>
        /// Gets the size of the domain specific context record.
        /// </summary>
        [PreserveSig]
        int GetDomainContextSize();

        /// <summary>
        /// Translates from a canonical context record to a domain specific context record.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateFromCanonicalContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext canonicalContext,
            [In] int domainRecordSize,
            [Out] IntPtr domainContext);
    }
}
