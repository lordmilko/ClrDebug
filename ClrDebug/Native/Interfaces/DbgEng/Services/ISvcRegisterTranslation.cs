using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_REGISTERTRANSLATION. The ISvcRegisterTranslation interface provides translation between register numbering domains.<para/>
    /// This can be utilized, for instance, to translate from a canonical register ID to a register ID specific to some ABI definition (e.g.: DWARF information for a platform on Linux).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C5A05162-A375-48FC-AB00-3045C6386836")]
    [ComImport]
    public interface ISvcRegisterTranslation
    {
        /// <summary>
        /// Translates from a canonical register ID to a domain specific register ID. The canonical register ID is whatever the architecture service defines for a given architecture.<para/>
        /// A domain specific register ID may be how register numbers are stored in a PDB for a given architecture (e.g.: CodeView identifiers) or how register numbers are stored in DWARF for a given architecture, etc...<para/>
        /// If there is no mapping from the canonical ID to a domain ID, E_BOUNDS is returned.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateFromCanonicalId(
            [In] int canonicalId,
            [Out] out int domainId);

        /// <summary>
        /// Translates from a domain specific register ID to a canonical register ID. The canonical register ID is whatever the architecture services defines for a given architecture.<para/>
        /// A domain specific register ID may be how register numbers are stored in a PDB for a given architecture (e.g.: CodeView identifiers) or how register numbers are stored in DWARF for a given architecture, etc...<para/>
        /// If there is no mapping from the domain specific ID to a canonical ID, E_BOUNDS is returned.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateToCanonicalId(
            [In] int domainId,
            [Out] out int canonicalId);
    }
}
