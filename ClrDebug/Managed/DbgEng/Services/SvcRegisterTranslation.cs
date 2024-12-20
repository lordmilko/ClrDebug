namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_REGISTERTRANSLATION. The ISvcRegisterTranslation interface provides translation between register numbering domains.<para/>
    /// This can be utilized, for instance, to translate from a canonical register ID to a register ID specific to some ABI definition (e.g.: DWARF information for a platform on Linux).
    /// </summary>
    public class SvcRegisterTranslation : ComObject<ISvcRegisterTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterTranslation(ISvcRegisterTranslation raw) : base(raw)
        {
        }

        #region ISvcRegisterTranslation
        #region TranslateFromCanonicalId

        /// <summary>
        /// Translates from a canonical register ID to a domain specific register ID. The canonical register ID is whatever the architecture service defines for a given architecture.<para/>
        /// A domain specific register ID may be how register numbers are stored in a PDB for a given architecture (e.g.: CodeView identifiers) or how register numbers are stored in DWARF for a given architecture, etc...<para/>
        /// If there is no mapping from the canonical ID to a domain ID, E_BOUNDS is returned.
        /// </summary>
        public int TranslateFromCanonicalId(int canonicalId)
        {
            int domainId;
            TryTranslateFromCanonicalId(canonicalId, out domainId).ThrowDbgEngNotOK();

            return domainId;
        }

        /// <summary>
        /// Translates from a canonical register ID to a domain specific register ID. The canonical register ID is whatever the architecture service defines for a given architecture.<para/>
        /// A domain specific register ID may be how register numbers are stored in a PDB for a given architecture (e.g.: CodeView identifiers) or how register numbers are stored in DWARF for a given architecture, etc...<para/>
        /// If there is no mapping from the canonical ID to a domain ID, E_BOUNDS is returned.
        /// </summary>
        public HRESULT TryTranslateFromCanonicalId(int canonicalId, out int domainId)
        {
            /*HRESULT TranslateFromCanonicalId(
            [In] int canonicalId,
            [Out] out int domainId);*/
            return Raw.TranslateFromCanonicalId(canonicalId, out domainId);
        }

        #endregion
        #region TranslateToCanonicalId

        /// <summary>
        /// Translates from a domain specific register ID to a canonical register ID. The canonical register ID is whatever the architecture services defines for a given architecture.<para/>
        /// A domain specific register ID may be how register numbers are stored in a PDB for a given architecture (e.g.: CodeView identifiers) or how register numbers are stored in DWARF for a given architecture, etc...<para/>
        /// If there is no mapping from the domain specific ID to a canonical ID, E_BOUNDS is returned.
        /// </summary>
        public int TranslateToCanonicalId(int domainId)
        {
            int canonicalId;
            TryTranslateToCanonicalId(domainId, out canonicalId).ThrowDbgEngNotOK();

            return canonicalId;
        }

        /// <summary>
        /// Translates from a domain specific register ID to a canonical register ID. The canonical register ID is whatever the architecture services defines for a given architecture.<para/>
        /// A domain specific register ID may be how register numbers are stored in a PDB for a given architecture (e.g.: CodeView identifiers) or how register numbers are stored in DWARF for a given architecture, etc...<para/>
        /// If there is no mapping from the domain specific ID to a canonical ID, E_BOUNDS is returned.
        /// </summary>
        public HRESULT TryTranslateToCanonicalId(int domainId, out int canonicalId)
        {
            /*HRESULT TranslateToCanonicalId(
            [In] int domainId,
            [Out] out int canonicalId);*/
            return Raw.TranslateToCanonicalId(domainId, out canonicalId);
        }

        #endregion
        #endregion
    }
}
