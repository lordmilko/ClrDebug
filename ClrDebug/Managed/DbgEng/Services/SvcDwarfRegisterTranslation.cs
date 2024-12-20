namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_REGISTERTRANSLATION. The ISvcDwarfRegisterTranslation interface provides an extension to ISvcRegisterTranslation required for register translations and stack unwinding specific to DWARF.<para/>
    /// Any implementation of this interface *MUST* implement ISvcRegisterTranslation. This is above and beyond. Note that while this interface can be optional for adapting to the DWARF unwinder, it is *HIGHLY* recommended.<para/>
    /// For any architecture that does *NOT* have a physical return address register (e.g.: ARM's @lr), it is *MANDATORY*.
    /// </summary>
    public class SvcDwarfRegisterTranslation : ComObject<ISvcDwarfRegisterTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDwarfRegisterTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDwarfRegisterTranslation(ISvcDwarfRegisterTranslation raw) : base(raw)
        {
        }

        #region ISvcDwarfRegisterTranslation
        #region TranslateFromAbstractId

        /// <summary>
        /// Translates from an abstract ID to a DWARF ID. Normally, one could take an abstract ID, translate it to a canonical one via ISvcMachineArchitecture and then ask ISvcRegisterTranslation to translate it to a DWARF ID via TranslateFromCanonicalId.<para/>
        /// There are, however, some concepts in DWARF to which this may not apply. All architectures for DWARF have a return address register whether the architecture has one or not.<para/>
        /// On ARM platforms, this is the @lr register. On x86/x64, this is a synthetic register in the FDE table. Asking for the @ra abstract ID to be translated to a canonical ID will fail because the architecture does not have the concept.<para/>
        /// DWARF, however, does. You can ask for the direct translation via this method.
        /// </summary>
        public int TranslateFromAbstractId(SvcAbstractRegister abstractId)
        {
            int domainId;
            TryTranslateFromAbstractId(abstractId, out domainId).ThrowDbgEngNotOK();

            return domainId;
        }

        /// <summary>
        /// Translates from an abstract ID to a DWARF ID. Normally, one could take an abstract ID, translate it to a canonical one via ISvcMachineArchitecture and then ask ISvcRegisterTranslation to translate it to a DWARF ID via TranslateFromCanonicalId.<para/>
        /// There are, however, some concepts in DWARF to which this may not apply. All architectures for DWARF have a return address register whether the architecture has one or not.<para/>
        /// On ARM platforms, this is the @lr register. On x86/x64, this is a synthetic register in the FDE table. Asking for the @ra abstract ID to be translated to a canonical ID will fail because the architecture does not have the concept.<para/>
        /// DWARF, however, does. You can ask for the direct translation via this method.
        /// </summary>
        public HRESULT TryTranslateFromAbstractId(SvcAbstractRegister abstractId, out int domainId)
        {
            /*HRESULT TranslateFromAbstractId(
            [In] SvcAbstractRegister abstractId,
            [Out] out int domainId);*/
            return Raw.TranslateFromAbstractId(abstractId, out domainId);
        }

        #endregion
        #region TranslateTypicalCfa

        /// <summary>
        /// Translates from the abstract DWARF concept of a CFA (canonical frame address) to concrete information that an unwinder can use (e.g.: an offset from a potentially dereferenced register).<para/>
        /// This returns such information for the *TYPICAL* CFA as defined by the DWARF specification: "the stack pointer at the call site in the caller's frame" for a call frame with a *TYPICAL* prologue.<para/>
        /// This method is used to help the stack unwinder in some circumstances (e.g.: when private DWARF unwind data is not available and components are compiled with frame pointers but DWARF debug information is present).<para/>
        /// The returned "symbol location" will typically take one of three forms - @reg : cfaLocation == SvcSymbolLocationRegister - @reg + offset : cfaLocation == SvcSymbolLocationRegisterRelative - [@reg + offset]: cfaLocation == SvcSymbolLocationRegisterRelativeIndirectOffset While implementation of this method is optional, it is highly recommended.
        /// </summary>
        public SvcSymbolLocation TranslateTypicalCfa()
        {
            SvcSymbolLocation cfaLocation;
            TryTranslateTypicalCfa(out cfaLocation).ThrowDbgEngNotOK();

            return cfaLocation;
        }

        /// <summary>
        /// Translates from the abstract DWARF concept of a CFA (canonical frame address) to concrete information that an unwinder can use (e.g.: an offset from a potentially dereferenced register).<para/>
        /// This returns such information for the *TYPICAL* CFA as defined by the DWARF specification: "the stack pointer at the call site in the caller's frame" for a call frame with a *TYPICAL* prologue.<para/>
        /// This method is used to help the stack unwinder in some circumstances (e.g.: when private DWARF unwind data is not available and components are compiled with frame pointers but DWARF debug information is present).<para/>
        /// The returned "symbol location" will typically take one of three forms - @reg : cfaLocation == SvcSymbolLocationRegister - @reg + offset : cfaLocation == SvcSymbolLocationRegisterRelative - [@reg + offset]: cfaLocation == SvcSymbolLocationRegisterRelativeIndirectOffset While implementation of this method is optional, it is highly recommended.
        /// </summary>
        public HRESULT TryTranslateTypicalCfa(out SvcSymbolLocation cfaLocation)
        {
            /*HRESULT TranslateTypicalCfa(
            [Out] out SvcSymbolLocation cfaLocation);*/
            return Raw.TranslateTypicalCfa(out cfaLocation);
        }

        #endregion
        #endregion
    }
}
