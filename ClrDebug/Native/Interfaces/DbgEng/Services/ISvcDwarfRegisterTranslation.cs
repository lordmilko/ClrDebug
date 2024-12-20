using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_REGISTERTRANSLATION. The ISvcDwarfRegisterTranslation interface provides an extension to ISvcRegisterTranslation required for register translations and stack unwinding specific to DWARF.<para/>
    /// Any implementation of this interface *MUST* implement ISvcRegisterTranslation. This is above and beyond. Note that while this interface can be optional for adapting to the DWARF unwinder, it is *HIGHLY* recommended.<para/>
    /// For any architecture that does *NOT* have a physical return address register (e.g.: ARM's @lr), it is *MANDATORY*.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A61B284D-EC7D-4EE7-A3B0-99B59F171F9A")]
    [ComImport]
    public interface ISvcDwarfRegisterTranslation
    {
        /// <summary>
        /// Translates from an abstract ID to a DWARF ID. Normally, one could take an abstract ID, translate it to a canonical one via ISvcMachineArchitecture and then ask ISvcRegisterTranslation to translate it to a DWARF ID via TranslateFromCanonicalId.<para/>
        /// There are, however, some concepts in DWARF to which this may not apply. All architectures for DWARF have a return address register whether the architecture has one or not.<para/>
        /// On ARM platforms, this is the @lr register. On x86/x64, this is a synthetic register in the FDE table. Asking for the @ra abstract ID to be translated to a canonical ID will fail because the architecture does not have the concept.<para/>
        /// DWARF, however, does. You can ask for the direct translation via this method.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateFromAbstractId(
            [In] SvcAbstractRegister abstractId,
            [Out] out int domainId);

        /// <summary>
        /// Translates from the abstract DWARF concept of a CFA (canonical frame address) to concrete information that an unwinder can use (e.g.: an offset from a potentially dereferenced register).<para/>
        /// This returns such information for the *TYPICAL* CFA as defined by the DWARF specification: "the stack pointer at the call site in the caller's frame" for a call frame with a *TYPICAL* prologue.<para/>
        /// This method is used to help the stack unwinder in some circumstances (e.g.: when private DWARF unwind data is not available and components are compiled with frame pointers but DWARF debug information is present).<para/>
        /// The returned "symbol location" will typically take one of three forms - @reg : cfaLocation == SvcSymbolLocationRegister - @reg + offset : cfaLocation == SvcSymbolLocationRegisterRelative - [@reg + offset]: cfaLocation == SvcSymbolLocationRegisterRelativeIndirectOffset While implementation of this method is optional, it is highly recommended.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateTypicalCfa(
            [Out] out SvcSymbolLocation cfaLocation);
    }
}
