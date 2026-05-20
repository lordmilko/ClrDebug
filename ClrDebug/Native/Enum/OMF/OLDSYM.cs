namespace ClrDebug.OMF
{
    //debsym.h defines these with the following names (but the name OLDSYM is made up)
    //NT 4 uses slightly different names, all starting with OSYM* (Old C6 Symbol Constants)

    /// <summary>
    /// Describes legacy symbol kinds found in NB00, NB01 and NB02 C6 style symbols.
    /// </summary>
    public enum OLDSYM : byte //Name is made up
    {
        /// <summary>
        /// Block start - obsolete<para/>
        /// Type: <see cref="BLKSYMTYPE"/>
        /// </summary>
        S_BLOCK = 0,

        /// <summary>
        /// Procedure start - obsolete<para/>
        /// Type: <see cref="PROCSYMTYPE"/>
        /// </summary>
        S_PROC = 1,

        /// <summary>
        /// Block, procedure, or "with" end
        /// </summary>
        S_END = 2,

        /// <summary>
        /// BP-relative<para/>
        /// Type: <see cref="BPSYMTYPE"/>
        /// </summary>
        S_BPREL = 4,

        /// <summary>
        /// Module-local symbol<para/>
        /// Type: <see cref="LOCSYMTYPE"/>
        /// </summary>
        S_LOCAL = 5,

        /// <summary>
        /// Code label - obsolete<para/>
        /// Type: <see cref="LABSYMTYPE"/>
        /// </summary>
        S_LABEL = 11,

        /// <summary>
        /// "With" start - obsolete<para/>
        /// Type: <see cref="WITHSYMTYPE"/>
        /// </summary>
        S_WITH = 12,

        /// <summary>
        /// Register variable<para/>
        /// Type: <see cref="REGSYMTYPE"/>
        /// </summary>
        S_REG = 13,

        /// <summary>
        /// Constant symbol<para/>
        /// Type: <see cref="CONSYMTYPE"/>
        /// </summary>
        S_CONST = 14,

        /// <summary>
        /// entry symbol<para/>
        /// Type: <see cref="PROCSYMTYPE"/>
        /// </summary>
        S_ENTRY = 15,

        /// <summary>
        /// noop - used for incremental padding
        /// </summary>
        S_NOOP = 16,

        /// <summary>
        /// effective code segment<para/>
        /// Type: Unknown
        /// </summary>
        S_CODSEG = 17,

        /// <summary>
        /// Used to specify a typedef<para/>
        /// Type: <see cref="TYPEDEFSYMTYPE"/>
        /// </summary>
        S_TYPEDEF = 18,

        /// <summary>
        /// Used to specify global data<para/>
        /// Type: Unknown
        /// </summary>
        S_GLOBAL = 19,

        /// <summary>
        /// Used to specify global procedure<para/>
        /// Type: Unknown
        /// </summary>
        S_GLOBPROC = 20,

        /// <summary>
        /// Used to specify local procedure<para/>
        /// Type: Unknown
        /// </summary>
        S_LOCPROC = 21,

        /// <summary>
        /// Change execution model - obsolete<para/>
        /// Type: Unknown
        /// </summary>
        S_CHGMODEL = 22,

        /// <summary>
        /// Symbol in $$PUBLICS section<para/>
        /// Type: Unknown
        /// </summary>
        S_PUBLIC = 23,

        /// <summary>
        /// Thunk start<para/>
        /// Type: <see cref="THUNKSYMTYPE"/>
        /// </summary>
        S_THUNK = 24,

        /// <summary>
        /// Start Search<para/>
        /// Type: Unknown
        /// </summary>
        S_SEARCH = 25,

        /// <summary>
        /// New version of S_BLOCK<para/>
        /// Type: <see cref="CV4BLKSYMTYPE"/>
        /// </summary>
        S_CV4BLOCK = 26,

        /// <summary>
        /// New version of S_WITH<para/>
        /// Type: <see cref="CV4WITHSYMTYPE"/>
        /// </summary>
        S_CV4WITH = 27,

        /// <summary>
        /// New version of S_LABEL<para/>
        /// Type: <see cref="CV4LABSYMTYPE"/>
        /// </summary>
        S_CV4LABEL = 28,

        /// <summary>
        /// New version of S_CHGMODEL<para/>
        /// Type: Unknown
        /// </summary>
        S_CV4CHGMODEL = 29,

        /// <summary>
        /// Some info about the compiler<para/>
        /// Type: Unknown
        /// </summary>
        S_COMPILEFLAG = 30,
    }
}
